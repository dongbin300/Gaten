namespace Gaten.Net.GameRule.RubiksCube.v2
{
    public class RubiksCubeSticker
    {
        public LocationCode Location { get; set; }
        public StickerCode Sticker { get; set; }

        public RubiksCubeSticker(LocationCode location, StickerCode sticker)
        {
            Location = location;
            Sticker = sticker;
        }
    }
}
