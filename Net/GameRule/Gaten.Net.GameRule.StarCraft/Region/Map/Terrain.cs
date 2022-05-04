using Gaten.Net.Extension;

namespace Gaten.Net.GameRule.StarCraft.Region.Map
{
    public class Terrain
    {
        public static ushort[] Tiles { get; set; }

        public Terrain()
        {
            Tiles = new ushort[(int)Base.HorizontalDimension * (int)Base.VerticalDimension];

            MakeDefault();
        }

        void MakeDefault()
        {
            Tiles.Fill((ushort)32);
        }
    }
}
