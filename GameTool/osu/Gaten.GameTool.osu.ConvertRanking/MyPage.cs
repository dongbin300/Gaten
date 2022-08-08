
using Gaten.Net.GameRule.osu;
using Gaten.Net.Network;

namespace Gaten.GameTool.osu.ConvertRanking
{
    public class MyPage
    {
        public enum BeatmapGameModeParseLevel { Strict, Lite }
        public string nickname = string.Empty;
        public string displayNickname = string.Empty;
        public GameMode gameMode;
        public string title = string.Empty;
        public string country = string.Empty;
        public string rankScore = string.Empty;
        public string accuracy = string.Empty;
        public string playCount = string.Empty;
        public string totalScore = string.Empty;
        public string totalHit = string.Empty;
        public string maxCombo = string.Empty;
        public string replayWatched = string.Empty;
        public string friendCount = string.Empty;
        public string levelProgress = string.Empty;
        public string level = string.Empty;
        public string totalPlayTime = string.Empty;
        public string medal = string.Empty;
        public string pp = string.Empty;
        public string silverSsCount = string.Empty;
        public string goldSsCount = string.Empty;
        public string silverSCount = string.Empty;
        public string goldSCount = string.Empty;
        public string aCount = string.Empty;
        public string worldRank = string.Empty;
        public string countryRank = string.Empty;
        public string registDate = string.Empty;
        public string onlineStatus = string.Empty;
        public string playDevice = string.Empty;
        public string postCount = string.Empty;
        public string residence = string.Empty;
        public string interests = string.Empty;
        public string job = string.Empty;
        public string twitter = string.Empty;
        public string lastFm = string.Empty;
        public string website = string.Empty;
        public string me = string.Empty;
        public List<RecentActivity> recentActivities = new ();
        public List<TopPerformance> topPerformances = new ();
        public List<FirstPlaceAchievement> firstPlaceAchievements = new ();
        public List<MostPlayBeatmap> mostPlayBeatmaps = new ();

        public MyPage() { }

        public MyPage(string nickname)
        {
            this.nickname = nickname;
        }

        /// <summary>
        /// 최초 호출 함수
        /// </summary>
        public void Init()
        {
            // 유저 마이페이지 접속
            SeleniumWebCrawler.Open($"https://osu.ppy.sh/users/{nickname}");
            WebCrawler.Open();

            // 매니아 클릭
            //ClickGameMode("mania");

            // 유저 정보(스탯) 가져오기
            GetStats();

            SeleniumWebCrawler.Close();
            WebCrawler.Close();
        }

        /// <summary>
        /// 유저 정보(스탯) 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetStats()
        {
            // 메인모드 가져오기
            GetMainMode();

            // 프로필 사진 다운로드
            DownloadAvatar();

            // 마이페이지 닉네임 가져오기
            GetDisplayNickname();

            // 타이틀 가져오기
            GetTitle();

            GetCountry();

            GetMainStats();

            GetFriendCount();

            GetLevelProgress();

            GetLevel();

            GetTotalPlayTime();

            GetMedal();

            GetPp();

            GetGradeRank();

            GetWorldRank();

            GetCountryRank();

            GetMoreInformation();

            GetMe();

            GetRecentActivity();

            GetTopRanks();

            GetMostPlayBeatmaps();
        }

        /// <summary>
        /// 메인모드 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetMainMode()
        {
            string gameModeString = SeleniumWebCrawler.SelectNode("//a[contains(@class,'game-mode-link--active')]").GetAttribute("href");
            string[] data = gameModeString.Split('/');
            switch (data[data.Length - 1])
            {
                case "osu": gameMode = GameMode.Osu; break;
                case "taiko": gameMode = GameMode.Taiko; break;
                case "fruits": gameMode = GameMode.CatchTheBeat; break;
                case "mania": gameMode = GameMode.Mania; break;
            }
        }

        /// <summary>
        /// 게임모드 클릭하기
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="gameModeString"></param>
        public void ClickGameMode(string gameModeString)
        {
            SeleniumWebCrawler.SelectNode($"//a[@class='game-mode-link' and contains(@href,'{gameModeString}')]").Click();
        }

        /// <summary>
        /// 프로필 사진 다운로드
        /// </summary>
        /// <param name="driver"></param>
        public void DownloadAvatar()
        {
            string avatarPath = SeleniumWebCrawler.SelectNode("//div[contains(@class,'avatar--full')]").GetAttribute("style").Split('"')[1];
            WebCrawler.DownloadFile(avatarPath, $"avatar\\{nickname}.png");
        }

        /// <summary>
        /// 마이페이지 닉네임 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetDisplayNickname()
        {
            displayNickname = SeleniumWebCrawler.SelectNode("//span[@class='u-ellipsis-overflow']").Text;
        }

        /// <summary>
        /// 타이틀 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetTitle()
        {
            title = SeleniumWebCrawler.SelectNode("//span[@class='profile-info__title']").Text;
        }

        /// <summary>
        /// 국가 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetCountry()
        {
            country = SeleniumWebCrawler.SelectNode("//span[@class='profile-info__flag-text']").Text;
        }

        /// <summary>
        /// 메인 스탯(랭크스코어,플레이카운트,리플레이재생수,...) 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetMainStats()
        {
            var nodes = SeleniumWebCrawler.SelectNodes("//dd[@class='profile-stats__value']").ToList();

            rankScore = nodes[0].Text;
            accuracy = nodes[1].Text;
            playCount = nodes[2].Text;
            totalScore = nodes[3].Text;
            totalHit = nodes[4].Text;
            maxCombo = nodes[5].Text;
            replayWatched = nodes[6].Text;
        }

        /// <summary>
        /// 친구 수 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetFriendCount()
        {
            friendCount = SeleniumWebCrawler.SelectNode("//span[@class='user-action-button__counter']").Text;
        }

        /// <summary>
        /// 레벨 진행도 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetLevelProgress()
        {
            levelProgress = SeleniumWebCrawler.SelectNode("//div[@class='bar bar--user-profile']/div[@class='bar__text']").Text;
        }

        /// <summary>
        /// 레벨 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetLevel()
        {
            level = SeleniumWebCrawler.SelectNode("//div[@class='profile-detail-bar__level']").Text;
        }

        /// <summary>
        /// 총 플레이 시간 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetTotalPlayTime()
        {
            totalPlayTime = SeleniumWebCrawler.SelectNode("//div[@class='profile-detail__col profile-detail__col--top-left']//div[@class='value-display']/div[@class='value-display__value']").Text;
        }

        /// <summary>
        /// 메달 개수 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetMedal()
        {
            medal = SeleniumWebCrawler.SelectNode("//div[@class='profile-detail__col profile-detail__col--top-left']//div[@class='value-display value-display--medals']/div[@class='value-display__value']").Text;
        }

        /// <summary>
        /// PP 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetPp()
        {
            pp = SeleniumWebCrawler.SelectNode("//div[@class='profile-detail__col profile-detail__col--top-left']//div[@class='value-display value-display--pp']/div[@class='value-display__value']").Text;
        }

        /// <summary>
        /// 그레이드랭크(SS, S, A) 개수 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetGradeRank()
        {
            var nodes = SeleniumWebCrawler.SelectNodes("//div[@class='profile-rank-count__item']").ToList();

            silverSsCount = nodes[0].Text;
            goldSsCount = nodes[1].Text;
            silverSCount = nodes[2].Text;
            goldSCount = nodes[3].Text;
            aCount = nodes[4].Text;
        }

        /// <summary>
        /// 세계 랭킹 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetWorldRank()
        {
            worldRank = SeleniumWebCrawler.SelectNode("//div[@class='profile-detail__col profile-detail__col--bottom-right']/div[@class='profile-detail__bottom-right-item']/div[@class='value-display value-display--large']/div[@class='value-display__value']").Text;
        }

        /// <summary>
        /// 국가 랭킹 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetCountryRank()
        {
            countryRank = SeleniumWebCrawler.SelectNode("//div[@class='profile-detail__col profile-detail__col--bottom-right']/div[@class='profile-detail__bottom-right-item']/div[@class='value-display']/div[@class='value-display__value']").Text;
        }

        /// <summary>
        /// 상세 정보 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetMoreInformation()
        {
            var nodes = SeleniumWebCrawler.SelectNodes("//div[@class='profile-links']//div[contains(@class,'profile-links__item')]").ToList();

            foreach (var node in nodes)
            {
                if (node.Text.Contains("에 가입"))
                    registDate = node.Text.Replace("에 가입", "");
                else if (node.Text.Contains("마지막으로 접속") || node.Text.Contains("온라인"))
                    onlineStatus = node.Text;
                else if (node.Text.Contains("플레이 장비: "))
                    playDevice = node.Text.Replace("플레이 장비: ", "");
                else if (node.Text.Contains("게시글 수 "))
                    postCount = node.Text.Replace("게시글 수 ", "");
                else
                {
                    string classData = SeleniumWebCrawler.SelectNode(".//span[contains(@class,'fa-fw')]").GetAttribute("class");

                    if (classData.Contains("fa-map-marker-alt"))
                        residence = node.Text;
                    else if (classData.Contains("fa-heart"))
                        interests = node.Text;
                    else if (classData.Contains("fa-suitcase"))
                        job = node.Text;
                    else if (classData.Contains("fa-twitter"))
                        twitter = node.Text;
                    else if (classData.Contains("fa-lastfm"))
                        lastFm = node.Text;
                    else if (classData.Contains("fa-link"))
                        website = node.Text;
                }
            }
        }

        /// <summary>
        /// me! 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetMe()
        {
            try
            {
                me = SeleniumWebCrawler.SelectNode("//div[@class='bbcode bbcode--profile-page']").Text;
            }
            catch
            {
                me = string.Empty;
            }
        }

        /// <summary>
        /// 최근 활동 가져오기
        /// (추후 더 보기 버튼을 눌러서 최대로 가져올 수 있는 만큼 가져오게 수정할 것)
        /// </summary>
        /// <param name="driver"></param>
        public void GetRecentActivity()
        {
            var nodes = SeleniumWebCrawler.SelectNodes("//div[@data-page-id='recent_activity']//li[@class='profile-extra-entries__item']").ToList();

            foreach (var node in nodes)
            {
                recentActivities.Add(new RecentActivity().Parse(node));
            }
        }

        /// <summary>
        /// 랭크 탭 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetTopRanks()
        {
            var nodes = SeleniumWebCrawler.SelectNodes("//div[@data-page-id='top_ranks']/div/div").ToList();

            var topPerformanceButton = SeleniumWebCrawler.SelectNode(nodes[1], ".//button");
            topPerformanceButton.Click();
            topPerformanceButton.Click();

            var topPerformanceNodes = SeleniumWebCrawler.SelectNodes(nodes[1], ".//div[@class='play-detail play-detail--highlightable play-detail--compact']").ToList();

            foreach (var node in topPerformanceNodes)
            {
                topPerformances.Add(new TopPerformance().Parse(node, BeatmapGameModeParseLevel.Lite));
            }

            var firstPlaceAchievementNodes = SeleniumWebCrawler.SelectNodes(nodes[2], ".//div[@class='play-detail play-detail--highlightable play-detail--compact']").ToList();

            foreach (var node in firstPlaceAchievementNodes)
            {
                firstPlaceAchievements.Add(new FirstPlaceAchievement().Parse(node, BeatmapGameModeParseLevel.Lite));
            }
        }

        /// <summary>
        /// 가장 많이 플레이한 비트맵 가져오기
        /// </summary>
        /// <param name="driver"></param>
        public void GetMostPlayBeatmaps()
        {
            var nodes = SeleniumWebCrawler.SelectNodes("//div[@data-page-id='historical']//div[@class='beatmap-playcount']").ToList();

            foreach (var node in nodes)
            {
                mostPlayBeatmaps.Add(new MostPlayBeatmap().Parse(node, BeatmapGameModeParseLevel.Lite));
            }
        }
    }
}
