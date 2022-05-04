using Gaten.Net.Extension;

using System.Reflection;
using System.Text;

namespace Gaten.Net.Windows.PE.Disassembly
{
    public class DisassemblyHelper
    {
        /// <summary>
        /// Little Endian 8
        /// Little Endian 16
        /// Little Endian 32
        /// Signed Hex
        /// Jump Opcode
        /// </summary>
        public enum OperandType
        {
            None,
            LE8,
            LE16,
            LE32,
            SH8,
            SH16,
            SH32,
            J8,
            J16,
            J32
        }

        public static byte[] Data { get; set; } = Array.Empty<byte>();
        public static int Interval { get; set; } = 0;
        public static int Index { get; set; } = 0;
        public static byte[]? Opcode1 { get; set; } = null;
        public static byte[]? Opcode2 { get; set; } = null;
        public static byte[]? Opcode3 { get; set; } = null;
        public static byte[]? Opcode4 { get; set; } = null;
        public static byte[]? Operand1 { get; set; } = null;
        public static byte[]? Operand2 { get; set; } = null;
        public static byte[]? Operand3 { get; set; } = null;
        public static byte[]? Operand4 { get; set; } = null;
        public static StringBuilder Disassembly { get; set; } = new();
        public static uint CurrentAddress { get; set; } = 0;

        public static int Success { get; set; } = 0;
        public static int Fail { get; set; } = 0;

        public static string? Opcode1HexString => Opcode1?.ToHexString();
        public static string? Opcode2HexString => Opcode2?.ToHexString();
        public static string? Opcode3HexString => Opcode3?.ToHexString();
        public static string? Opcode4HexString => Opcode4?.ToHexString();

        public static List<Instruction> MakeInstructionTable(PEFileDisassembly peFileDisassembly)
        {
            try
            {
                List<Instruction> instructions = new();

                var baseAddress = peFileDisassembly.BaseAddress;
                Data = peFileDisassembly.Data;
                Interval = peFileDisassembly.BassAddressInterval;

                Index = 0;

                while (Index < Data.Length)
                {
                    // initialize
                    Opcode1 = Opcode2 = Opcode3 = Opcode4 = null;
                    Operand1 = Operand2 = Operand3 = Operand4 = null;
                    Disassembly.Clear();

                    CurrentAddress = (uint)(baseAddress + Index);
                    GetOpcode();

                    // parse hex
                    try
                    {
                        Type? t = Type.GetType("Gaten.Net.Windows.PE.Disassembly.Parser._" + Opcode1?.ToHexString());
                        MethodInfo? method = t?.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public);
                        method?.Invoke(null, null);
                    }
                    catch
                    {

                    }

                    if (Opcode1 == null)
                    {
                        throw new NullReferenceException(nameof(Opcode1));
                    }

                    // arrange opcode & operand and make hex bytes
                    byte[] OPCODE =
                        Opcode2 == null ? Opcode1 :
                        Opcode3 == null ? Opcode1.Serialize(Opcode2) :
                        Opcode4 == null ? Opcode1.Serialize(Opcode2, Opcode3) :
                        Opcode1.Serialize(Opcode2, Opcode3, Opcode4);

                    byte[]? OPERAND =
                        Operand1 == null ? null :
                        Operand2 == null ? Operand1 :
                        Operand3 == null ? Operand1.Serialize(Operand2) :
                        Operand4 == null ? Operand1.Serialize(Operand2, Operand3) :
                        Operand1.Serialize(Operand2, Operand3, Operand4);

                    byte[] hexBytes =
                        OPERAND == null ? OPCODE :
                        OPCODE.Serialize(OPERAND);

                    // make instructions
                    instructions.Add(new Instruction(
                        CurrentAddress, hexBytes, Disassembly.ToString().ToLower()
                        ));

                    // check progress
                    if (string.IsNullOrEmpty(Disassembly.ToString()))
                    {
                        Fail++;
                    }
                    else
                    {
                        Success++;
                    }
                }

                return instructions;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public static void GetOpcode()
        {
            if (Opcode1 == null)
            {
                Opcode1 = new byte[] { Data[Index++] };
            }
            else if (Opcode2 == null)
            {
                Opcode2 = new byte[] { Data[Index++] };
            }
            else if (Opcode3 == null)
            {
                Opcode3 = new byte[] { Data[Index++] };
            }
            else if (Opcode4 == null)
            {
                Opcode4 = new byte[] { Data[Index++] };
            }
        }

        public static void GetOperand(int count)
        {
            switch (count)
            {
                case 1:
                    Operand1 = Data.GetBytes(Index, 4);
                    Index += 4;
                    break;
                case 2:
                    Operand1 = Data.GetBytes(Index, 4);
                    Operand2 = Data.GetBytes(Index + 4, 4);
                    Index += 8;
                    break;
                default:
                    break;
            }
        }

        public static void GetOperand16(int count)
        {
            switch (count)
            {
                case 1:
                    Operand1 = Data.GetBytes(Index, 2);
                    Index += 2;
                    break;
                case 2:
                    Operand1 = Data.GetBytes(Index, 2);
                    Operand2 = Data.GetBytes(Index + 2, 2);
                    Index += 4;
                    break;
                default:
                    break;
            }
        }

        public static void GetOperand8(int count)
        {
            switch (count)
            {
                case 1:
                    Operand1 = Data.GetBytes(Index, 1);
                    Index++;
                    break;
                case 2:
                    Operand1 = Data.GetBytes(Index, 1);
                    Operand2 = Data.GetBytes(Index + 1, 1);
                    Index += 2;
                    break;
                default:
                    break;
            }
        }

        public static void SetDisassemblyString(string assembly,
            OperandType operand1Type = OperandType.None,
            OperandType operand2Type = OperandType.None,
            OperandType operand3Type = OperandType.None,
            OperandType operand4Type = OperandType.None)
        {
            if (operand1Type == OperandType.None)
            {
                Disassembly.Append(assembly);
                return;
            }

            GetOperandsFormat(operand1Type, operand2Type, operand3Type, operand4Type);

            if (operand2Type == OperandType.None)
            {
                Disassembly.AppendFormat(assembly, SetOperand(Operand1, operand1Type));
                return;
            }

            if (operand3Type == OperandType.None)
            {
                Disassembly.AppendFormat(assembly, SetOperand(Operand1, operand1Type), SetOperand(Operand2, operand2Type));
                return;
            }

            if (operand4Type == OperandType.None)
            {
                Disassembly.AppendFormat(assembly, SetOperand(Operand1, operand1Type), SetOperand(Operand2, operand2Type), SetOperand(Operand3, operand3Type));
                return;
            }

            Disassembly.AppendFormat(assembly, SetOperand(Operand1, operand1Type), SetOperand(Operand2, operand2Type), SetOperand(Operand3, operand3Type), SetOperand(Operand4, operand4Type));
        }

        /// <summary>
        /// 오퍼랜드 출력
        /// 1. 1바이트 출력(l-e) : 변환없이 바로 Hex String
        /// 2. 2바이트 출력(l-e) : Reverse 후 Hex String
        /// 3. 4바이트 출력(l-e) : Reverse 후 Hex String
        /// 4. SignedHexString 출력 : Util.UnsignedToSignedHexString
        /// </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static string SetOperand(byte[]? operand, OperandType type)
        {
            if (operand == null)
            {
                throw new ArgumentNullException(nameof(operand));
            }

            return type switch
            {
                OperandType.SH8 or OperandType.SH16 or OperandType.SH32 => operand.UnsignedToSignedHexString(),
                OperandType.LE8 => operand.ToHexString(),
                OperandType.LE16 or OperandType.LE32 => operand.ToHexString(true),
                OperandType.J8 => ((byte)(CurrentAddress + operand[0] + GetOpcodeCount() + 1)).ToHexString(true),
                OperandType.J16 => ((ushort)(CurrentAddress + BitConverter.ToUInt32(operand) + GetOpcodeCount() + 2)).ToHexString(true),
                OperandType.J32 => ((uint)(CurrentAddress + BitConverter.ToUInt32(operand) + GetOpcodeCount() + 4)).ToHexString(true),
                _ => string.Empty,
            };
        }

        public static void GetOperand(OperandType type, int operandNumber)
        {
            int byteSize = type switch
            {
                OperandType.LE8 or OperandType.SH8 or OperandType.J8 => 1,
                OperandType.LE16 or OperandType.SH16 or OperandType.J16 => 2,
                OperandType.LE32 or OperandType.SH32 or OperandType.J32 => 4,
                _ => 0,
            };

            var operand = Data.GetBytes(Index, byteSize);
            switch (operandNumber)
            {
                case 1:
                    Operand1 = operand;
                    break;
                case 2:
                    Operand2 = operand;
                    break;
                case 3:
                    Operand3 = operand;
                    break;
                case 4:
                    Operand4 = operand;
                    break;
                default:
                    break;
            }
            Index += byteSize;
        }

        public static void GetOperands(OperandType type, int count = 1)
        {
            switch (type)
            {
                case OperandType.LE8:
                case OperandType.SH8:
                case OperandType.J8:
                    switch (count)
                    {
                        case 1:
                            Operand1 = Data.GetBytes(Index, 1);
                            Index++;
                            break;
                        case 2:
                            Operand1 = Data.GetBytes(Index, 1);
                            Operand2 = Data.GetBytes(Index + 1, 1);
                            Index += 2;
                            break;
                        case 3:
                            Operand1 = Data.GetBytes(Index, 1);
                            Operand2 = Data.GetBytes(Index + 1, 1);
                            Operand3 = Data.GetBytes(Index + 2, 1);
                            Index += 3;
                            break;
                        case 4:
                            Operand1 = Data.GetBytes(Index, 1);
                            Operand2 = Data.GetBytes(Index + 1, 1);
                            Operand3 = Data.GetBytes(Index + 2, 1);
                            Operand4 = Data.GetBytes(Index + 3, 1);
                            Index += 4;
                            break;
                        default:
                            break;
                    }
                    break;

                case OperandType.LE16:
                case OperandType.SH16:
                case OperandType.J16:
                    switch (count)
                    {
                        case 1:
                            Operand1 = Data.GetBytes(Index, 2);
                            Index += 2;
                            break;
                        case 2:
                            Operand1 = Data.GetBytes(Index, 2);
                            Operand2 = Data.GetBytes(Index + 2, 2);
                            Index += 4;
                            break;
                        case 3:
                            Operand1 = Data.GetBytes(Index, 2);
                            Operand2 = Data.GetBytes(Index + 2, 2);
                            Operand3 = Data.GetBytes(Index + 4, 2);
                            Index += 6;
                            break;
                        case 4:
                            Operand1 = Data.GetBytes(Index, 2);
                            Operand2 = Data.GetBytes(Index + 2, 2);
                            Operand3 = Data.GetBytes(Index + 4, 2);
                            Operand4 = Data.GetBytes(Index + 6, 2);
                            Index += 8;
                            break;
                        default:
                            break;
                    }
                    break;

                case OperandType.LE32:
                case OperandType.SH32:
                case OperandType.J32:
                    switch (count)
                    {
                        case 1:
                            Operand1 = Data.GetBytes(Index, 4);
                            Index += 4;
                            break;
                        case 2:
                            Operand1 = Data.GetBytes(Index, 4);
                            Operand2 = Data.GetBytes(Index + 4, 4);
                            Index += 8;
                            break;
                        case 3:
                            Operand1 = Data.GetBytes(Index, 4);
                            Operand2 = Data.GetBytes(Index + 4, 4);
                            Operand3 = Data.GetBytes(Index + 8, 4);
                            Index += 12;
                            break;
                        case 4:
                            Operand1 = Data.GetBytes(Index, 4);
                            Operand2 = Data.GetBytes(Index + 4, 4);
                            Operand3 = Data.GetBytes(Index + 8, 4);
                            Operand4 = Data.GetBytes(Index + 12, 4);
                            Index += 16;
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        public static void GetOperandsFormat(
            OperandType operand1Type = OperandType.None,
            OperandType operand2Type = OperandType.None,
            OperandType operand3Type = OperandType.None,
            OperandType operand4Type = OperandType.None)
        {
            if (operand1Type == OperandType.None)
            {
                return;
            }

            GetOperand(operand1Type, 1);

            if (operand2Type == OperandType.None)
            {
                return;
            }

            GetOperand(operand2Type, 2);

            if (operand3Type == OperandType.None)
            {
                return;
            }

            GetOperand(operand3Type, 3);

            if (operand4Type == OperandType.None)
            {
                return;
            }

            GetOperand(operand4Type, 4);
        }

        public static void GetOperandFormat(int size1 = 0, int size2 = 0, int size3 = 0, int size4 = 0)
        {
            if (size1 != 0)
            {
                Operand1 = Data.GetBytes(Index, size1);
                Index += size1;
            }
            if (size2 != 0)
            {
                Operand2 = Data.GetBytes(Index, size2);
                Index += size2;
            }
            if (size3 != 0)
            {
                Operand3 = Data.GetBytes(Index, size3);
                Index += size3;
            }
            if (size4 != 0)
            {
                Operand4 = Data.GetBytes(Index, size4);
                Index += size4;
            }
        }

        public static int GetOpcodeCount()
        {
            if (Opcode1 == null)
            {
                return 0;
            }
            else if (Opcode2 == null)
            {
                return 1;
            }
            else if (Opcode3 == null)
            {
                return 2;
            }
            else if (Opcode4 == null)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
    }
}
