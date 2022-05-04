using Gaten.Net.Extension;

namespace Gaten.Net.Windows.PE.PEFileFormat
{
    public class MS_DOS_STUB
    {
        byte[] Data;
        public byte[] Bytes => ToBytes();

        public MS_DOS_STUB()
        {
            //Data = (
            //    "0E 1F BA 0E 00 B4 09 CD 21 B8 01 4C CD 21 54 68 " +
            //    "69 73 20 70 72 6F 67 72 61 6D 20 63 61 6E 6E 6F " +
            //    "74 20 62 65 20 72 75 6E 20 69 6E 20 44 4F 53 20 " +
            //    "6D 6F 64 65 2E 0D 0D 0A 24 00 00 00 00 00 00 00 " +
            //    "5D 17 1D DB 19 76 73 88 19 76 73 88 19 76 73 88 " +
            //    "E5 56 61 88 18 76 73 88 52 69 63 68 19 76 73 88 " +
            //    "00 00 00 00 00 00 00 00").ToBytes();

            Data = (
                "0E 1F BA 0E 00 B4 09 CD 21 B8 01 4C CD 21 54 68 " +
                "69 73 20 70 72 6F 67 72 61 6D 20 63 61 6E 6E 6F " +
                "74 20 62 65 20 72 75 6E 20 69 6E 20 44 4F 53 20 " +
                "6D 6F 64 65 2E 0D 0D 0A 24 00 00 00 00 00 00 00 " +
                "0A A3 B7 E3 4E C2 D9 B0 4E C2 D9 B0 4E C2 D9 B0 " +
                "F0 B3 D8 B1 4D C2 D9 B0 F0 B3 DC B1 57 C2 D9 B0 " +
                "F0 B3 DD B1 43 C2 D9 B0 15 AA D8 B1 4A C2 D9 B0 " +
                "4E C2 D8 B0 0B C2 D9 B0 D9 B0 DC B1 4F C2 D9 B0 " +
                "D9 B0 26 B0 4F C2 D9 B0 D9 B0 DB B1 4F C2 D9 B0 " +
                "52 69 63 68 4E C2 D9 B0 00 00 00 00 00 00 00 00 ").ToBytes();
        }

        private byte[] ToBytes() => Data;
    }
}
