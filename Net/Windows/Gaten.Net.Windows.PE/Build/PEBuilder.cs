using Gaten.Net.Data.Serialization;
using Gaten.Net.Windows.PE.PEFileFormat;

namespace Gaten.Net.Windows.PE.Build
{
    public class PEBuilder
    {
        private readonly IMAGE_DOS_HEADER imageDosHeader;
        private readonly MS_DOS_STUB msDosStub;
        private readonly IMAGE_NT_HEADER imageNTHeader;
        private readonly List<IMAGE_SECTION_HEADER> imageSectionHeaders;
        private readonly List<SECTION> sections;

        private byte[] bytes;

        //public PEBuilder(byte[] assemblyBytes, byte[] dataBytes)
        //{
        //    imageDosHeader = new IMAGE_DOS_HEADER();
        //    msDosStub = new MS_DOS_STUB();
        //    imageNTHeader = new IMAGE_NT_HEADER();
        //    imageSectionHeaders = new List<IMAGE_SECTION_HEADER>();
        //    //imageSectionHeaders.Add(new IMAGE_SECTION_HEADER(".textbss", 0x00010000));
        //    imageSectionHeaders.Add(new IMAGE_SECTION_HEADER(".text", (uint)assemblyBytes.Length));
        //    imageSectionHeaders.Add(new IMAGE_SECTION_HEADER(".rdata", 0x00002299));
        //    imageSectionHeaders.Add(new IMAGE_SECTION_HEADER(".data", (uint)dataBytes.Length));
        //    imageSectionHeaders.Add(new IMAGE_SECTION_HEADER(".idata", 0x00000B02));
        //    imageSectionHeaders.Add(new IMAGE_SECTION_HEADER(".msvcjmc", 0x00000104));
        //    imageSectionHeaders.Add(new IMAGE_SECTION_HEADER(".00cfg", 0x00000109));
        //    imageSectionHeaders.Add(new IMAGE_SECTION_HEADER(".rsrc", 0x0000043C));
        //    imageSectionHeaders.Add(new IMAGE_SECTION_HEADER(".reloc", 0x0000058F));
        //    sections = new List<SECTION>();
        //    sections.Add(new SECTION(".text", imageSectionHeaders.Find(h => h.NameString.Equals(".text")).SizeOfRawData, assemblyBytes));
        //    sections.Add(new SECTION(".rdata", imageSectionHeaders.Find(h => h.NameString.Equals(".rdata")).SizeOfRawData));
        //    sections.Add(new SECTION(".data", imageSectionHeaders.Find(h => h.NameString.Equals(".data")).SizeOfRawData, dataBytes));
        //    sections.Add(new SECTION(".idata", imageSectionHeaders.Find(h => h.NameString.Equals(".idata")).SizeOfRawData));
        //    sections.Add(new SECTION(".msvcjmc", imageSectionHeaders.Find(h => h.NameString.Equals(".msvcjmc")).SizeOfRawData));
        //    sections.Add(new SECTION(".00cfg", imageSectionHeaders.Find(h => h.NameString.Equals(".00cfg")).SizeOfRawData));
        //    sections.Add(new SECTION(".rsrc", imageSectionHeaders.Find(h => h.NameString.Equals(".rsrc")).SizeOfRawData));
        //    sections.Add(new SECTION(".reloc", imageSectionHeaders.Find(h => h.NameString.Equals(".reloc")).SizeOfRawData));

        //    Serialize();
        //}

        public PEBuilder(byte[] assemblyBytes, byte[] dataBytes)
        {
            bytes = Array.Empty<byte>();

            // Dos Stub
            msDosStub = new MS_DOS_STUB();

            // Section
            sections = new List<SECTION>
            {
                new SECTION(".text", (uint)assemblyBytes.Length, RAW_DATA.TextData),
                new SECTION(".rdata", 0x00002299, RAW_DATA.RDataData),
                new SECTION(".data", (uint)dataBytes.Length, RAW_DATA.DataData),
                new SECTION(".idata", 0x00000B02, RAW_DATA.IDataData),
                new SECTION(".msvcjmc", 0x00000104, RAW_DATA.MsvcjmcData),
                new SECTION(".00cfg", 0x00000109, RAW_DATA.CfgData),
                new SECTION(".rsrc", 0x0000043C, RAW_DATA.RsrcData),
                new SECTION(".reloc", 0x0000058F, RAW_DATA.RelocData)
            };

            // Section Header
            imageSectionHeaders = new List<IMAGE_SECTION_HEADER>
            {
                //imageSectionHeaders.Add(new IMAGE_SECTION_HEADER(".textttt", 0x00010000, 0x00001000, 0x00000000, 0x00000000,
                //IMAGE_SECTION_HEADER.SectionFlags.IMAGE_SCN_CNT_CODE | IMAGE_SECTION_HEADER.SectionFlags.IMAGE_SCN_CNT_UNINITIALIZED_DATA | IMAGE_SECTION_HEADER.SectionFlags.IMAGE_SCN_MEM_EXECUTE | IMAGE_SECTION_HEADER.SectionFlags.IMAGE_SCN_MEM_READ | IMAGE_SECTION_HEADER.SectionFlags.IMAGE_SCN_MEM_WRITE));
                new IMAGE_SECTION_HEADER(".text", (uint)assemblyBytes.Length, 0x00001000, 0x00005A00, 0x00000400,
                SectionFlags.IMAGE_SCN_CNT_CODE | SectionFlags.IMAGE_SCN_MEM_EXECUTE | SectionFlags.IMAGE_SCN_MEM_READ),
                new IMAGE_SECTION_HEADER(".rdata", 0x00002299, 0x00007000, 0x00002400, 0x00005E00,
                SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ),
                new IMAGE_SECTION_HEADER(".data", (uint)dataBytes.Length, 0x0000A000, 0x00000200, 0x00008200,
                SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ | SectionFlags.IMAGE_SCN_MEM_WRITE),
                new IMAGE_SECTION_HEADER(".idata", 0x00000B02, 0x0000B000, 0x00000C00, 0x00008400,
                SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ),
                new IMAGE_SECTION_HEADER(".msvcjmc", 0x00000104, 0x0000C000, 0x00000200, 0x00009000,
                SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ | SectionFlags.IMAGE_SCN_MEM_WRITE),
                new IMAGE_SECTION_HEADER(".00cfg", 0x00000109, 0x0000D000, 0x00000200, 0x00009200,
                SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ),
                new IMAGE_SECTION_HEADER(".rsrc", 0x0000043C, 0x0000E000, 0x00000600, 0x00009400,
                SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ),
                new IMAGE_SECTION_HEADER(".reloc", 0x0000058F, 0x0000F000, 0x00000600, 0x00009A00,
                SectionFlags.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionFlags.IMAGE_SCN_MEM_READ | SectionFlags.IMAGE_SCN_MEM_DISCARDABLE)
            };

            imageNTHeader = new IMAGE_NT_HEADER((ushort)imageSectionHeaders.Count);
            imageDosHeader = new IMAGE_DOS_HEADER(
                0x0090, 0x0003, 0x0000, 0x0004,
                0x0000, 0xFFFF, 0x0000, 0x00B8,
                0x0000, 0x0000, 0x0000, 0x0040, 0x0000,
                0x0000, 0x0000, 0x000000E0);

            Serialize();
        }

        private void Serialize()
        {
            Serializer serializer = new();
            serializer.Add(imageDosHeader.Bytes);
            serializer.Add(msDosStub.Bytes);
            serializer.Add(imageNTHeader.Bytes);
            foreach (IMAGE_SECTION_HEADER header in imageSectionHeaders)
            {
                serializer.Add(header.Bytes);
            }

            serializer.Add(new byte[40]);
            serializer.Add(new byte[0xC0]);

            foreach (SECTION section in sections)
            {
                serializer.Add(section.Bytes);
            }

            bytes = serializer.ToBytes();
        }

        public void WriteFile(Stream stream) => stream.Write(bytes, 0, bytes.Length);
    }
}
