using Gaten.Net.GameRule.StarCraft.Script;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class WAVChunk : Chunk
    {
        public WAVChunk()
        {
            Name = "WAV ";
            Size = 2048;

            Match();
        }

        void Match()
        {
            foreach (uint mpqPath in Wav.MPQPath)
            {
                AddData(mpqPath);
            }
        }
    }
}
