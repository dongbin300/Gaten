namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _C7
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "05":
                    DisassemblyHelper.SetDisassemblyString("MOV DWORD PTR DS:[{0}], {1}", DisassemblyHelper.OperandType.LE32, DisassemblyHelper.OperandType.LE32);
                    break;

                case "45":
                    DisassemblyHelper.SetDisassemblyString("MOV DWORD PTR SS:[EBP{0}], {1}", DisassemblyHelper.OperandType.SH8, DisassemblyHelper.OperandType.LE32);
                    break;

                case "85":
                    DisassemblyHelper.SetDisassemblyString("MOV DWORD PTR SS:[EBP{0}], {1}", DisassemblyHelper.OperandType.SH32, DisassemblyHelper.OperandType.LE32);
                    break;

                default:
                    break;
            }
        }
    }
}
