using Gaten.Net.Exception;
using Gaten.Net.Extension;
using Gaten.Net.Windows.PE.Assembly;

using static Gaten.Net.Windows.PE.Assembly.IAssembly;

namespace Gaten.Net.Windows.PE.Build.Assemble
{
    public class AssemblyParser
    {
        public enum ParseType
        {
            Pre,
            Real
        }

        /// <summary>
        /// Parse Assembly
        /// Must be set text and data section raw size when real-parse
        /// </summary>
        /// <param name="assemblyText"></param>
        /// <param name="parseType"></param>
        /// <param name="textSectionRawSize"></param>
        /// <param name="dataSectionRawSize"></param>
        /// <returns></returns>
        public static (List<Instruction>, List<Variable>) Parse(string assemblyText, ParseType parseType, uint textSectionRawSize = 0, uint dataSectionRawSize = 0)
        {
            // Initializing AddressManager
            switch (parseType)
            {
                case ParseType.Pre:
                    AddressManager.Initialize();
                    break;
                case ParseType.Real:
                    AddressManager.Initialize(textSectionRawSize, dataSectionRawSize);
                    break;
                default:
                    throw new ArgumentNullException(nameof(parseType));
            }

            int lineNumber = 0;

            try
            {
                string[] instructionTexts = assemblyText.ToUpper().Split(new string[] { "\n" }, StringSplitOptions.None).Select(p => p.Trim()).ToArray();

                foreach (string instructionText in instructionTexts)
                {
                    lineNumber++;

                    string instructionTextExcludeComment = instructionText.Split(COMMENT_TOKEN)[0].Trim();

                    if (instructionTextExcludeComment == string.Empty) // All texts were comments
                    {
                        continue;
                    }

                    int firstSpaceIndex = instructionTextExcludeComment.IndexOf(' ');

                    if (firstSpaceIndex == -1) // 1 Word
                    {
                        object head = ParseHead(instructionTextExcludeComment);

                        if (head is OpcodeType opcode) // Opcode + 0 Operand
                        {
                            AddressManager.AddInstruction(opcode);
                        }
                        else if (head is Site site) // Site
                        {
                            if (parseType == ParseType.Pre)
                            {
                                if (AddressManager.IsExistSite(site.Name))
                                {
                                    throw new AlreadyExistException(site.Name);
                                }

                                AddressManager.AddSite(site);
                            }
                        }
                    }
                    else // 1+ Words
                    {
                        string headText = instructionTextExcludeComment[..firstSpaceIndex];
                        object head = ParseHead(headText);

                        if (head is OpcodeType opcode)
                        {
                            string operandText = instructionTextExcludeComment[(firstSpaceIndex + 1)..].Trim();
                            string[] operandTexts = operandText.Split(',').Select(p => p.Trim()).ToArray();

                            if (operandTexts.Length == 1) // Opcode + 1 Operand
                            {
                                var operand1 = ParseOperand(operandTexts[0], parseType, opcode, opcode);

                                AddressManager.AddInstruction(opcode, operand1);
                            }
                            else if (operandTexts.Length == 2) // Opcode + 2 Operands
                            {
                                var operand1 = ParseOperand(operandTexts[0], parseType, null, opcode);
                                var operand2 = ParseOperand(operandTexts[1], parseType, operand1, opcode);

                                AddressManager.AddInstruction(opcode, operand1, operand2);
                            }
                        }

                        else if (head is DataType dataType)
                        {
                            string variableText = instructionTextExcludeComment[(firstSpaceIndex + 1)..].Trim();
                            string[] variableTexts = variableText.Split(',').Select(p => p.Trim()).ToArray();

                            if (variableTexts.Length == 1) // DataType + Variable Name
                            {
                                string variableName = variableTexts[0];

                                if (AddressManager.IsExistVariable(variableName))
                                {
                                    throw new AlreadyExistException(variableName);
                                }

                                AddressManager.AddVariable(dataType, variableName, 0);
                            }
                            else if (variableTexts.Length == 2) // DataType + Variable Name + Initial Value
                            {
                                string variableName = variableTexts[0];

                                if (AddressManager.IsExistVariable(variableName))
                                {
                                    throw new AlreadyExistException(variableName);
                                }

                                // Exception handling and add variable according to data type
                                switch (dataType)
                                {
                                    case DataType.BYTE:
                                        byte byteResult = ConvertToByte(variableTexts[1]);
                                        AddressManager.AddVariable(dataType, variableName, byteResult);
                                        break;

                                    case DataType.WORD:
                                        ushort wordResult = ConvertToWord(variableTexts[1]);
                                        AddressManager.AddVariable(dataType, variableName, wordResult);
                                        break;

                                    case DataType.DWORD:
                                        uint dwordResult = ConvertToDword(variableTexts[1]);
                                        AddressManager.AddVariable(dataType, variableName, dwordResult);
                                        break;

                                    case DataType.QWORD:
                                        ulong qwordResult = ConvertToQword(variableTexts[1]);
                                        AddressManager.AddVariable(dataType, variableName, qwordResult);
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }

                        else if (head is Procedure procedure)
                        {
                            string procedureText = instructionTextExcludeComment[(firstSpaceIndex + 1)..].Trim();
                            string[] procedureTexts = procedureText.Split(',').Select(p => p.Trim()).ToArray();

                            if (procedureTexts.Length == 1) // PRCD + ...
                            {
                                string procedureName = procedureTexts[0];

                                if (procedureName.Equals(PROCEDURE_END_KEYWORD)) // PRCD END
                                {
                                    AddressManager.AddInstruction(OpcodeType.RET);
                                }
                                else // PRCD + Procedure Name
                                {
                                    if (parseType == ParseType.Pre)
                                    {
                                        if (AddressManager.IsExistProcedure(procedureName))
                                        {
                                            throw new AlreadyExistException(procedureName);
                                        }

                                        procedure.Name = procedureName;

                                        AddressManager.AddProcedure(procedure);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message + ", line:" + lineNumber);
            }

            return (AddressManager.Instructions, AddressManager.Variables);
        }

        /// <summary>
        /// Parse Head Section
        /// i) Opcode
        ///     -ADD, MUL, RET, INC, PUSH, POP, MOV, ...
        /// ii) Data Type
        ///     -BYTE, WORD, DWORD, QWORD
        /// iii) Site
        ///     -LOCATION1:, GOOD:, TRUE:, ...
        /// iv) Procedure
        ///     -PRCD sum
        ///         ...
        ///         ...
        ///      PRCD END
        /// </summary>
        /// <param name="headText"></param>
        /// <returns></returns>
        static object ParseHead(string headText)
        {
            // iii) Site
            if (headText.Contains(SITE_TOKEN))
            {
                return new Site(headText.Replace(SITE_TOKEN, ""));
            }

            // iv) Procedure
            if (headText.Equals(PROCEDURE_KEYWORD))
            {
                return new Procedure();
            }

            // i) Opcode
            if (Enum.TryParse(typeof(OpcodeType), headText, out object? result))
            {
                if (result == null)
                {
                    throw new NotParsedException(nameof(result)); 
                }

                return result;
            }

            // ii) Data Type
            if (Enum.TryParse(typeof(DataType), headText, out result))
            {
                if (result == null)
                {
                    throw new NotParsedException(nameof(result));
                }

                return result;
            }

            return new NotParsedException(nameof(headText));
        }

        /// <summary>
        /// Parse Operand
        /// i) Register-X Type
        ///     -R8, R16, R32, R64
        /// ii) Pointer-X Type
        ///     -PTR8, PTR16, PTR32, PTR64
        /// iii) Constant Pointer Type
        ///     -PTRC
        /// iv) Segment Type
        ///     -S
        /// v) Variable Type
        ///     -num1, num2, ...
        /// vi) Constant Value Type
        ///     -11, 12, 13, 14, ...
        /// vii) Site Type
        ///     -LOCATION1:, GOOD:, TRUE:, ...
        /// viii) Procedure Type
        ///     -PRCD sum
        ///         ...
        ///         ...
        ///      PRCD END
        /// *) Special Case
        /// </summary>
        /// <param name="operandText"></param>
        /// <returns></returns>
        static object? ParseOperand(string operandText, ParseType parseType, object? preArgument = null, OpcodeType opcode = OpcodeType.RET)
        {
            string[] operandTexts = operandText.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

            if (operandTexts.Length == 1) // not PTR operand
            {
                // 175, 0x1034, ...
                if (operandTexts[0].IsHexaDecimalString())
                {
                    // *) Special Case
                    switch (opcode)
                    {
                        case OpcodeType.IN:
                        case OpcodeType.OUT:
                        case OpcodeType.RCL:
                        case OpcodeType.RCR:
                        case OpcodeType.ROL:
                        case OpcodeType.ROR:
                        case OpcodeType.SHL:
                        case OpcodeType.SHR:
                            return ConvertToByte(operandTexts[0]);

                        default:
                            break;
                    }

                    // vi) Constant Value Type
                    if (preArgument is PTRC ptrc)
                    {
                        switch (ptrc.DataType)
                        {
                            case DataType.BYTE:
                                return ConvertToByte(operandTexts[0]);

                            case DataType.WORD:
                                return ConvertToWord(operandTexts[0]);

                            case DataType.DWORD:
                                return ConvertToDword(operandTexts[0]);

                            case DataType.QWORD:
                                return ConvertToQword(operandTexts[0]);

                            default:
                                break;
                        }
                    }

                    if (preArgument is PTR8 || preArgument is R8)
                    {
                        return ConvertToByte(operandTexts[0]);
                    }
                    if (preArgument is PTR16 || preArgument is R16)
                    {
                        return ConvertToWord(operandTexts[0]);
                    }
                    if (preArgument is PTR32 || preArgument is R32)
                    {
                        return ConvertToDword(operandTexts[0]);
                    }
                    if (preArgument is PTR64 || preArgument is R64)
                    {
                        return ConvertToQword(operandTexts[0]);
                    }

                    if (preArgument is OpcodeType opcodeType)
                    {
                        switch (opcodeType)
                        {
                            case OpcodeType.PUSH:
                            case OpcodeType.JO:
                            case OpcodeType.JNO:
                            case OpcodeType.JB:
                            case OpcodeType.JAE:
                            case OpcodeType.JE:
                            case OpcodeType.JNE:
                            case OpcodeType.JBE:
                            case OpcodeType.JA:
                            case OpcodeType.JS:
                            case OpcodeType.JNS:
                            case OpcodeType.JP:
                            case OpcodeType.JNP:
                            case OpcodeType.JL:
                            case OpcodeType.JGE:
                            case OpcodeType.JLE:
                            case OpcodeType.JG:
                            case OpcodeType.INT:
                            case OpcodeType.AAM:
                            case OpcodeType.AAD:
                            case OpcodeType.LOOPNE:
                            case OpcodeType.LOOPE:
                            case OpcodeType.LOOP:
                            case OpcodeType.JECXZ:
                            case OpcodeType.JMP:
                                return ConvertToByte(operandTexts[0]);

                            default:
                                break;
                        }
                    }
                }
                else
                {
                    // i) Register-X Type
                    if (Enum.TryParse(typeof(R8), operandTexts[0], out object? result))
                    {
                        if(result == null)
                        {
                            throw new NotParsedException(nameof(result));
                        }
                        return result;
                    }

                    if (Enum.TryParse(typeof(R16), operandTexts[0], out result))
                    {
                        if (result == null)
                        {
                            throw new NotParsedException(nameof(result));
                        }
                        return result;
                    }

                    if (Enum.TryParse(typeof(R32), operandTexts[0], out result))
                    {
                        if (result == null)
                        {
                            throw new NotParsedException(nameof(result));
                        }
                        return result;
                    }

                    if (Enum.TryParse(typeof(R64), operandTexts[0], out result))
                    {
                        if (result == null)
                        {
                            throw new NotParsedException(nameof(result));
                        }
                        return result;
                    }

                    // iv) Segment Type
                    if (Enum.TryParse(typeof(S), operandTexts[0], out result))
                    {
                        if (result == null)
                        {
                            throw new NotParsedException(nameof(result));
                        }
                        return result;
                    }

                    // v) Variable Type
                    if (AddressManager.TryGetVariable(operandTexts[0], out Variable? variable))
                    {
                        if (variable == null)
                        {
                            throw new NotParsedException(nameof(variable));
                        }
                        return new PTRC(variable.DataType, variable.Address);
                    }

                    // vii) Site Type
                    // viii) Procedure Type
                    switch (parseType)
                    {
                        case ParseType.Pre:
                            return opcode switch
                            {
                                // site caller in pre-parse
                                OpcodeType.JO or OpcodeType.JNO or OpcodeType.JB or OpcodeType.JAE or
                                OpcodeType.JE or OpcodeType.JNE or OpcodeType.JBE or OpcodeType.JA or
                                OpcodeType.JS or OpcodeType.JNS or OpcodeType.JP or OpcodeType.JNP or
                                OpcodeType.JL or OpcodeType.JGE or OpcodeType.JLE or OpcodeType.JG or
                                OpcodeType.JECXZ or OpcodeType.JMP => new Site(operandTexts[0], 0),

                                // procedure caller in pre-parse
                                OpcodeType.CALL => new Procedure(operandTexts[0], 0),

                                _ => throw new NotExistException(operandTexts[0])
                            };
                        case ParseType.Real:
                            {
                                // site caller in real-parse
                                if (AddressManager.TryGetSite(operandTexts[0], out Site? site))
                                {
                                    if (site == null)
                                    {
                                        throw new NotParsedException(nameof(site));
                                    }
                                    return site;
                                }
                                // procedure caller in real-parse
                                else if (AddressManager.TryGetProcedure(operandTexts[0], out Procedure? procedure))
                                {
                                    if (procedure == null)
                                    {
                                        throw new NotParsedException(nameof(procedure));
                                    }
                                    return procedure;
                                }
                                else
                                {
                                    throw new NotExistException(operandTexts[0]);
                                }
                            }
                    }
                }
            }
            else if (operandTexts.Length == 2) // PTR operand
            {
                // Remove 'PTR' Keyword
                operandTexts[0] = operandTexts[0].Replace("PTR", "").Trim();

                // iii) Constant Pointer Type
                if (operandTexts[1][0] >= '0' && operandTexts[1][0] <= '9')
                {
                    var dataType = (DataType)Enum.Parse(typeof(DataType), operandTexts[0]);
                    return new PTRC(dataType, operandTexts[1].ToUInt(true));
                }
                // ii) Pointer-X Type
                else
                {
                    try
                    {
                        return operandTexts[0] switch
                        {
                            "BYTE" => Enum.Parse(typeof(PTR8), operandTexts[1]),
                            "WORD" => Enum.Parse(typeof(PTR16), operandTexts[1]),
                            "DWORD" => Enum.Parse(typeof(PTR32), operandTexts[1]),
                            "FWORD" => Enum.Parse(typeof(PTR48), operandTexts[1]),
                            "QWORD" => Enum.Parse(typeof(PTR64), operandTexts[1]),
                            _ => null,
                        };
                    }
                    catch
                    {
                        return null;
                    }
                }
            }

            return null;
        }

        static byte ConvertToByte(string numericString)
        {
            byte result;

            if (numericString.StartsWith("0X"))
            {
                result = Convert.ToByte(numericString, 16);
            }
            else if (numericString.EndsWith("H"))
            {
                result = Convert.ToByte(numericString.Replace("H", ""), 16);
            }
            else if (!byte.TryParse(numericString, out result))
            {
                throw new OverflowException(numericString);
            }

            return result;
        }

        static ushort ConvertToWord(string numericString)
        {
            ushort result;

            if (numericString.StartsWith("0X"))
            {
                result = Convert.ToUInt16(numericString, 16);
            }
            else if (numericString.EndsWith("H"))
            {
                result = Convert.ToUInt16(numericString.Replace("H", ""), 16);
            }
            else if (!ushort.TryParse(numericString, out result))
            {
                throw new OverflowException(numericString);
            }
            return result;
        }

        static uint ConvertToDword(string numericString)
        {
            uint result;

            if (numericString.StartsWith("0X"))
            {
                result = Convert.ToUInt32(numericString, 16);
            }
            else if (numericString.EndsWith("H"))
            {
                result = Convert.ToUInt32(numericString.Replace("H", ""), 16);
            }
            else if (!uint.TryParse(numericString, out result))
            {
                throw new OverflowException(numericString);
            }
            return result;
        }

        static ulong ConvertToQword(string numericString)
        {
            ulong result;

            if (numericString.StartsWith("0X"))
            {
                result = Convert.ToUInt64(numericString, 16);
            }
            else if (numericString.EndsWith("H"))
            {
                result = Convert.ToUInt64(numericString.Replace("H", ""), 16);
            }
            else if (!ulong.TryParse(numericString, out result))
            {
                throw new OverflowException(numericString);
            }
            return result;
        }
    }
}
