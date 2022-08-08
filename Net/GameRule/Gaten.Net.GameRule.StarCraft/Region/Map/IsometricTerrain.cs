using Gaten.Net.Extensions;

namespace Gaten.Net.GameRule.StarCraft.Region.Map
{
    public class IsometricTerrain
    {
        public static ushort[] Tiles { get; set; } = new ushort[((int)Base.HorizontalDimension / 2 + 1) * ((int)Base.VerticalDimension + 1) * 4];

        public IsometricTerrain()
        {
            MakeDefault();
        }

        void MakeDefault()
        {
            Tiles.Fill((ushort)16);
        }
    }
}
