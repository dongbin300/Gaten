namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _F7
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "D0":
                    DisassemblyHelper.SetDisassemblyString("NOT EAX");
                    break;

                default:
                    break;
            }
        }
    }
}
