using Gaten.Net.GameRule.osu;
using Gaten.Net.Network;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Gaten.GameTool.osu.ConvertRanking
{
    public class MostPlayBeatmap
    {
        public string BeatmapString { get; set; }
        public string BeatmapArtist { get; set; }
        public string BeatmapUrl { get; set; }
        public string Difficulty { get; set; }
        public string Mapper { get; set; }
        public string MapperUrl { get; set; }
        public string PlayCount { get; set; }
        public GameMode GameMode { get; set; }

        public MostPlayBeatmap Parse(IWebElement node, MyPage.BeatmapGameModeParseLevel beatmapGameModeParseLevel)
        {
            BeatmapArtist = SeleniumWebCrawler.SelectNode(node, ".//span[@class='beatmap-playcount__title-artist']").Text.Replace("by ", "");
            BeatmapUrl = SeleniumWebCrawler.SelectNode(node, ".//a[@class='beatmap-playcount__title']").GetAttribute("href");
            string[] data = SeleniumWebCrawler.SelectNode(node, ".//a[@class='beatmap-playcount__title']").Text.Replace("by " + BeatmapArtist, "").Split('[');
            BeatmapString = data[0].Trim();
            Difficulty = data[1].Replace("]", "").Trim();
            Mapper = SeleniumWebCrawler.SelectNode(node, ".//a[@class='beatmap-playcount__mapper-link js-usercard']").Text;
            MapperUrl = SeleniumWebCrawler.SelectNode(node, ".//a[@class='beatmap-playcount__mapper-link js-usercard']").GetAttribute("href");
            PlayCount = SeleniumWebCrawler.SelectNode(node, ".//div[@class='beatmap-playcount__count']").Text;

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
