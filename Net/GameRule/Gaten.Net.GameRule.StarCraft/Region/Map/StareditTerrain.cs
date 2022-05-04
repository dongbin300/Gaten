using Gaten.Net.Extension;

namespace Gaten.Net.GameRule.StarCraft.Region.Map
{
    public class StareditTerrain
    {
        public static ushort[] Tiles { get; set; }

        public StareditTerrain()
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
