namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _1B
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "C0":
                    DisassemblyHelper.SetDisassemblyString("SBB EAX, EAX");
                    break;

                default:
                    break;
            }
        }
    }
}
