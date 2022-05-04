namespace Gaten.Net.Windows.CHK.Chunks
{
    public class PTECChunk : Chunk
    {
        public PTECChunk(string name, int size, byte[,] available, byte[,] researched, byte[] allAvailable, byte[] allResearched, byte[,] defaults)
        {
            Name = name;
            Size = size;

            foreach(byte b in available)
            {
                AddData(b);
            }

            foreach (byte b in researched)
            {
                AddData(b);
            }

            foreach (byte b in allAvailable)
            {
                AddData(b);
            }

            foreach (byte b in allResearched)
            {
                AddData(b);
            }

            foreach (byte b in defaults)
            {
                AddData(b);
            }
        }
    }
}