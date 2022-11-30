namespace Gaten.GameTool.osu.Mosu_.Models
{
    class PlayerInfo
    {
        public string Rank = string.Empty;
        public string Nickname = string.Empty;
        public string PlayCount = string.Empty;
        public string RankScore = string.Empty;
        public string SS = string.Empty;
        public string S = string.Empty;
        public string A = string.Empty;

        public override string ToString()
        {
            return $"{Rank} {Nickname} P:{PlayCount} R:{RankScore} SS:{SS} S:{S} A:{A}";
        }
    }
}
