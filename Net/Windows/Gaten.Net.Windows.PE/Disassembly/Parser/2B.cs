namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _2B
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "C8":
                    DisassemblyHelper.SetDisassemblyString("SUB ECX, EAX");
                    break;

                default:
                    break;
            }
        }
    }
}
