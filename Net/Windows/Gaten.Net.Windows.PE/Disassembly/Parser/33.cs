namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _33
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "C0":
                    DisassemblyHelper.SetDisassemblyString("XOR EAX, EAX");
                    break;

                case "C5":
                    DisassemblyHelper.SetDisassemblyString("XOR EAX, EBP");
                    break;

                case "CD":
                    DisassemblyHelper.SetDisassemblyString("XOR ECX, EBP");
                    break;

                case "F6":
                    DisassemblyHelper.SetDisassemblyString("XOR ESI, ESI");
                    break;

                case "FF":
                    DisassemblyHelper.SetDisassemblyString("XOR EDI, EDI");
                    break;

                default:
                    break;
            }
        }
    }
}
