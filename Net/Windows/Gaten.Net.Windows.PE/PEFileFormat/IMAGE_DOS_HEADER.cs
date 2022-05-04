using Gaten.Net.Data.Serialization;
using Gaten.Net.Extension;

namespace Gaten.Net.Windows.PE.PEFileFormat
{
    public class IMAGE_DOS_HEADER
    {
        public ushort Signature { get; set; }
        public ushort BytesOnLastPageOfFile { get; set; }
        public ushort PagesInFile { get; set; }
        public ushort Relocations { get; set; }
        public ushort SizeOfHeaderInParagraphs { get; set; }
        public ushort MinimumExtraParagraphs { get; set; }
        public ushort MaximumExtraParagraphs { get; set; }
        public ushort InitialSS { get; set; }
        public ushort InitialSP { get; set; }
        public ushort Checksum { get; set; }
        public ushort InitialIP { get; set; }
        public ushort InitialCS { get; set; }
        public ushort OffsetToRelocationTable { get; set; }
        public ushort OverlayNumber { get; set; }
        public ushort OEMIdentifier { get; set; }
        public ushort OEMInformation { get; set; }
        public uint OffsetToNewEXEHeader { get; set; }
        public byte[] Bytes => ToBytes();

        public IMAGE_DOS_HEADER(ushort bytesOnLastPageOfFile, ushort pagesInFile, ushort relocations, ushort sizeOfHeaderInParagraphs, ushort minimumExtraParagraphs, ushort maximumExtraParagraphs, ushort initialSS, ushort initialSP, ushort checksum, ushort initialIP, ushort initialCS, ushort offsetToRelocationTable, ushort overlayNumber, ushort oemIdentifier, ushort oemInformation, uint offsetToNewEXEHeader)
        {
            Signature = "MZ".ToUShort();
            BytesOnLastPageOfFile = bytesOnLastPageOfFile;
            PagesInFile = pagesInFile;
            Relocations = relocations;
            SizeOfHeaderInParagraphs = sizeOfHeaderInParagraphs;
            MinimumExtraParagraphs = minimumExtraParagraphs;
            MaximumExtraParagraphs = maximumExtraParagraphs;
            InitialSS = initialSS;
            InitialSP = initialSP;
            Checksum = checksum;
            InitialIP = initialIP;
            InitialCS = initialCS;
            OffsetToRelocationTable = offsetToRelocationTable;
            OverlayNumber = overlayNumber;
            OEMIdentifier = oemIdentifier;
            OEMInformation = oemInformation;
            OffsetToNewEXEHeader = offsetToNewEXEHeader;

            //BytesOnLastPageOfFile = 0x0090;
            //PagesInFile = 0x0003;
            //Relocations = 0x0000;
            //SizeOfHeaderInParagraphs = 0x0004;
            //MinimumExtraParagraphs = 0x0000;
            //MaximumExtraParagraphs = 0xFFFF;
            //InitialSS = 0x0000;
            //InitialSP = 0x00B8;
            //Checksum = 0x0000;
            //InitialIP = 0x0000;
            //InitialCS = 0x0000;
            //OffsetToRelocationTable = 0x0040;
            //OverlayNumber = 0x0000;

            //// Reserved 8 Bytes

            //OEMIdentifier = 0x0000;
            //OEMInformation = 0x0000;

            //// Reserved 20 Bytes

            ////OffsetToNewEXEHeader = HexStringToUInt("000000A8");//
            //OffsetToNewEXEHeader = 0x000000E0;
        }

        private byte[] ToBytes()
        {
            Serializer serializer = new Serializer();
            serializer.Add(Signature);
            serializer.Add(BytesOnLastPageOfFile);
            serializer.Add(PagesInFile);
            serializer.Add(Relocations);
            serializer.Add(SizeOfHeaderInParagraphs);
            serializer.Add(MinimumExtraParagraphs);
            serializer.Add(MaximumExtraParagraphs);
            serializer.Add(InitialSS);
            serializer.Add(InitialSP);
            serializer.Add(Checksum);
            serializer.Add(InitialIP);
            serializer.Add(InitialCS);
            serializer.Add(OffsetToRelocationTable);
            serializer.Add(OverlayNumber);
            serializer.Add(new byte[8]);
            serializer.Add(OEMIdentifier);
            serializer.Add(OEMInformation);
            serializer.Add(new byte[20]);
            serializer.Add(OffsetToNewEXEHeader);

            return serializer.ToBytes();
        }
    }
}
