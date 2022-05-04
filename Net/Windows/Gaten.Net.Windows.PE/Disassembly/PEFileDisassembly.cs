namespace Gaten.Net.Windows.PE.Disassembly
{
    public class PEFileDisassembly
    {
        public uint BaseAddress { get; set; }
        public int BassAddressInterval { get; set; }
        public byte[] Data { get; set; }

        public PEFileDisassembly()
        {
            Data = Array.Empty<byte>();
        }
    }
}
