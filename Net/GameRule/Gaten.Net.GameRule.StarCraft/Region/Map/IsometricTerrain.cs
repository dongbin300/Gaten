using Gaten.Net.Extension;

namespace Gaten.Net.GameRule.StarCraft.Region.Map
{
    public class IsometricTerrain
    {
        public static ushort[] Tiles { get; set; }

        public IsometricTerrain()
        {
            Tiles = new ushort[((int)Base.HorizontalDimension / 2 + 1) * ((int)Base.VerticalDimension + 1) * 4];

            MakeDefault();
        }

        void MakeDefault()
        {
            Tiles.Fill((ushort)16);
        }
    }
}
