namespace Gaten.Net.Windows.PE.Disassembly
{
    public class Instruction
    {
        public uint Address { get; set; }
        public byte[] Bytes { get; set; }
        public string Disassembly { get; set; }

        public Instruction(uint address, byte[] bytes, string disassembly)
        {
            Address = address;
            Bytes = bytes;
            Disassembly = disassembly;
        }
    }
}
