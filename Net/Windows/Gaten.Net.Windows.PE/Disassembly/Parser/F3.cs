namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _F3
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "AA":
                    DisassemblyHelper.SetDisassemblyString("REP STOSB");
                    break;

                case "AB":
                    DisassemblyHelper.SetDisassemblyString("REP STOSD");
                    break;

                default:
                    break;
            }
        }
    }
}
