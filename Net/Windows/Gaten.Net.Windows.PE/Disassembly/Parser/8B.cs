namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _8B
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "00":
                    DisassemblyHelper.SetDisassemblyString("MOV EAX, DWORD PTR DS:[EAX]");
                    break;

                case "02":
                    DisassemblyHelper.SetDisassemblyString("MOV EAX, DWORD PTR DS:[EDX]");
                    break;

                case "10":
                    DisassemblyHelper.SetDisassemblyString("MOV EDX, DWORD PTR DS:[EAX]");
                    break;

                case "14":
                    DisassemblyHelper.GetOpcode();

                    switch (DisassemblyHelper.Opcode3HexString)
                    {
                        case "39":
                            DisassemblyHelper.SetDisassemblyString("MOV EDX, DWORD PTR DS:[ECX+EDI]");
                            break;

                        default:
                            break;
                    }
                    break;

                case "40":
                    DisassemblyHelper.SetDisassemblyString("MOV EAX, DWORD PTR DS:[EAX{0}]",  DisassemblyHelper.OperandType.SH8);
                    break;

                case "44":
                    DisassemblyHelper.GetOpcode();

                    switch (DisassemblyHelper.Opcode3HexString)
                    {
                        case "39":
                            DisassemblyHelper.SetDisassemblyString("MOV EAX, DWORD PTR DS:[ECX+EDI{0}]",  DisassemblyHelper.OperandType.SH8);
                            break;

                        default:
                            break;
                    }
                    break;

                case "45":
                    DisassemblyHelper.SetDisassemblyString("MOV EAX, DWORD PTR SS:[EBP{0}]",  DisassemblyHelper.OperandType.SH8);
                    break;

                case "46":
                    DisassemblyHelper.SetDisassemblyString("MOV EAX, DWORD PTR DS:[ESI{0}]", DisassemblyHelper.OperandType.SH8);
                    break;

                case "48":
                    DisassemblyHelper.SetDisassemblyString("MOV ECX, DWORD PTR DS:[EAX{0}]", DisassemblyHelper.OperandType.SH8);
                    break;

                case "4B":
                    DisassemblyHelper.SetDisassemblyString("MOV ECX, DWORD PTR DS:[EBX{0}]", DisassemblyHelper.OperandType.SH8);
                    break;

                case "4D":
                    DisassemblyHelper.SetDisassemblyString("MOV ECX, DWORD PTR SS:[EBP{0}]", DisassemblyHelper.OperandType.SH8);
                    break;

                case "55":
                    DisassemblyHelper.SetDisassemblyString("MOV EDX, DWORD PTR SS:[EBP{0}]", DisassemblyHelper.OperandType.SH8);
                    break;

                case "75":
                    DisassemblyHelper.SetDisassemblyString("MOV ESI, DWORD PTR SS:[EBP{0}]", DisassemblyHelper.OperandType.SH8);
                    break;

                case "76":
                    DisassemblyHelper.SetDisassemblyString("MOV ESI, DWORD PTR DS:[ESI{0}]", DisassemblyHelper.OperandType.SH8);
                    break;

                case "85":
                    DisassemblyHelper.SetDisassemblyString("MOV EAX, DWORD PTR SS:[EBP{0}]", DisassemblyHelper.OperandType.SH32);
                    break;

                case "C1":
                    DisassemblyHelper.SetDisassemblyString("MOV EAX, ECX");
                    break;

                case "C4":
                    DisassemblyHelper.SetDisassemblyString("MOV EAX, ESP");
                    break;

                case "C6":
                    DisassemblyHelper.SetDisassemblyString("MOV EAX, ESI");
                    break;

                case "CB":
                    DisassemblyHelper.SetDisassemblyString("MOV ECX, EBX");
                    break;

                case "CD":
                    DisassemblyHelper.SetDisassemblyString("MOV ECX, EBP");
                    break;

                case "DA":
                    DisassemblyHelper.SetDisassemblyString("MOV EBX, EDX");
                    break;

                case "E5":
                    DisassemblyHelper.SetDisassemblyString("MOV ESP, EBP");
                    break;

                case "EC":
                    DisassemblyHelper.SetDisassemblyString("MOV EBP, ESP");
                    break;

                case "F1":
                    DisassemblyHelper.SetDisassemblyString("MOV ESI, ECX");
                    break;

                case "F4":
                    DisassemblyHelper.SetDisassemblyString("MOV ESI, ESP");
                    break;

                case "FE":
                    DisassemblyHelper.SetDisassemblyString("MOV EDI, ESI");
                    break;

                default:
                    break;
            }
        }
    }
}
