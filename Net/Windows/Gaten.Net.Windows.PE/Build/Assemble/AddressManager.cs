using Gaten.Net.Windows.PE.Assembly;
using static Gaten.Net.Windows.PE.Assembly.IAssembly;
using Gaten.Net.Extensions;

namespace Gaten.Net.Windows.PE.Build.Assemble
{
    public class AddressManager
    {
        /* Optional Header */
        public static uint ImageBaseAddress { get; set; } = 0x00400000;
        public static ulong ImageBase64Address { get; set; } = 0x0000000000400000;
        public static uint SectionAlignment { get; set; } = 0x00001000;
        public static uint FileAlignment { get; set; } = 0x00000200;
        public static uint EntryPointAddress { get; set; } = 0x00001023;
        //public static uint EntryPointAddress{ get; set; } = 0x00001000;
        public static uint ImageSize { get; set; } = 0x00020000;
        //public static uint ImageSize { get; set; }= 0x00003000;

        /* Text Section */
        public static uint TextSectionSize { get; set; } // 0x00001000
        public static uint TextSectionRVA { get; set; } // 0x00001000
        public static uint TextSectionRawSize { get; set; } // 0x00000200
        public static uint TextSectionRawPointer { get; set; } // 0x00000200

        /* Data Section */
        public static uint DataSectionSize { get; set; } // 0x00001000
        public static uint DataSectionRVA { get; set; } // 0x00002000
        public static uint DataSectionRawSize { get; set; } // 0x00000200
        public static uint DataSectionRawPointer { get; set; } // 0x00000400

        public static List<Instruction> Instructions { get; set; } = new();
        public static List<Variable> Variables { get; set; } = new();
        public static List<Site> Sites { get; set; } = new();
        public static List<Procedure> Procedures { get; set; } = new();

        public static uint TextSectionCurrentAddress { get; set; }
        public static uint DataSectionCurrentAddress { get; set; }

        /// <summary>
        /// First Initialize without SectionRawSizes in pre-parse
        /// Second Initialize with SectionRawSizes in real parse
        /// </summary>
        /// <param name="textSectionRawSize"></param>
        /// <param name="dataSectionRawSize"></param>
        public static void Initialize(uint textSectionRawSize = 0, uint dataSectionRawSize = 0)
        {
            Instructions = new List<Instruction>();
            Variables = new List<Variable>();

            if(textSectionRawSize == 0 && dataSectionRawSize == 0)
            {
                Sites = new List<Site>();
                Procedures = new List<Procedure>();
            }

            TextSectionSize = 0x00005400;
            //TextSectionSize = 0x00001000;
            DataSectionSize = 0x00004400;
            //DataSectionSize = 0x00001000;
            TextSectionRVA = SectionAlignment;
            DataSectionRVA = 0x00001000;
            //DataSectionRVA = TextSectionRVA + TextSectionSize;
            TextSectionRawSize = 0x00005400;
            //TextSectionRawSize = textSectionRawSize == 0 ? 0x00000200 : textSectionRawSize;
            DataSectionRawSize = 0x00004400;
            //DataSectionRawSize = dataSectionRawSize == 0 ? 0x00000200 : dataSectionRawSize;
            TextSectionRawPointer = 0x00000200;
            DataSectionRawPointer = TextSectionRawPointer + TextSectionRawSize;

            TextSectionCurrentAddress = (BuildEnvironment.Format == PEFormat.PE32 ? ImageBaseAddress : (uint)ImageBase64Address) + TextSectionRVA;
            DataSectionCurrentAddress = (BuildEnvironment.Format == PEFormat.PE32 ? ImageBaseAddress : (uint)ImageBase64Address) + DataSectionRVA;
        }

        public static void AddInstruction(OpcodeType opcode, object? operand1 = null, object? operand2 = null)
        {
            switch (opcode)
            {
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
                case OpcodeType.JECXZ:
                case OpcodeType.JMP:
                    if (operand1 is Site site) // JMP + Site Name
                    {
                        // site caller in pre-parse
                        if(site.Address == 0)
                        {
                            TextSectionCurrentAddress += 2;
                            return;
                        }

                        // site caller in real-parse
                        operand1 = GetJumpValue(site);

                        var instruction1 = new Instruction(opcode, operand1, operand2, TextSectionCurrentAddress);
                        Instructions.Add(instruction1);

                        TextSectionCurrentAddress += (uint)instruction1.MachineCode.Bytes.Length;
                    }
                    break;

                case OpcodeType.CALL:
                    if (operand1 is Procedure procedure) // CALL + Procedure Name
                    {
                        // procedure caller in pre-parse
                        if(procedure.Address == 0)
                        {
                            TextSectionCurrentAddress += 5;
                            return;
                        }

                        // procedure caller in real-parse
                        operand1 = GetCallValue(procedure);

                        var instruction2 = new Instruction(opcode, operand1, operand2, TextSectionCurrentAddress);
                        Instructions.Add(instruction2);

                        TextSectionCurrentAddress += (uint)instruction2.MachineCode.Bytes.Length;
                    }
                    break;

                default:
                    var instruction = new Instruction(opcode, operand1, operand2, TextSectionCurrentAddress);
                    Instructions.Add(instruction);

                    TextSectionCurrentAddress += (uint)instruction.MachineCode.Bytes.Length;
                    break;
            }
        }

        public static void AddVariable(DataType dataType, string name, object value)
        {
            var variable = new Variable(dataType, name, value, DataSectionCurrentAddress);
            
            Variables.Add(variable);

            DataSectionCurrentAddress += dataType switch
            {
                DataType.BYTE => 1,
                DataType.WORD => 2,
                DataType.DWORD => 4,
                DataType.QWORD => 8,
                _ => 0
            };
        }

        public static void AddSite(Site site)
        {
            site.Address = TextSectionCurrentAddress;

            Sites.Add(site);
        }

        public static void AddProcedure(Procedure procedure)
        {
            procedure.Address = TextSectionCurrentAddress;

            Procedures.Add(procedure);

            // Set EntryPoint Address due to entry procedure
            if (procedure.Name.Equals(ENTRY_PROCEDURE_NAME))
            {
                EntryPointAddress = procedure.Address - ImageBaseAddress;
            }
        }

        public static bool IsExistVariable(string variableName) => Variables.Find(v => v.Name.Equals(variableName)) != null;

        public static bool IsExistSite(string siteName) => Sites.Find(s => s.Name.Equals(siteName)) != null;

        public static bool IsExistProcedure(string procedureName) => Procedures.Find(p => p.Name.Equals(procedureName)) != null;

        public static bool TryGetVariable(string variableName, out Variable? variable)
        {
            variable = Variables.Find(v => v.Name.Equals(variableName));

            return variable != null;
        }

        public static bool TryGetSite(string siteName, out Site? site)
        {
            site = Sites.Find(s => s.Name.Equals(siteName));

            return site != null;
        }

        public static bool TryGetProcedure(string procedureName, out Procedure? procedure)
        {
            procedure = Procedures.Find(p => p.Name.Equals(procedureName));

            return procedure != null;
        }

        public static byte GetJumpValue(Site site) => (byte)(site.Address - TextSectionCurrentAddress - 2);

        public static int GetCallValue(Procedure procedure) => (int)(procedure.Address - TextSectionCurrentAddress - 5);

        public static uint GetSectionRawSize(byte[] bytes) => ((uint)bytes.Length).PaddedValue(9);
    }
}
