namespace Gaten.GameTool.osu.Mosu_.Models
{
    public class BeatmapDifficulty
    {
        public string Name { get; set; }
        public string Difficulty { get; set; }

        public BeatmapDifficulty(string name, string difficulty)
        {
            Name = name;
            Difficulty = difficulty;
        }
    }
}
