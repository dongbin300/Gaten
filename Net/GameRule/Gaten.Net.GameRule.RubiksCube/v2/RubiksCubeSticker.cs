using System.Runtime.InteropServices;

namespace Gaten.Net.GameRule.RubiksCube.v2
{
    [StructLayout(LayoutKind.Sequential)]
    public class RubiksCubeSticker
    {
        public LocationCode Location { get; set; }
        public StickerCode Sticker { get; set; }

        public RubiksCubeSticker(LocationCode location, StickerCode sticker)
        {
            Location = location;
            Sticker = sticker;
        }

        public string GetStickerOneCode() => Sticker switch
        {
            StickerCode.F => "F",
            StickerCode.L => "L",
            StickerCode.U => "U",
            StickerCode.R => "R",
            StickerCode.D => "D",
            StickerCode.B => "B",
            _ => "X"
        };

        public void SetStickerOneCode(string code) => Sticker = code switch
        {
            "F" => StickerCode.F,
            "L" => StickerCode.L,
            "U" => StickerCode.U,
            "R" => StickerCode.R,
            "D" => StickerCode.D,
            "B" => StickerCode.B,
            "X" or _ => StickerCode.Unknown,
        };

        public RubiksCubeSticker Clone()
        {
            return new RubiksCubeSticker(Location, Sticker);
        }
    }
}
