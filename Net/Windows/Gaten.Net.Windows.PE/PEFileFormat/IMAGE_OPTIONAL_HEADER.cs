using Gaten.Net.Serialization;
using Gaten.Net.Windows.PE.Build;

namespace Gaten.Net.Windows.PE.PEFileFormat
{
    public enum WindowsSubsystem : ushort
    {
        IMAGE_SUBSYSTEM_UNKNOWN = 0x0000,
        IMAGE_SUBSYSTEM_NATIVE = 0x0001,
        IMAGE_SUBSYSTEM_WINDOWS_GUI = 0x0002,
        IMAGE_SUBSYSTEM_WINDOWS_CUI = 0x0003,
        IMAGE_SUBSYSTEM_OS2_CUI = 0x0005,
        IMAGE_SUBSYSTEM_POSIX_CUI = 0x0007,
        IMAGE_SUBSYSTEM_NATIVE_WINDOWS = 0x0008,
        IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 0x0009,
        IMAGE_SUBSYSTEM_EFI_APPLICATION = 0x000A,
        IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 0x000B,
        IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER = 0x000C,
        IMAGE_SUBSYSTEM_EFI_ROM = 0x000D,
        IMAGE_SUBSYSTEM_XBOX = 0x000E,
        IMAGE_SUBSYSTEM_WINDOWS_BOOT_APPLICATION = 0x0010
    }

    [Flags]
    public enum DLLCharacteristics : ushort
    {
        IMAGE_DLLCHARACTERISTICS_HIGH_ENTROPY_VA = 0x0020,
        IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE = 0x0040,
        IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY = 0x0080,
        IMAGE_DLLCHARACTERISTICS_NX_COMPAT = 0x0100,
        IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 0x0200,
        IMAGE_DLLCHARACTERISTICS_NO_SEH = 0x0400,
        IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x0800,
        IMAGE_DLLCHARACTERISTICS_APPCONTAINER = 0x1000,
        IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000,
        IMAGE_DLLCHARACTERISTICS_GUARD_CF = 0x4000,
        IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000,
    }

    public class IMAGE_OPTIONAL_HEADER
    {
        /* Standard fields */
        public Build.PEFormat Magic { get; set; }
        public ushort MagicValue => (ushort)Magic;
        public byte MajorLinkerVersion { get; set; }
        public byte MinorLinkerVersion { get; set; }
        public uint SizeOfCode { get; set; }
        public uint SizeOfInitializedData { get; set; }
        public uint SizeOfUninitializedData { get; set; }
        public uint AddressOfEntryPoint { get; set; }
        public uint BaseOfCode { get; set; }
        public uint BaseOfData { get; set; } // PE32 only included

        /* Windows-specific fields */
        public uint ImageBase { get; set; }
        public ulong ImageBase64 { get; set; }
        public uint SectionAlignment { get; set; }
        public uint FileAlignment { get; set; }
        public ushort MajorOSVersion { get; set; }
        public ushort MinorOSVersion { get; set; }
        public ushort MajorImageVersion { get; set; }
        public ushort MinorImageVersion { get; set; }
        public ushort MajorSubsystemVersion { get; set; }
        public ushort MinorSubsystemVersion { get; set; }
        public uint Win32VersionValue { get; set; }
        public uint SizeOfImage { get; set; }
        public uint SizeOfHeaders { get; set; }
        public uint Checksum { get; set; }
        public WindowsSubsystem Subsystem { get; set; }
        public ushort SubsystemValue => (ushort)Subsystem;
        public DLLCharacteristics _DLLCharacteristics { get; set; }
        public ushort DLLCharacteristicsValue => (ushort)_DLLCharacteristics;
        public uint SizeOfStackReserve { get; set; }
        public ulong SizeOfStackReserve64 { get; set; }
        public uint SizeOfStackCommit { get; set; }
        public ulong SizeOfStackCommit64 { get; set; }
        public uint SizeOfHeapReserve { get; set; }
        public ulong SizeOfHeapReserve64 { get; set; }
        public uint SizeOfHeapCommit { get; set; }
        public ulong SizeOfHeapCommit64 { get; set; }
        public uint LoaderFlags { get; set; }
        public uint NumberOfDataDirectories { get; set; }
        public List<IMAGE_DATA_DIRECTORY> DataDirectories { get; set; }
        public byte[] Bytes => ToBytes();

        public IMAGE_OPTIONAL_HEADER(PEFormat magic, byte majorLinkerVersion, byte minorLinkerVersion, uint sizeOfCode, uint sizeOfInitializedData, uint sizeOfUninitializedData, uint addressOfEntryPoint, uint baseOfCode, uint baseOfData, uint imageBase, uint sectionAlignment, uint fileAlignment, ushort majorOsVersion, ushort minorOsVersion, ushort majorImageVersion, ushort minorImageVersion, ushort majorSubsystemVersion, ushort minorSubsystemVersion, uint win32VersionValue, uint sizeOfImage, uint sizeOfHeaders, uint checksum, WindowsSubsystem subsystem, DLLCharacteristics dllCharacteristics, uint sizeOfStackReserve, uint sizeOfStackCommit, uint sizeOfHeapReserve, uint sizeOfHeapCommit, uint loaderFlags, uint numberOfDataDirectories, List<IMAGE_DATA_DIRECTORY> dataDirectories)
        {
            Magic = magic;
            MajorLinkerVersion = majorLinkerVersion;
            MinorLinkerVersion = minorLinkerVersion;
            SizeOfCode = sizeOfCode;
            SizeOfInitializedData = sizeOfInitializedData;
            SizeOfUninitializedData = sizeOfUninitializedData;
            AddressOfEntryPoint = addressOfEntryPoint;
            BaseOfCode = baseOfCode;
            SectionAlignment = sectionAlignment;
            FileAlignment = fileAlignment;
            MajorOSVersion = majorOsVersion;
            MinorOSVersion = minorOsVersion;
            MajorImageVersion = majorImageVersion;
            MinorImageVersion = minorImageVersion;
            MajorSubsystemVersion = majorSubsystemVersion;
            MinorSubsystemVersion = minorSubsystemVersion;
            Win32VersionValue = win32VersionValue;
            SizeOfImage = sizeOfImage;
            SizeOfHeaders = sizeOfHeaders;
            Checksum = checksum;
            Subsystem = subsystem;
            _DLLCharacteristics = dllCharacteristics;
            LoaderFlags = loaderFlags;
            NumberOfDataDirectories = numberOfDataDirectories;
            DataDirectories = dataDirectories;

            if (Magic == PEFormat.PE32)
            {
                BaseOfData = baseOfData;
                ImageBase = imageBase;
                SizeOfStackReserve = sizeOfStackReserve;
                SizeOfStackCommit = sizeOfStackCommit;
                SizeOfHeapReserve = sizeOfHeapReserve;
                SizeOfHeapCommit = sizeOfHeapCommit;
            }
            else if (Magic == PEFormat.PE32PLUS)
            {
                BaseOfData = 0;
                ImageBase64 = imageBase;
                SizeOfStackReserve64 = sizeOfStackReserve;
                SizeOfStackCommit64 = sizeOfStackCommit;
                SizeOfHeapReserve64 = sizeOfHeapReserve;
                SizeOfHeapCommit64 = sizeOfHeapCommit;
            }

            //Magic = BuildEnvironment.Format;
            //MajorLinkerVersion = 0x0E;
            ////MajorLinkerVersion = 0x05;
            //MinorLinkerVersion = 0x1C;
            ////MinorLinkerVersion = 0x0C;
            //SizeOfCode = 0x00005A00;
            ////SizeOfCode = AddressManager.TextSectionRawSize;
            //SizeOfInitializedData = 0x00004600;
            ////SizeOfInitializedData = AddressManager.DataSectionRawSize;
            //SizeOfUninitializedData = 0x00000000;
            //AddressOfEntryPoint = AddressManager.EntryPointAddress;
            //BaseOfCode = 0x00001000;
            ////BaseOfCode = AddressManager.TextSectionRVA;
            //SectionAlignment = AddressManager.SectionAlignment;
            //FileAlignment = AddressManager.FileAlignment;
            //MajorOSVersion = 0x0006;
            ////MajorOSVersion = 0x0004;
            //MinorOSVersion = 0x0000;
            //MajorImageVersion = 0x0000;
            //MinorImageVersion = 0x0000;
            //MajorSubsystemVersion = 0x0006;
            ////MajorSubsystemVersion = 0x0004;
            //MinorSubsystemVersion = 0x0000;
            //Win32VersionValue = 0x00000000;
            //SizeOfImage = AddressManager.ImageSize;
            //SizeOfHeaders = 0x00000400;
            ////SizeOfHeaders = 0x00000200;
            //Checksum = 0x00000000;
            //Subsystem = WindowsSubsystem.IMAGE_SUBSYSTEM_WINDOWS_CUI;
            //_DLLCharacteristics = DLLCharacteristics.IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE | DLLCharacteristics.IMAGE_DLLCHARACTERISTICS_NX_COMPAT | DLLCharacteristics.IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE;
            //LoaderFlags = 0x00000000;
            //NumberOfDataDirectories = 0x00000010;

            //DataDirectories = new List<IMAGE_DATA_DIRECTORY>();
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x0001B1C8, 0x00000050));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x0001E000, 0x0000043C));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x0001F000, 0x000003AC));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x000184F4, 0x00000038));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00018530, 0x00000040));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x0001B000, 0x000001C8));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            //DataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));

            //if (Magic == BuildEnvironment.PEFormat.PE32)
            //{
            //    BaseOfData = 0x00001000;
            //    //BaseOfData = AddressManager.DataSectionRVA;
            //    ImageBase = AddressManager.ImageBaseAddress;
            //    SizeOfStackReserve = 0x00100000;
            //    SizeOfStackCommit = 0x00001000;
            //    SizeOfHeapReserve = 0x00100000;
            //    SizeOfHeapCommit = 0x00001000;
            //}
            //else if (Magic == BuildEnvironment.PEFormat.PE32PLUS)
            //{
            //    BaseOfData = 0;
            //    ImageBase64 = AddressManager.ImageBase64Address;
            //    SizeOfStackReserve64 = 0x0000000000100000;
            //    SizeOfStackCommit64 = 0x0000000000001000;
            //    SizeOfHeapReserve64 = 0x0000000000100000;
            //    SizeOfHeapCommit64 = 0x0000000000001000;
            //}
        }

        private byte[] ToBytes()
        {
            Serializer serializer = new Serializer();
            serializer.Add(MagicValue);
            serializer.Add(MajorLinkerVersion);
            serializer.Add(MinorLinkerVersion);
            serializer.Add(SizeOfCode);
            serializer.Add(SizeOfInitializedData);
            serializer.Add(SizeOfUninitializedData);
            serializer.Add(AddressOfEntryPoint);
            serializer.Add(BaseOfCode);
            if (Magic == PEFormat.PE32)
            {
                serializer.Add(BaseOfData);
                serializer.Add(ImageBase);
            }
            else if (Magic == PEFormat.PE32PLUS)
            {
                serializer.Add(ImageBase64);
            }
            serializer.Add(SectionAlignment);
            serializer.Add(FileAlignment);
            serializer.Add(MajorOSVersion);
            serializer.Add(MinorOSVersion);
            serializer.Add(MajorImageVersion);
            serializer.Add(MinorImageVersion);
            serializer.Add(MajorSubsystemVersion);
            serializer.Add(MinorSubsystemVersion);
            serializer.Add(Win32VersionValue);
            serializer.Add(SizeOfImage);
            serializer.Add(SizeOfHeaders);
            serializer.Add(Checksum);
            serializer.Add(SubsystemValue);
            serializer.Add(DLLCharacteristicsValue);
            if (Magic == PEFormat.PE32)
            {
                serializer.Add(SizeOfStackReserve);
                serializer.Add(SizeOfStackCommit);
                serializer.Add(SizeOfHeapReserve);
                serializer.Add(SizeOfHeapCommit);
            }
            else if (Magic == PEFormat.PE32PLUS)
            {
                serializer.Add(SizeOfStackReserve64);
                serializer.Add(SizeOfStackCommit64);
                serializer.Add(SizeOfHeapReserve64);
                serializer.Add(SizeOfHeapCommit64);
            }
            serializer.Add(LoaderFlags);
            serializer.Add(NumberOfDataDirectories);
            foreach (IMAGE_DATA_DIRECTORY dir in DataDirectories)
            {
                serializer.Add(dir.VirtualAddress);
                serializer.Add(dir.Size);
            }

            return serializer.ToBytes();
        }
    }
}
