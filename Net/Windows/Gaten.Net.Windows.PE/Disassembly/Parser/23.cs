namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _23
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "C8":
                    DisassemblyHelper.SetDisassemblyString("AND ECX, EAX");
                    break;

                default:
                    break;
            }
        }
    }
}
