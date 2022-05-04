namespace Gaten.Net.GameRule.StarCraft.Region.Map
{
    public class Base
    {
        public enum MapTileSet
        {
            Badlands = 0,
            SpacePlatform = 1,
            Installation = 2,
            Ashworld = 3,
            Jungle = 4,
            Desert = 5,
            Arctic = 6,
            Twilight = 7
        }

        public enum MapDimension
        {
            Size64 = 64,
            Size96 = 96,
            Size128 = 128,
            Size192 = 192,
            Size256 = 256
        }

        public static MapTileSet TileSet { get; set; }
        public static MapDimension HorizontalDimension { get; set; }
        public static MapDimension VerticalDimension { get; set; }

        public Base()
        {
            MakeDefault();
        }

        void MakeDefault()
        {
            TileSet = MapTileSet.Badlands;

            HorizontalDimension = MapDimension.Size128;
            VerticalDimension = MapDimension.Size128;
        }
    }
}
