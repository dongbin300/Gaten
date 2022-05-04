namespace Gaten.Net.Windows.CHK.Chunks
{
    public class UPGRChunk : Chunk
    {
        public UPGRChunk(string name, int size, byte[,] playerMaxLevels, byte[,] playerStartLevels, byte[] globalMaxLevels, byte[] globalStartLevels, byte[,] defaults)
        {
            Name = name;
            Size = size;

            foreach(byte playerMaxLevel in playerMaxLevels)
            {
                AddData(playerMaxLevel);
            }

            foreach (byte playerStartLevel in playerStartLevels)
            {
                AddData(playerStartLevel);
            }

            foreach (byte globalMaxLevel in globalMaxLevels)
            {
                AddData(globalMaxLevel);
            }

            foreach (byte globalStartLevel in globalStartLevels)
            {
                AddData(globalStartLevel);
            }

            foreach (byte _default in defaults)
            {
                AddData(_default);
            }
        }
    }
}
