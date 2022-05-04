namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _39
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "05":
                    DisassemblyHelper.SetDisassemblyString("CMP DWORD PTR DS:[{0}], EAX", DisassemblyHelper.OperandType.LE32);
                    break;

                case "33":
                    DisassemblyHelper.SetDisassemblyString("CMP DWORD PTR DS:[EBX], ESI");
                    break;

                default:
                    break;
            }
        }
    }
}
