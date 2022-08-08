using Gaten.Net.Extensions;

namespace Gaten.Net.GameRule.StarCraft.Region.Map
{
    public class StareditTerrain
    {
        public static ushort[] Tiles { get; set; } = new ushort[(int)Base.HorizontalDimension * (int)Base.VerticalDimension];

        public StareditTerrain()
        {
            MakeDefault();
        }

        void MakeDefault()
        {
            Tiles.Fill((ushort)32);
        }
    }
}
