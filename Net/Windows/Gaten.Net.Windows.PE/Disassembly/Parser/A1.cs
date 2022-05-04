namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _A1
    {
        public static void Parse()
        {
            DisassemblyHelper.SetDisassemblyString("MOV EAX, DWORD PTR DS:[{0}]", DisassemblyHelper.OperandType.LE32);
        }
    }
}
