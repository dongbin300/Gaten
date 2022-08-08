using Gaten.Net.Extensions;

namespace Gaten.Net.GameRule.StarCraft.Region.Map
{
    public class Terrain
    {
        public static ushort[] Tiles { get; set; } = new ushort[(int)Base.HorizontalDimension * (int)Base.VerticalDimension];

        public Terrain()
        {
            MakeDefault();
        }

        void MakeDefault()
        {
            Tiles.Fill((ushort)32);
        }
    }
}
