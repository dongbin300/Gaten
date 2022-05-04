namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _65
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "78":
                    DisassemblyHelper.SetDisassemblyString("JS [{0}]", DisassemblyHelper.OperandType.J8);
                    break;

                default:
                    break;
            }
        }
    }
}
