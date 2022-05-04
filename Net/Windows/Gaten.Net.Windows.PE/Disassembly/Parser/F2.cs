namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _F2
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "72":
                    DisassemblyHelper.SetDisassemblyString("BND JB [{0}]", DisassemblyHelper.OperandType.J8);
                    break;

                case "75":
                    DisassemblyHelper.SetDisassemblyString("BND JNE [{0}]", DisassemblyHelper.OperandType.J8);
                    break;

                case "C3":
                    DisassemblyHelper.SetDisassemblyString("BND RET");
                    break;

                case "E9":
                    DisassemblyHelper.SetDisassemblyString("BND JMP [{0}]", DisassemblyHelper.OperandType.J32);
                    break;

                default:
                    break;
            }
        }
    }
}
