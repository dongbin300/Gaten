namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _69
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "85":
                    DisassemblyHelper.SetDisassemblyString("IMUL EAX, DWORD PTR SS:[EBP{0}], {1}", DisassemblyHelper.OperandType.SH32, DisassemblyHelper.OperandType.LE32);
                    break;

                case "8D":
                    DisassemblyHelper.SetDisassemblyString("IMUL ECX, DWORD PTR SS:[EBP{0}], {1}", DisassemblyHelper.OperandType.SH32, DisassemblyHelper.OperandType.LE32);
                    break;

                default:
                    break;
            }
        }
    }
}
