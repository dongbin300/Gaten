namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _C6
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "05":
                    DisassemblyHelper.SetDisassemblyString("MOV BYTE PTR DS:[{0}], {1}", DisassemblyHelper.OperandType.LE32, DisassemblyHelper.OperandType.LE8);
                    break;

                default:
                    break;
            }
        }
    }
}
