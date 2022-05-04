using Gaten.Net.GameRule.StarCraft.Region.Map;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class THG2Chunk : Chunk
    {
        public THG2Chunk(List<Sprite> sprites)
        {
            Name = "THG2";
            Size = 10 * sprites.Count;

            Match(sprites);
        }

        void Match(List<Sprite> sprites)
        {
            foreach(Sprite sprite in sprites)
            {
                AddData(sprite.Number);
                AddData(sprite.X);
                AddData(sprite.Y);
                AddData(sprite.Owner);
                AddData(0);
                AddData((ushort)sprite.Status);
            }
        }
    }
}
