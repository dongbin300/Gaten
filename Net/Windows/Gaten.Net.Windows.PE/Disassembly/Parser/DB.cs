namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _DB
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "E2":
                    DisassemblyHelper.SetDisassemblyString("FNCLEX");
                    break;

                default:
                    break;
            }
        }
    }
}
