
using Gaten.Net.Serialization;
using Gaten.Net.Extensions;

namespace Gaten.Net.Windows.PE.PEFileFormat
{
    [Flags]
    public enum SectionFlags : uint
    {
        IMAGE_SCN_TYPE_NO_PAD = 0x00000008,
        IMAGE_SCN_CNT_CODE = 0x00000020,
        IMAGE_SCN_CNT_INITIALIZED_DATA = 0x00000040,
        IMAGE_SCN_CNT_UNINITIALIZED_DATA = 0x00000080,
        IMAGE_SCN_LNK_OTHER = 0x00000100,
        IMAGE_SCN_LNK_INFO = 0x00000200,
        IMAGE_SCN_LNK_REMOVE = 0x00000800,
        IMAGE_SCN_LNK_COMDAT = 0x00001000,
        IMAGE_SCN_GPREL = 0x00008000,
        IMAGE_SCN_MEM_PURGEABLE = 0x00020000,
        IMAGE_SCN_MEM_16BIT = 0x00020000,
        IMAGE_SCN_MEM_LOCKED = 0x00040000,
        IMAGE_SCN_MEM_PRELOAD = 0x00080000,
        IMAGE_SCN_ALIGN_1BYTES = 0x00100000,
        IMAGE_SCN_ALIGN_2BYTES = 0x00200000,
        IMAGE_SCN_ALIGN_4BYTES = 0x00300000,
        IMAGE_SCN_ALIGN_8BYTES = 0x00400000,
        IMAGE_SCN_ALIGN_16BYTES = 0x00500000,
        IMAGE_SCN_ALIGN_32BYTES = 0x00600000,
        IMAGE_SCN_ALIGN_64BYTES = 0x00700000,
        IMAGE_SCN_ALIGN_128BYTES = 0x00800000,
        IMAGE_SCN_ALIGN_256BYTES = 0x00900000,
        IMAGE_SCN_ALIGN_512BYTES = 0x00A00000,
        IMAGE_SCN_ALIGN_1024BYTES = 0x00B00000,
        IMAGE_SCN_ALIGN_2048BYTES = 0x00C00000,
        IMAGE_SCN_ALIGN_4096BYTES = 0x00D00000,
        IMAGE_SCN_ALIGN_8192BYTES = 0x00E00000,
        IMAGE_SCN_LNK_NRELOC_OVFL = 0x01000000,
        IMAGE_SCN_MEM_DISCARDABLE = 0x02000000,
        IMAGE_SCN_MEM_NOT_CACHED = 0x04000000,
        IMAGE_SCN_MEM_NOT_PAGED = 0x08000000,
        IMAGE_SCN_MEM_SHARED = 0x10000000,
        IMAGE_SCN_MEM_EXECUTE = 0x20000000,
        IMAGE_SCN_MEM_READ = 0x40000000,
        IMAGE_SCN_MEM_WRITE = 0x80000000,
    }

    public class IMAGE_SECTION_HEADER
    {
        public string NameString { get; set; }
        public ulong Name => NameString.ToULong();

        /// <summary>
        /// 어셈블리 코드의 크기
        /// </summary>
        public uint VirtualSize { get; set; }

        /// <summary>
        /// 실제 메모리 상에서의 상대주소
        /// section마다 기본값은 0x1000으로 잡지만
        /// 크기가 클 경우 그 이상으로 잡아야함
        /// </summary>
        public uint RVA { get; set; }

        /// <summary>
        /// Section의 크기
        /// </summary>
        public uint SizeOfRawData { get; set; }

        /// <summary>
        /// Section의 시작주소
        /// </summary>
        public uint PointerToRawData { get; set; }

        public uint PointerToRelocations { get; set; }
        public uint PointerToLineNumbers { get; set; }
        public ushort NumberOfRelocations { get; set; }
        public ushort NumberOfLineNumbers { get; set; }
        public SectionFlags Characteristics { get; set; }
        public uint CharacteristicsValue => (uint)Characteristics;
        public byte[] Bytes => ToBytes();

        public IMAGE_SECTION_HEADER(string name, uint virtualSize, uint rva, uint sizeOfRawData, uint pointerToRawData, SectionFlags characteristics, uint pointerToRelocations = 0x00000000, uint pointerToLineNumbers = 0x00000000, ushort numberOfRelocations = 0x0000, ushort numberOfLineNumbers = 0x0000)
        {
            NameString = name;
            VirtualSize = virtualSize;
            RVA = rva;
            SizeOfRawData = sizeOfRawData;
            PointerToRawData = pointerToRawData;
            Characteristics = characteristics;
            PointerToRelocations = pointerToRelocations;
            PointerToLineNumbers = pointerToLineNumbers;
            NumberOfRelocations = numberOfRelocations;
            NumberOfLineNumbers = numberOfLineNumbers;

            //switch (name)
            //{
            //    case ".text":
            //        InitializeText(contentBytesLength);
            //        break;

            //    case ".data":
            //        InitializeData(contentBytesLength);
            //        break;

            //    case ".textbss":
            //        InitializeTextBss(contentBytesLength);
            //        break;

            //    case ".rdata":
            //        InitializeRData(contentBytesLength);
            //        break;

            //    case ".idata":
            //        InitializeIData(contentBytesLength);
            //        break;

            //    case ".msvcjmc":
            //        InitializeMSVCJMC(contentBytesLength);
            //        break;

            //    case ".00cfg":
            //        Initialize00CFG(contentBytesLength);
            //        break;

            //    case ".rsrc":
            //        InitializeRSRC(contentBytesLength);
            //        break;

            //    case ".reloc":
            //        InitializeRELOC(contentBytesLength);
            //        break;

            //    default:
            //        break;
            //}
        }

        private void InitializeText(uint assemblyBytesLength)
        {
            VirtualSize = assemblyBytesLength;
            //RVA = AddressManager.TextSectionRVA;
            RVA = 0x00011000;
            //SizeOfRawData = AddressManager.TextSectionRawSize;
            SizeOfRawData = 0x00005A00;
            //PointerToRawData = AddressManager.TextSectionRawPointer;
            PointerToRawData = 0x00000400;
            PointerToRelocations = 0x00000000;
            PointerToLineNumbers = 0x00000000;
            NumberOfRelocations = 0x0000;
            NumberOfLineNumbers = 0x0000;
            Characteristics = SectionFlags.IMAGE_SCN_CNT_CODE | SectionFlags.IMAGE_SCN_MEM_EXECUTE | SectionFlags.IMAGE_SCN_MEM_READ;
        }

        private void InitializeData(uint dataBytesLength)
        {
            VirtualSize = dataBytesLength;
            //RVA = AddressManager.DataSectionRVA;
            RVA = 0x0001A000;
            //SizeOfRawData = AddressManager.DataSectionRawSize;
            SizeOfRawData = 0x00000200;
            //PointerToRawData = AddressManager.DataSectionRawPointer;
            PointerToRawData = 0x00008200;
            PointerToRelocations = 0x00000000;
            PointerToLineNumbers = 0x00000000;
            NumberOfRelocations = 0x0000;
            NumberOfLineNumbers = 0x0000;
            Characteristics = SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ | SectionFlags.IMAGE_SCN_MEM_WRITE;
        }

        private void InitializeTextBss(uint length)
        {
            VirtualSize = length;
            RVA = 0x00001000;
            SizeOfRawData = 0x00000000;
            PointerToRawData = 0x00000000;
            PointerToRelocations = 0x00000000;
            PointerToLineNumbers = 0x00000000;
            NumberOfRelocations = 0x0000;
            NumberOfLineNumbers = 0x0000;
            Characteristics = SectionFlags.IMAGE_SCN_CNT_CODE | SectionFlags.IMAGE_SCN_CNT_UNINITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_EXECUTE | SectionFlags.IMAGE_SCN_MEM_READ | SectionFlags.IMAGE_SCN_MEM_WRITE;
        }

        private void InitializeRData(uint length)
        {
            VirtualSize = length;
            RVA = 0x00017000;
            SizeOfRawData = 0x00002400;
            PointerToRawData = 0x00005E00;
            PointerToRelocations = 0x00000000;
            PointerToLineNumbers = 0x00000000;
            NumberOfRelocations = 0x0000;
            NumberOfLineNumbers = 0x0000;
            Characteristics = SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ;
        }

        private void InitializeIData(uint length)
        {
            VirtualSize = length;
            RVA = 0x0001B000;
            SizeOfRawData = 0x00000C00;
            PointerToRawData = 0x00008400;
            PointerToRelocations = 0x00000000;
            PointerToLineNumbers = 0x00000000;
            NumberOfRelocations = 0x0000;
            NumberOfLineNumbers = 0x0000;
            Characteristics = SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ;
        }

        private void InitializeMSVCJMC(uint length)
        {
            VirtualSize = length;
            RVA = 0x0001C000;
            SizeOfRawData = 0x00000200;
            PointerToRawData = 0x00009000;
            PointerToRelocations = 0x00000000;
            PointerToLineNumbers = 0x00000000;
            NumberOfRelocations = 0x0000;
            NumberOfLineNumbers = 0x0000;
            Characteristics = SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ | SectionFlags.IMAGE_SCN_MEM_WRITE;
        }

        private void Initialize00CFG(uint length)
        {
            VirtualSize = length;
            RVA = 0x0001D000;
            SizeOfRawData = 0x00000200;
            PointerToRawData = 0x00009200;
            PointerToRelocations = 0x00000000;
            PointerToLineNumbers = 0x00000000;
            NumberOfRelocations = 0x0000;
            NumberOfLineNumbers = 0x0000;
            Characteristics = SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ;
        }

        private void InitializeRSRC(uint length)
        {
            VirtualSize = length;
            RVA = 0x0001E000;
            SizeOfRawData = 0x00000600;
            PointerToRawData = 0x00009400;
            PointerToRelocations = 0x00000000;
            PointerToLineNumbers = 0x00000000;
            NumberOfRelocations = 0x0000;
            NumberOfLineNumbers = 0x0000;
            Characteristics = SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ;
        }

        private void InitializeRELOC(uint length)
        {
            VirtualSize = length;
            RVA = 0x0001F000;
            SizeOfRawData = 0x00000600;
            PointerToRawData = 0x00009A00;
            PointerToRelocations = 0x00000000;
            PointerToLineNumbers = 0x00000000;
            NumberOfRelocations = 0x0000;
            NumberOfLineNumbers = 0x0000;
            Characteristics = SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ | SectionFlags.IMAGE_SCN_MEM_DISCARDABLE;
        }

        private byte[] ToBytes()
        {
            Serializer serializer = new Serializer();
            serializer.Add(Name);
            serializer.Add(VirtualSize);
            serializer.Add(RVA);
            serializer.Add(SizeOfRawData);
            serializer.Add(PointerToRawData);
            serializer.Add(PointerToRelocations);
            serializer.Add(PointerToLineNumbers);
            serializer.Add(NumberOfRelocations);
            serializer.Add(NumberOfLineNumbers);
            serializer.Add(CharacteristicsValue);

            return serializer.ToBytes();
        }
    }
}
