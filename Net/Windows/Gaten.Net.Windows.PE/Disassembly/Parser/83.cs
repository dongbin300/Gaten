namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _83
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "3D":
                    DisassemblyHelper.SetDisassemblyString("CMP DWORD PTR DS:[{0}], {1}", DisassemblyHelper.OperandType.LE32, DisassemblyHelper.OperandType.LE8);
                    break;

                case "C0":
                    DisassemblyHelper.SetDisassemblyString("ADD EAX, {0}", DisassemblyHelper.OperandType.LE8);
                    break;

                case "C4":
                    DisassemblyHelper.SetDisassemblyString("ADD ESP, {0}", DisassemblyHelper.OperandType.LE8);
                    break;

                case "C7":
                    DisassemblyHelper.SetDisassemblyString("ADD EDI, {0}", DisassemblyHelper.OperandType.LE8);
                    break;

                case "EC":
                    DisassemblyHelper.SetDisassemblyString("SUB ESP, {0}", DisassemblyHelper.OperandType.LE8);
                    break;

                default:
                    break;
            }
        }
    }
}
