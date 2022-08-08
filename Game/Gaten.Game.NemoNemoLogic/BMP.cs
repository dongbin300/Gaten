namespace Gaten.Game.NemoNemoLogic
{
    internal class BMP
    {
        private readonly string fileName;
        private int fileSize;
        private int dataOffset;
        public int width;
        public int height;
        private short bits;
        private int dataSize;
        private int paletteCount;
        private byte[] paletteData;
        public Colors[] colorData;

        public struct Colors
        {
            public byte r, g, b;
        };

        private readonly int InfoLength = 54;

        public BMP(string fileName)
        {
            this.fileName = fileName;
        }
        public void ReadBitmap()
        {
            int size, cnt = 0;
            _ = new byte[InfoLength];
            FileStream fs = new(fileName, FileMode.Open);
            BinaryReader br = new(fs);
            byte[] info = br.ReadBytes(InfoLength);
            fileSize = BitConverter.ToInt32(info, 2);
            dataOffset = BitConverter.ToInt32(info, 10);
            width = BitConverter.ToInt32(info, 18);
            height = BitConverter.ToInt32(info, 22);
            bits = BitConverter.ToInt16(info, 28);
            dataSize = BitConverter.ToInt32(info, 34);
            paletteCount = BitConverter.ToInt32(info, 46);

            if (paletteCount > 0)
            {
                _ = br.ReadBytes(paletteCount * 4);
                paletteCount = 0;
            }
            switch (bits)
            {
                case 8:
                    paletteData = new byte[paletteCount * 4];
                    break;
            }
            size = 3 * width * height;
            colorData = new Colors[size / 3];
            for (int i = 0; i < size; i += 3)
            {
                colorData[cnt].b = br.ReadByte();
                colorData[cnt].g = br.ReadByte();
                colorData[cnt++].r = br.ReadByte();
            }
            br.Close();
            fs.Close();
        }

        public void BinaryImage()
        {
            byte b;
            for (int i = 0; i < colorData.Length; i++)
            {
                b = colorData[i].r + colorData[i].g + colorData[i].b < 384 ? (byte)0 : (byte)255;
                colorData[i].r = colorData[i].g = colorData[i].b = b;
            }
        }

        public void DataSubstitution()
        {

        }

        public void ReSize()
        {
            while (width > 50 || height > 50)
            {
                width /= 2;
                height /= 2;
            }
        }
    }
}
