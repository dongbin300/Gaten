using Gaten.Net.Extension;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class STRXChunk : Chunk
    {
        public STRXChunk(GameRule.StarCraft.Script.String @string)
        {
            Name = "STRx";
            Size = 4102 + GetAllStringLength(@string);

            Match(@string);
        }

        void Match(GameRule.StarCraft.Script.String @string)
        {
            AddData(@string.StringCount);

            foreach(uint offset in @string.Offsets)
            {
                AddData(offset);
            }

            AddData(0);

            foreach(string data in @string.Data)
            {
                if (data == null)
                    continue;

                AddData(data.AsciiToBytes());
                AddData(0);
            }

            AddData(0);
        }

        int GetAllStringLength(GameRule.StarCraft.Script.String @string)
        {
            int sum = 0;

            for (int i = 0; i < 1024; i++)
            {
                if (@string.Offsets[i] != 4100)
                {
                    sum += @string.Data[i].Length + 1;
                }
            }

            return sum;
        }
    }
}
