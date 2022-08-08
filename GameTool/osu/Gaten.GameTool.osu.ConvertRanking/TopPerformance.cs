
using Gaten.Net.GameRule.osu;
using Gaten.Net.Network;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Gaten.GameTool.osu.ConvertRanking
{
    public class TopPerformance
    {
        public GradeRank GradeRank { get; set; }
        public string BeatmapString { get; set; } = string.Empty;
        public string BeatmapArtist { get; set; } = string.Empty;
        public string BeatmapUrl { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public GameMode GameMode { get; set; }
        public string ElapsedTime { get; set; } = string.Empty;
        public Modes Mode { get; set; }
        public string Accuracy { get; set; } = string.Empty;
        public string WeightedPp { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string Pp { get; set; } = string.Empty;

        public TopPerformance Parse(IWebElement node, MyPage.BeatmapGameModeParseLevel beatmapGameModeParseLevel)
        {
            string gradeRankClassData = SeleniumWebCrawler.SelectNode(node, ".//div[@class='play-detail__icon play-detail__icon--main']/div").GetAttribute("class");
            if (gradeRankClassData.Contains("score-rank--D")) GradeRank = GradeRank.D;
            else if (gradeRankClassData.Contains("score-rank--C")) GradeRank = GradeRank.C;
            else if (gradeRankClassData.Contains("score-rank--B")) GradeRank = GradeRank.B;
            else if (gradeRankClassData.Contains("score-rank--A")) GradeRank = GradeRank.A;
            else if (gradeRankClassData.Contains("score-rank--SH")) GradeRank = GradeRank.SilverS;
            else if (gradeRankClassData.Contains("score-rank--XH")) GradeRank = GradeRank.SilverSS;
            else if (gradeRankClassData.Contains("score-rank--S")) GradeRank = GradeRank.GoldS;
            else if (gradeRankClassData.Contains("score-rank--X")) GradeRank = GradeRank.GoldSS;

            BeatmapArtist = SeleniumWebCrawler.SelectNode(node, ".//small[@class='play-detail__artist']").Text.Replace("by ", "");
            BeatmapString = SeleniumWebCrawler.SelectNode(node, ".//a[@class='play-detail__title u-ellipsis-overflow']").Text.Replace("by " + BeatmapArtist, "").Trim();
            BeatmapUrl = SeleniumWebCrawler.SelectNode(node, ".//a[@class='play-detail__title u-ellipsis-overflow']").GetAttribute("href");
            Difficulty = SeleniumWebCrawler.SelectNode(node, ".//span[@class='play-detail__beatmap']").Text;
            ElapsedTime = SeleniumWebCrawler.SelectNode(node, ".//span[@class='play-detail__time']").Text;
            try
            {
                var modeNodes = SeleniumWebCrawler.SelectNodes(node, ".//div[@class='mods__mod-image']/div").ToList();
                foreach (IWebElement modeNode in modeNodes)
                {
                    string modeClassData = modeNode.GetAttribute("class");
                    if (modeClassData.Contains("mod--EZ")) Mode |= Modes.Easy;
                    if (modeClassData.Contains("mod--HT")) Mode |= Modes.HalfTime;
                    if (modeClassData.Contains("mod--NF")) Mode |= Modes.NoFail;
                    if (modeClassData.Contains("mod--HR")) Mode |= Modes.HardRock;
                    if (modeClassData.Contains("mod--SD")) Mode |= Modes.SuddenDeath;
                    if (modeClassData.Contains("mod--PF")) Mode |= Modes.Perfect;
                    if (modeClassData.Contains("mod--DT")) Mode |= Modes.DoubleTime;
                    if (modeClassData.Contains("mod--NC")) Mode |= Modes.NightCore;
                    if (modeClassData.Contains("mod--HD")) Mode |= Modes.Hidden;
                    if (modeClassData.Contains("mod--FL")) Mode |= Modes.FlashLight;
                }
            }
            catch
            {
                Mode = Modes.None;
            }
            Accuracy = SeleniumWebCrawler.SelectNode(node, ".//span[@class='play-detail__accuracy']").Text;
            WeightedPp = SeleniumWebCrawler.SelectNode(node, ".//span[@class='play-detail__weighted-pp']").Text.Replace("pp", "");
            Weight = SeleniumWebCrawler.SelectNode(node, ".//div[@class='play-detail__pp-weight']").Text.Replace("가중치 ", "");
            Pp = SeleniumWebCrawler.SelectNode(node, ".//div[@class='play-detail__pp']").Text.Replace("pp", "");

            // 엄격하게 비트맵 게임모드 확인
            // 실제로 비트맵 URL 들어가서 모드 확인하는 방식이라 정확함
            // 크롬 열었다 닫았다 해야돼서 처리시간 오래걸림
            if (beatmapGameModeParseLevel == MyPage.BeatmapGameModeParseLevel.Strict)
            {
                using (IWebDriver gameModeCheckDriver = new ChromeDriver())
                {
                    gameModeCheckDriver.Url = BeatmapUrl;

                    string gameModeClassData = gameModeCheckDriver.FindElement(By.XPath("//a[contains(@class,'beatmapset-beatmap-picker__beatmap--active')]//i")).GetAttribute("class");
                    if (gameModeClassData.Contains("fa-extra-mode-osu")) GameMode = GameMode.Osu;
                    else if (gameModeClassData.Contains("fa-extra-mode-taiko")) GameMode = GameMode.Taiko;
                    else if (gameModeClassData.Contains("fa-extra-mode-fruits")) GameMode = GameMode.CatchTheBeat;
                    else if (gameModeClassData.Contains("fa-extra-mode-mania")) GameMode = GameMode.Mania;
                }
            }
            // 간단하게 비트맵 게임모드 확인
            // 난이도 문자열로 대충 판단하는 방식이라 정확하지 않을 수 있음
            // 처리시간 매우 빠름
            else if (beatmapGameModeParseLevel == MyPage.BeatmapGameModeParseLevel.Lite)
            {
                if (General.TaikoDifficultyStrings.Find(s => Difficulty.Contains(s)) != null) GameMode = GameMode.Taiko;
                else if (General.CatchTheBeatDifficultyStrings.Find(s => Difficulty.Contains(s)) != null) GameMode = GameMode.CatchTheBeat;
                else if (General.ManiaDifficultyStrings.Find(s => Difficulty.Contains(s)) != null) GameMode = GameMode.Mania;
                else GameMode = GameMode.Osu;
            }

            return this;
        }
    }
}
