namespace Gaten.GameTool.StarCraft.BoundMapMaker
{
    public class Pattern
    {
        public int ID { get; set; }
        public List<int> ZoneNumbers { get; set; }
        public int Wait { get; set; }

        public Pattern()
        {
            ZoneNumbers = new List<int>();
        }
    }
}
