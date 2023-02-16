using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gaten.Audio.Waver.Models
{
    internal class WavFile
    {
        public int ChunkID;
        public int ChunkSize;
        public int Format;
        public int SubChunk1ID;
        public int SubChunk1Size;
        public short AudioFormat;
        public short NumChannels;
        public int SampleRate;
        public int ByteRate;
        public short BlockAlign;
        public short BitsPerSample;
        public short ExtraParamSize;
        public int ListID;
        public int ListSize;
        public int SubChunk2ID;
        public int SubChunk2Size;
        public List<double> Data { get; set; } = new();

        public WavFile(string filename)
        {
            using var stream = new FileStream(filename, FileMode.Open);
            using var reader = new BinaryReader(stream);

            ChunkID = BitConverter.ToInt32(reader.ReadBytes(4), 0);
            ChunkSize = BitConverter.ToInt32(reader.ReadBytes(4), 0);
            Format = BitConverter.ToInt32(reader.ReadBytes(4), 0);

            SubChunk1ID = BitConverter.ToInt32(reader.ReadBytes(4), 0);
            SubChunk1Size = BitConverter.ToInt32(reader.ReadBytes(4), 0);
            AudioFormat = BitConverter.ToInt16(reader.ReadBytes(2), 0);
            NumChannels = BitConverter.ToInt16(reader.ReadBytes(2), 0);
            SampleRate = BitConverter.ToInt32(reader.ReadBytes(4), 0);
            ByteRate = BitConverter.ToInt32(reader.ReadBytes(4), 0);
            BlockAlign = BitConverter.ToInt16(reader.ReadBytes(2), 0);
            BitsPerSample = BitConverter.ToInt16(reader.ReadBytes(2), 0);

            if (SubChunk1Size > 16)
            {
                ExtraParamSize = BitConverter.ToInt16(reader.ReadBytes(2), 0);
            }

            if (reader.PeekChar() == 'F')
            {
                reader.ReadBytes(10);
            }

            if (reader.PeekChar() == 'L')
            {
                ListID = BitConverter.ToInt32(reader.ReadBytes(4), 0);
                ListSize = BitConverter.ToInt32(reader.ReadBytes(4), 0);

                reader.ReadBytes(ListSize);
            }

            SubChunk2ID = BitConverter.ToInt32(reader.ReadBytes(4), 0);
            SubChunk2Size = BitConverter.ToInt32(reader.ReadBytes(4), 0);

            int bps = BitsPerSample / 8;
            switch(bps)
            {
                case 4:
                    for (int i = 0; i < SubChunk2Size; i += bps)
                    {
                        Data.Add(BitConverter.ToInt32(reader.ReadBytes(bps), 0));
                    }
                    break;

                case 3:
                    for (int i = 0; i < SubChunk2Size; i += bps)
                    {
                        byte[] rv = reader.ReadBytes(bps).Concat(new byte[] { 0x00 }).ToArray();
                        Data.Add(BitConverter.ToInt32(rv, 0));
                    }
                    break;

                case 2:
                    for (int i = 0; i < SubChunk2Size; i += bps)
                    {
                        byte[] rv = reader.ReadBytes(bps).Concat(new byte[] { 0x00, 0x00 }).ToArray();
                        Data.Add(BitConverter.ToInt32(rv, 0));
                    }
                    break;
            }
        }

    }
}
