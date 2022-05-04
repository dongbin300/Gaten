namespace Gaten.Net.GameRule.StarCraft.Region
{
    public class Location
    {
        [Flags]
        public enum Elevations
        {
            None = 0,
            LowElevation = 1,
            MediumElevation = 2,
            HighElevation = 4,
            LowAir = 8,
            MediumAir = 16,
            HighAir = 32
        }

        public uint Left { get; set; }
        public uint Top { get; set; }
        public uint Right { get; set; }
        public uint Bottom { get; set; }
        public ushort StringNumber { get; set; }
        public Elevations _Elevations { get; set; }

        public Location()
        {

        }

        public Location(uint left, uint top, uint right, uint bottom, ushort stringNumber, Elevations elevations)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            StringNumber = stringNumber;
            _Elevations = elevations;
        }
    }
}
