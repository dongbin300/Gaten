namespace Gaten.Net.Windows.PE.PEFileFormat
{
    public class IMAGE_IMPORT_DESCRIPTOR
    {
        public uint Characteristics { get; set; }
        public uint OriginalFirstThunk { get; set; }
        public uint TimeDateStamp { get; set; }
        public uint ForwarderChain { get; set; }
        public uint Name { get; set; }
        public uint FirstThunk { get; set; }
    }
}
