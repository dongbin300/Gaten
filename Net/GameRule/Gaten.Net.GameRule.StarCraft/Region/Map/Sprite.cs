namespace Gaten.Net.GameRule.StarCraft.Region.Map
{
    [Flags]
    public enum SpriteStatus
    {
        DrawAsSprite,
        Disabled
    }

    public class Sprite
    {
        public ushort Number { get; set; }
        public ushort X { get; set; }
        public ushort Y { get; set; }
        public byte Owner { get; set; }
        public SpriteStatus Status { get; set; }
    }
}
