namespace Gaten.Net.Windows.CHK.Chunks
{
    public class ISOMChunk : Chunk
    {
        public ISOMChunk()
        {
            Name = "ISOM";
            Size = 0;
            //Size = 2 * StarcraftRule.Region.Map.IsometricTerrain.Tiles.Length;

            Match();
        }

        void Match()
        {
            //foreach (ushort tile in StarcraftRule.Region.Map.IsometricTerrain.Tiles)
            //{
            //    AddData(tile);
            //}
        }
    }
}