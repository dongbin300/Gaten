namespace Gaten.Net.GameRule.StarCraft.Region.Map
{
    public class Util
    {
        public static string SetTile(int x, int y, int tileNum)
        {
            if (x >= (int)Base.HorizontalDimension)
            {
                throw new OverflowException(nameof(x));
            }

            if (x >= (int)Base.VerticalDimension)
            {
                throw new OverflowException(nameof(y));
            }

            Terrain.Tiles[y * (int)Base.HorizontalDimension + x] = (ushort)tileNum;
            StareditTerrain.Tiles[y * (int)Base.HorizontalDimension + x] = (ushort)tileNum;

            return string.Empty;
        }
    }
}
