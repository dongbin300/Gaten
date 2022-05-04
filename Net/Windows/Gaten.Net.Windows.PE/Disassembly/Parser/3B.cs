namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _3B
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "05":
                    DisassemblyHelper.SetDisassemblyString("CMP EAX, DWORD PTR DS:[{0}]", DisassemblyHelper.OperandType.LE32);
                    break;

                case "0D":
                    DisassemblyHelper.SetDisassemblyString("CMP ECX, DWORD PTR DS:[{0}]", DisassemblyHelper.OperandType.LE32);
                    break;

                case "33":
                    DisassemblyHelper.SetDisassemblyString("CMP ESI, DWORD PTR DS:[EBX]");
                    break;

                case "85":
                    DisassemblyHelper.SetDisassemblyString("CMP EAX, DWORD PTR SS:[EBP{0}]", DisassemblyHelper.OperandType.SH32);
                    break;

                case "C8":
                    DisassemblyHelper.SetDisassemblyString("CMP ECX, EAX");
                    break;

                case "EC":
                    DisassemblyHelper.SetDisassemblyString("CMP EBP, ESP");
                    break;

                case "F4":
                    DisassemblyHelper.SetDisassemblyString("CMP ESI, ESP");
                    break;

                default:
                    break;
            }
        }
    }
}
