using Gaten.Net.Extensions;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class Chunk
    {
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; }

        public List<byte> NameBytes => Name.AsciiToBytes().ToList();
        public List<byte> SizeBytes => Size.ToBytes().ToList();
        public List<byte> Data { get; set; } = new();

        public Chunk()
        {
        }

        public Chunk(string name, int size, string data)
        {
            Name = name;
            Size = size;
            Data = data.ToBytes().ToList();
        }

        public Chunk(string name, int size, List<byte> data)
        {
            Name = name;
            Size = size;
            Data = data;
        }

        public void Show()
        {
            Console.Write($"{Name}({Size} bytes): ");
            Console.Write($"[{NameBytes.ToHexString()}]");
            Console.Write($"[{SizeBytes.ToHexString()}]");
            Console.Write($"{Data.ToHexString()}");
            Console.WriteLine();
        }

        /// <summary>
        /// Name + Size + Data Hex Bytes
        /// 파일에 데이터 작성용
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            var temp = NameBytes;
            temp.AddRange(SizeBytes);
            temp.AddRange(Data);

            return temp.ToArray();
        }

        public void AddData(byte data)
        {
            Data = Data.Concat(new List<byte> { data }).ToList();
        }

        public void AddData(ushort data)
        {
            Data = Data.Concat(BitConverter.GetBytes(data)).ToList();
        }

        public void AddData(uint data)
        {
            Data = Data.Concat(BitConverter.GetBytes(data)).ToList();
        }

        public void AddData(string data)
        {
            Data = Data.Concat(Data.ToBytes()).ToList();
        }

        public void AddData(byte[] data)
        {
            foreach(byte b in data)
            {
                AddData(b);
            }
        }

        public void AddData(ushort[] data)
        {
            foreach (ushort s in data)
            {
                AddData(s);
            }
        }

        public void AddData(uint[] data)
        {
            foreach (uint i in data)
            {
                AddData(i);
            }
        }
    }
}
