
using Gaten.Net.GameRule.osu;
using Gaten.Net.Network;

using OpenQA.Selenium;

namespace Gaten.GameTool.osu.ConvertRanking
{
    public enum RecentActivityType
    {
        Record,
        Lose
    }

    public class RecentActivity
    {
        public RecentActivityType RecentActivityType { get; set; }
        public GradeRank GradeRank { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string BeatmapString { get; set; } = string.Empty;
        public string BeatmapUrl { get; set; } = string.Empty;
        public GameMode GameMode { get; set; }
        public string Rank { get; set; } = string.Empty;
        public string ElapsedTime { get; set; } = string.Empty;

        public RecentActivity Parse(IWebElement node)
        {
            if (node.Text.Contains("기록했습니다"))
            {
                RecentActivityType = RecentActivityType.Record;

                string classData = SeleniumWebCrawler.SelectNode(node, ".//div[@class='profile-extra-entries__icon']/div").GetAttribute("class");
                if (classData.Contains("score-rank--D")) GradeRank = GradeRank.D;
                else if (classData.Contains("score-rank--C")) GradeRank = GradeRank.C;
                else if (classData.Contains("score-rank--B")) GradeRank = GradeRank.B;
                else if (classData.Contains("score-rank--A")) GradeRank = GradeRank.A;
                else if (classData.Contains("score-rank--SH")) GradeRank = GradeRank.SilverS;
                else if (classData.Contains("score-rank--XH")) GradeRank = GradeRank.SilverSS;
                else if (classData.Contains("score-rank--S")) GradeRank = GradeRank.GoldS;
                else if (classData.Contains("score-rank--X")) GradeRank = GradeRank.GoldSS;

                UserName = SeleniumWebCrawler.SelectNode(node, ".//strong/em").Text;
                BeatmapString = SeleniumWebCrawler.SelectNode(node, ".//div[@class='profile-extra-entries__text']/em/a").Text;
                BeatmapUrl = SeleniumWebCrawler.SelectNode(node, ".//div[@class='profile-extra-entries__text']/em/a").GetAttribute("href");
                string temp = SeleniumWebCrawler.SelectNode(node, ".//div[@class='profile-extra-entries__text']").Text.Replace(UserName + "님이 " + BeatmapString + " (", "");
                string[] data = temp.Split(new string[] { ")맵에서 ", "등을" }, StringSplitOptions.None);
                switch (data[0])
                {
                    case "osu!": GameMode = GameMode.Osu; break;
                    case "osu!taiko": GameMode = GameMode.Taiko; break;
                    case "osu!catch": GameMode = GameMode.CatchTheBeat; break;
                    case "osu!mania": GameMode = GameMode.Mania; break;
                }
                Rank = data[1];

                ElapsedTime = SeleniumWebCrawler.SelectNode(node, ".//div[@class='profile-extra-entries__time']").Text;
            }

            return this;
        }
    }
}
