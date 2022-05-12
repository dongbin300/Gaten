namespace Gaten.GameTool.osu.osuRankingManager
{
    class PlayerInfo
    {
        public string Rank;
        public string Nickname;
        public string PlayCount;
        public string RankScore;
        public string SS;
        public string S;
        public string A;

        public override string ToString()
        {
            return $"{Rank} {Nickname} P:{PlayCount} R:{RankScore} SS:{SS} S:{S} A:{A}";
        }
    }
}
