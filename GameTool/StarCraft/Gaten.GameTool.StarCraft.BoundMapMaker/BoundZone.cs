namespace Gaten.GameTool.StarCraft.BoundMapMaker
{
    public class BoundZone
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public List<int> PatternNumber { get; set; }

        public BoundZone()
        {
            PatternNumber = new List<int>();
        }


    }
}
