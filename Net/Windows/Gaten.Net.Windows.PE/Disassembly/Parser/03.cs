namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _03
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "C2":
                    DisassemblyHelper.SetDisassemblyString("ADD EAX, EDX");
                    break;

                case "CA":
                    DisassemblyHelper.SetDisassemblyString("ADD ECX, EDX");
                    break;

                case "D1":
                    DisassemblyHelper.SetDisassemblyString("ADD EDX, ECX");
                    break;

                default:
                    break;
            }
        }
    }
}
