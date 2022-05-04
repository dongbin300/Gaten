namespace Gaten.Net.GameRule.StarCraft.Region
{
    public class LocationSet
    {
        public List<Location> Locations { get; set; }

        public LocationSet()
        {
            Locations = new List<Location>();

            MakeDefault();
        }

        void MakeDefault()
        {
            for (int i = 0; i < 255; i++)
            {
                Locations.Add(new Location(0, 0, 0, 0, 0, Location.Elevations.None));
            }
        }
    }
}
