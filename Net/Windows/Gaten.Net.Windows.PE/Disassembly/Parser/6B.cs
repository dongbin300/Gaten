namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _6B
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "95":
                    DisassemblyHelper.SetDisassemblyString("IMUL EDX, DWORD PTR SS:[EBP{0}], {1}", DisassemblyHelper.OperandType.SH32, DisassemblyHelper.OperandType.LE8);
                    break;

                case "C8":
                    DisassemblyHelper.SetDisassemblyString("IMUL ECX, EAX, {0}", DisassemblyHelper.OperandType.LE8);
                    break;

                default:
                    break;
            }
        }
    }
}
