namespace Gaten.Net.Windows.PE.PEFileFormat
{
    public class IMAGE_EXPORT_DIRECTORY
    {
        public uint Characteristics { get; set; }
        public uint TimeDateStamp { get; set; }
        public ushort MajorVersion { get; set; }
        public ushort MinorVersion { get; set; }
        public uint Name { get; set; }
        public uint Base { get; set; }
        public uint NumberOfFunctions { get; set; }
        public uint NumberOfNames { get; set; }
        public uint AddressOfFunctions { get; set; }
        public uint AddressOfNames { get; set; }
        public uint AddressOfNameOrdinals { get; set; }
    }
}
