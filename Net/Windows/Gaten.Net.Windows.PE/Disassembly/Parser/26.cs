namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _26
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "1C":
                    DisassemblyHelper.SetDisassemblyString("SBB AL, {0}", DisassemblyHelper.OperandType.LE8);
                    break;

                default:
                    break;
            }
        }
    }
}
