namespace Gaten.Net.Windows.PE.PEFileFormat
{
    public class IMAGE_DATA_DIRECTORY
    {
        public uint VirtualAddress { get; set; }
        public uint Size { get; set; }

        public IMAGE_DATA_DIRECTORY(uint virtualAddress, uint size)
        {
            VirtualAddress = virtualAddress;
            Size = size;
        }
    }
}
