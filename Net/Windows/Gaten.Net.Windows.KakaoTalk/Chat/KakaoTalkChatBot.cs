using Gaten.Net.Extensions;
using Gaten.Net.Image;
using Gaten.Net.Math;
using Gaten.Net.Windows.KakaoTalk.Game.StockGame;
using Gaten.Net.Windows.KakaoTalk.Quiz;

using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Versioning;
using System.Text;

namespace Gaten.Net.Windows.KakaoTalk.Chat
{
    [SupportedOSPlatform("windows")]
    public class KakaoTalkChatBot
    {
        public static bool IsRunning { get; private set; }
        public static KakaoTalkChatWindow Window { get; set; } = new();
        public static List<KakaoTalkChatMessage> Messages { get; private set; } = new();
        static Thread worker = default!;
        private static int pointerIndex = 0;
        private readonly static int InitMessasgeCount = 8;
        private static SmartRandom r = new();

        public static int CurrentProfileCount { get; set; }
        public static int CurrentChatCount { get; set; }

        public static int WorkInterval = 2000;
        private readonly static int ProfileSize = 43;
        private readonly static int ChatWidth = 25;
        private readonly static int ChatHeight = 30;

        private static bool quizzing;
        private static bool IsStockGameRefreshed;
        private static bool IsStockGameRewarded;

        private static Dictionary<string, int> HolAccounts = new();

        private static int ChatHeightMultiLine(int lineCount) => ChatHeight + (lineCount - 1) * 18;

        public static Bitmap ChatRoomImage { get; set; } = default!;

        public KakaoTalkChatBot()
        {

        }

        public static void Init(KakaoTalkChatWindow window)
        {
            ChosungQuiz.Init();
            KakaoTalkChatApi.SendChatMessage(window, StockGameEngine.Init());
            worker = new Thread(new ThreadStart(DoWork));
            Window = window;
        }

        public static void InitChosung(KakaoTalkChatWindow window)
        {
            ChosungQuiz.Init();
            worker = new Thread(new ThreadStart(DoWork));
            Window = window;
        }

        public static void InitHol(KakaoTalkChatWindow window)
        {
            KakaoTalkChatApi.SendChatMessage(window, "홀짝게임\r\n홀 100, 짝 200 과 같이 채팅을 치면 게임을 플레이 할 수 있습니다.");
            worker = new Thread(new ThreadStart(DoWork));
            Window = window;
        }

        public static void InitStock(KakaoTalkChatWindow window)
        {
            KakaoTalkChatApi.SendChatMessage(window, StockGameEngine.Init());
            worker = new Thread(new ThreadStart(DoWork));
            Window = window;
        }

        public static void Start()
        {
            worker.Start();
            IsRunning = true;
        }

        public static void Stop()
        {
            if (worker != null)
            {
                if (worker.ThreadState == ThreadState.Running)
                {
                    worker.Join();
                }
            }
            IsRunning = false;
        }

        private static void DoWork()
        {
            while (IsRunning)
            {
                try
                {
                    Messages = KakaoTalkChatApi.GetChatMessage(Window) ?? new List<KakaoTalkChatMessage>();

                    switch (Window.BotMode)
                    {
                        case BotMode.Blind:
                            BlindMode();
                            break;

                        case BotMode.Encrypt:
                            EncryptMode();
                            break;

                        case BotMode.KoreanName:
                            KoreanNameMode();
                            break;

                        case BotMode.Parrot:
                            ParrotMode();
                            break;

                        case BotMode.Export:
                            ExportMode();
                            break;

                        case BotMode.Test:
                            AnalyzeCurrentChat();
                            break;

                        case BotMode.Chosung:
                            PlayChosungQuiz();
                            break;

                        case BotMode.StockGame:
                            PlayStockGame();
                            break;

                        case BotMode.Hol:
                            PlayHol();
                            break;

                    }

                    Thread.Sleep(WorkInterval);
                }
                catch
                {
                }
            }
        }

        enum ActionType
        {
            RispiBuy,
            RispiBuyFail,
            RispiSell,
            IrispiBuy,
            IrispiBuyFail,
            IrispiSell
        }

        private static string GmChatting(ActionType type)
        {
            int num = r.Next(5);

            switch (type)
            {
                case ActionType.RispiBuy:
                    return num switch
                    {
                        0 => "떡상 가즈아~",
                        1 => "이제 오를거임 ㅅㄱ",
                        2 => "내가 사는대로 따라 사면 무조건 수익임",
                        3 => "상승장임 매수 ㄱㄱ",
                        4 => "ㅇㅋ",
                        _ => "떡상 가즈아~",
                    };

                case ActionType.RispiBuyFail:
                    return num switch
                    {
                        0 => "ㅇㄴ 리스피 살 돈이없네",
                        1 => "ㅇㄴ",
                        2 => "리스피 좀 사게 기부좀",
                        3 => "이런 좋은 기회에 돈이 없네",
                        4 => "ㅇㅋ 일단 존버",
                        _ => "ㅇㄴ 리스피 살 돈이없네",
                    };

                case ActionType.IrispiBuy:
                    return num switch
                    {
                        0 => "인버스 사야지 ㅎㅎ",
                        1 => "이제 폭락장임 빨리 파셈",
                        2 => "인버스로 달달하게 이자나 땡겨야지",
                        3 => "인덱스 이자 너무 달달한데",
                        4 => "물량 다 던지셈",
                        _ => "인버스 사야지 ㅎㅎ",
                    };

                case ActionType.IrispiBuyFail:
                    return num switch
                    {
                        0 => "인버스 사고 싶은데 돈이 없네 ㅠ",
                        1 => "ㅇㄴ 돈점",
                        2 => "곧 폭락장인데 ㅠ",
                        3 => "인버스 사고 싶었는데 흠",
                        4 => "ㅇㅋ 일단 존버하고 본다",
                        _ => "리스피 사고 싶은데 돈이 없네 ㅠ",
                    };
            }

            return string.Empty;
        }

        public static void PlayStockGame()
        {
            string helpMessage = "잘못된 명령입니다.\n.도움말, .?를 입력하시면 도움말을 볼 수 있습니다.";
            int RefreshIntervalMinute = 3;
            int RewardIntervalHour = 1;

            //if(DateTime.Now.Minute % RefreshIntervalMinute == 0 && DateTime.Now.Second == 10)
            //{
            //    if (StockGameEngine.MarketInterestDegree <= 45) // i리스피 매수, 리스피 매도
            //    {
            //        if (StockGameEngine.GmProfile.Assets.Find(x => x.Code.Equals("101"))._Quantity > 0)
            //        {
            //            KakaoTalkChatApi.SendChatMessage(Window, ".매도 101 1000");
            //        }
            //        else
            //        {
            //            if(StockGameEngine.GmProfile.Money >= StockGameEngine.GetCurrentIrispi() * 1000)
            //            {
            //                KakaoTalkChatApi.SendChatMessage(Window, GmChatting(ActionType.IrispiBuy));
            //                KakaoTalkChatApi.SendChatMessage(Window, ".매수 102 1000");
            //            }
            //            else
            //            {
            //                KakaoTalkChatApi.SendChatMessage(Window, GmChatting(ActionType.IrispiBuyFail));
            //            }
            //        }
            //    }
            //    else if (StockGameEngine.MarketInterestDegree >= 55) // 리스피 매수, i리스피 매도
            //    {
            //        if (StockGameEngine.GmProfile.Assets.Find(x => x.Code.Equals("102"))._Quantity > 0)
            //        {
            //            KakaoTalkChatApi.SendChatMessage(Window, ".매도 102 1000");
            //        }
            //        else
            //        {
            //            if(StockGameEngine.GmProfile.Money >= StockGameEngine.GetCurrentRispi() * 1000)
            //            {
            //                KakaoTalkChatApi.SendChatMessage(Window, GmChatting(ActionType.RispiBuy));
            //                KakaoTalkChatApi.SendChatMessage(Window, ".매수 101 1000");
            //            }
            //            else
            //            {
            //                KakaoTalkChatApi.SendChatMessage(Window, GmChatting(ActionType.RispiBuyFail));
            //            }
            //        }
            //    }
            //}

            // 시장 업데이트
            if (DateTime.Now.Minute % RefreshIntervalMinute == 0 && DateTime.Now.Second <= 5 && !IsStockGameRefreshed)
            {
                IsStockGameRefreshed = true;
                StockGameEngine.GmProfile.Money *= 1.01M; // 운영자는 업데이트마다 1% 자동 수익
                KakaoTalkChatApi.SendChatMessage(Window, StockGameEngine.Refresh());
                StockGameEngine.Save();
            }

            if (DateTime.Now.Minute % RefreshIntervalMinute == 0 && DateTime.Now.Second > 6 && IsStockGameRefreshed)
            {
                IsStockGameRefreshed = false;
            }

            // 이자 지급 + 세금 납세
            if (DateTime.Now.Hour % RewardIntervalHour == 0 && DateTime.Now.Minute == 0 && DateTime.Now.Second <= 5 && !IsStockGameRewarded)
            {
                IsStockGameRewarded = true;
                KakaoTalkChatApi.SendChatMessage(Window, StockGameEngine.Reward());
                KakaoTalkChatApi.SendChatMessage(Window, StockGameEngine.Tax());
                StockGameEngine.Save();
            }

            if (DateTime.Now.Hour % RewardIntervalHour == 0 && DateTime.Now.Minute == 0 && DateTime.Now.Second > 6 && IsStockGameRewarded)
            {
                IsStockGameRewarded = false;
            }

            // 주말엔 매매 수수료 1%, 평일 2%
            StockGameEngine.Fee = DateTime.Today.DayOfWeek == DayOfWeek.Saturday || DateTime.Today.DayOfWeek == DayOfWeek.Sunday ? 1.0M : 2.0M;

            for (int i = pointerIndex; i < Messages.Count; i++, pointerIndex++)
            {
                if (i <= InitMessasgeCount)
                {
                    continue;
                }
                var message = Messages[i];
                if (message.Type == MessageType.Talk && message.Content.StartsWith('.'))
                {
                    var data = message.Content.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    switch (data[0])
                    {
                        case ".도움말":
                        case ".?":
                            KakaoTalkChatApi.SendChatMessage(Window, StockGameEngine.Help());
                            break;

                        case ".매매":
                            KakaoTalkChatApi.SendChatMessage(Window, StockGameEngine.HelpTrading());
                            break;

                        case ".정보":
                        case ".나":
                        case ".":
                            KakaoTalkChatApi.SendChatMessage(Window, StockGameEngine.Info(message.UserName));
                            break;

                        case ".계좌개설":
                            KakaoTalkChatApi.SendChatMessage(Window, StockGameEngine.New(message.UserName));
                            break;

                        case ".현재":
                            KakaoTalkChatApi.SendChatMessage(Window, StockGameEngine.Current());
                            break;

                        case ".랭킹":
                            KakaoTalkChatApi.SendChatMessage(Window, StockGameEngine.AssetRanking());
                            break;

                        case ".매수":
                            if (data.Length != 3)
                            {
                                pointerIndex++;
                                KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                return;
                            }
                            if (data[2].EndsWith("."))
                            {
                                if (int.TryParse(data[2].AsSpan(0, data[2].Length - 1), out int percent))
                                {
                                    if (data[1].Length == 3)
                                    {
                                        string result = StockGameEngine.BuyIndexPer(data[1], message.UserName, percent);
                                        KakaoTalkChatApi.SendChatMessage(Window, result);
                                        StockGameEngine.Save();
                                    }
                                    else
                                    {
                                        string result = StockGameEngine.BuyPer(data[1], message.UserName, percent);
                                        KakaoTalkChatApi.SendChatMessage(Window, result);
                                        StockGameEngine.Save();
                                    }
                                }
                                else
                                {
                                    pointerIndex++;
                                    KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                    return;
                                }
                            }
                            else if (decimal.TryParse(data[2], out decimal quantity))
                            {
                                quantity = System.Math.Round(quantity);

                                if (data[1].Length == 3)
                                {
                                    string result = StockGameEngine.BuyIndex(data[1], message.UserName, quantity);
                                    KakaoTalkChatApi.SendChatMessage(Window, result);
                                    StockGameEngine.Save();
                                }
                                else
                                {
                                    string result = StockGameEngine.Buy(data[1], message.UserName, quantity);
                                    KakaoTalkChatApi.SendChatMessage(Window, result);
                                    StockGameEngine.Save();
                                }
                            }
                            else
                            {
                                pointerIndex++;
                                KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                return;
                            }
                            break;

                        case ".ㅅ":
                            if (data.Length != 2)
                            {
                                pointerIndex++;
                                KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                return;
                            }

                            string buy_result = data[1].Length == 3 ?
                                StockGameEngine.BuyIndexPer(data[1], message.UserName, 100) :
                                StockGameEngine.BuyPer(data[1], message.UserName, 100);

                            KakaoTalkChatApi.SendChatMessage(Window, buy_result);
                            StockGameEngine.Save();
                            break;

                        case ".매도":
                            if (data.Length != 3)
                            {
                                pointerIndex++;
                                KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                return;
                            }
                            if (data[2].EndsWith("."))
                            {
                                if (int.TryParse(data[2].AsSpan(0, data[2].Length - 1), out int percent2))
                                {
                                    if (data[1].Length == 3)
                                    {
                                        string result = StockGameEngine.SellIndexPer(data[1], message.UserName, percent2);
                                        KakaoTalkChatApi.SendChatMessage(Window, result);
                                        StockGameEngine.Save();
                                    }
                                    else
                                    {
                                        string result = StockGameEngine.SellPer(data[1], message.UserName, percent2);
                                        KakaoTalkChatApi.SendChatMessage(Window, result);
                                        StockGameEngine.Save();
                                    }
                                }
                                else
                                {
                                    pointerIndex++;
                                    KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                    return;
                                }
                            }
                            else if (decimal.TryParse(data[2], out decimal quantity2))
                            {
                                quantity2 = System.Math.Round(quantity2);

                                if (data[1].Length == 3)
                                {
                                    string result = StockGameEngine.SellIndex(data[1], message.UserName, quantity2);
                                    KakaoTalkChatApi.SendChatMessage(Window, result);
                                    StockGameEngine.Save();
                                }
                                else
                                {
                                    string result = StockGameEngine.Sell(data[1], message.UserName, quantity2);
                                    KakaoTalkChatApi.SendChatMessage(Window, result);
                                    StockGameEngine.Save();
                                }
                            }
                            else
                            {
                                pointerIndex++;
                                KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                return;
                            }
                            break;

                        case ".ㄷ":
                            if (data.Length != 2)
                            {
                                pointerIndex++;
                                KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                return;
                            }

                            string sell_result = data[1].Length == 3 ?
                                StockGameEngine.SellIndexPer(data[1], message.UserName, 100) :
                                StockGameEngine.SellPer(data[1], message.UserName, 100);

                            KakaoTalkChatApi.SendChatMessage(Window, sell_result);
                            StockGameEngine.Save();
                            break;

                        case ".롱":
                            if (data.Length != 2)
                            {
                                pointerIndex++;
                                KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                return;
                            }
                            if (data[1].EndsWith("."))
                            {
                                if (int.TryParse(data[1].AsSpan(0, data[1].Length - 1), out int percent3))
                                {
                                    var longResult = StockGameEngine.Long(message.UserName, percent3);
                                    KakaoTalkChatApi.SendChatMessage(Window, longResult);
                                }
                            }
                            else
                            {
                                pointerIndex++;
                                KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                return;
                            }
                            break;

                        case ".숏":
                            if (data.Length != 2)
                            {
                                pointerIndex++;
                                KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                return;
                            }
                            if (data[1].EndsWith("."))
                            {
                                if (int.TryParse(data[1].AsSpan(0, data[1].Length - 1), out int percent4))
                                {
                                    var shortResult = StockGameEngine.Short(message.UserName, percent4);
                                    KakaoTalkChatApi.SendChatMessage(Window, shortResult);
                                }
                            }
                            else
                            {
                                pointerIndex++;
                                KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                                return;
                            }
                            break;

                        default:
                            pointerIndex++;
                            KakaoTalkChatApi.SendChatMessage(Window, helpMessage);
                            return;
                    }

                }
                Thread.Sleep(10);
            }
        }

        public static void PlayChosungQuiz()
        {
            if (quizzing)
            {
                for (int i = pointerIndex; i < Messages.Count; i++, pointerIndex++)
                {
                    if (i <= InitMessasgeCount)
                    {
                        continue;
                    }
                    var message = Messages[i];
                    if (message.Type == MessageType.Talk)
                    {
                        var nickname = message.UserName;
                        if (message.Content.Equals("패스"))
                        {
                            var userScore = ChosungQuiz.GetUserScore(nickname);
                            if (userScore <= 0)
                            {
                                KakaoTalkChatApi.SendChatMessage(Window, $"{nickname}님의 골드가 부족합니다.");
                                continue;
                            }

                            var score = 0;
                            var passUser = ChosungQuiz.PassUsers.Find(x => x.Nickname.Equals(nickname));
                            if (passUser == null) // 첫 패스자
                            {
                                ChosungQuiz.PassUsers.Add(new PassUser(nickname, -25, DateTime.Now));
                                score = -25;
                            }
                            else // 이전 패스기록이 있는 패스자
                            {
                                if ((DateTime.Now - passUser.Time).TotalSeconds < 10) // 10초 이내에 재패스 시 추가 패널티
                                {
                                    passUser.Penalty -= 0;
                                    passUser.Time = DateTime.Now;
                                    score = passUser.Penalty;
                                }
                                else // 정상적인 패스자
                                {
                                    passUser.Time = DateTime.Now;
                                    score = -25;
                                }
                            }

                            quizzing = false;
                            var resultScore = ChosungQuiz.UpdateScore(message.UserName, score);
                            KakaoTalkChatApi.SendChatMessage(Window, $"[패스] 정답: {ChosungQuiz.CurrentQuiz.Answer}, 패스자: {nickname}, 골드: {resultScore}({score})");
                            continue;
                        }

                        if (message.Content.Equals("랭킹"))
                        {
                            var rankingInfo = ChosungQuiz.GetScoreInfo();
                            KakaoTalkChatApi.SendChatMessage(Window, rankingInfo);
                            continue;
                        }

                        (var result, var answer) = ChosungQuiz.TryAnswer(message.Content);
                        if (result)
                        {
                            quizzing = false;
                            var score = (30 + 10 * answer.Trim().Replace(" ", "").Length) * (ChosungQuiz.IsRandomTitle ? 5 : 1);
                            if (answer.Trim().Length == 1)
                            {
                                score = 250 * (ChosungQuiz.IsRandomTitle ? 5 : 1);
                            }
                            var resultScore = ChosungQuiz.UpdateScore(nickname, score);
                            KakaoTalkChatApi.SendChatMessage(Window, $"정답: {answer}, 정답자: {nickname}, 골드: {resultScore}(+{score})");
                        }
                    }
                    Thread.Sleep(10);
                }
            }
            else
            {
                quizzing = true;
                KakaoTalkChatApi.SendChatMessage(Window, $"{ChosungQuiz.GetQuestion()}");
            }
        }

        public static void PlayHol()
        {
            for (int i = pointerIndex; i < Messages.Count; i++, pointerIndex++)
            {
                if (i <= InitMessasgeCount)
                {
                    continue;
                }
                var message = Messages[i];
                if (message.Type == MessageType.Talk)
                {
                    var seg = message.Content.Split(' ');
                    if (seg.Length == 2)
                    {
                        if ((seg[0] == "홀" || seg[0] == "짝") && int.TryParse(seg[1], out var bet))
                        {
                            if (!HolAccounts.ContainsKey(message.UserName)) // 신입
                            {
                                HolAccounts.Add(message.UserName, 1000);
                                KakaoTalkChatApi.SendChatMessage(Window, $"{message.UserName}님 등록 완료. 1,000원 지급.");
                                continue;
                            }

                            if (HolAccounts[message.UserName] < bet)
                            {
                                KakaoTalkChatApi.SendChatMessage(Window, $"{message.UserName}님 남은 돈 {HolAccounts[message.UserName]:#,###}");
                                continue;
                            }

                            var answer = r.Next(2) == 0 ? "홀" : "짝";
                            if (seg[0].Equals(answer)) // 정답
                            {
                                HolAccounts[message.UserName] += bet;
                                KakaoTalkChatApi.SendChatMessage(Window, $"{answer}!! {message.UserName}님 돈 {HolAccounts[message.UserName]:#,###}(+{bet:#,###})");
                            }
                            else // 오답
                            {
                                HolAccounts[message.UserName] -= bet;
                                KakaoTalkChatApi.SendChatMessage(Window, $"{answer};; {message.UserName}님 돈 {HolAccounts[message.UserName]:#,###}(-{bet:#,###})");
                            }
                        }
                    }
                }
                Thread.Sleep(10);
            }
        }

        public static void AnalyzeCurrentChat()
        {
            var chatRoomImages = new List<Bitmap>();
            var rect = KakaoTalkChatApi.GetChatListRect(Window);

            var chatWindowBitmap = ScreenShot.Take(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
            var profileBitmap = chatWindowBitmap.CropImage(new Rectangle(14, 55, ProfileSize, chatWindowBitmap.Height - 55));
            var chatBitmap = chatWindowBitmap.CropImage(new Rectangle(14 + profileBitmap.Width, 55, chatWindowBitmap.Width - profileBitmap.Width - 30, chatWindowBitmap.Height - 55));

            var profileColor = profileBitmap.GetPixelColor2D();
            var chatColor = chatBitmap.GetPixelColor2D();

            /* Profile */
            CurrentProfileCount = 0;
            using (Graphics g = Graphics.FromImage(profileBitmap))
            {
                for (int i = 0; i < profileBitmap.Height - ProfileSize; i += 3)
                {
                    var targetColor = profileColor.Split(0, i, ProfileSize, ProfileSize);
                    if (targetColor.Cast<Color>().Where(x => x.IsGrayColor(1) && x.IsBlack(50)).Count() < targetColor.Length * 0.25)
                    {
                        Pen pen = new Pen(Brushes.Red, 1);
                        g.DrawRectangle(pen, new Rectangle(0, i, ProfileSize - 1, ProfileSize - 1));
                        i += ProfileSize;
                        CurrentProfileCount++;
                    }
                }
            }
            chatRoomImages.Add(profileBitmap);

            /* Chat */
            CurrentChatCount = 0;
            using (Graphics g = Graphics.FromImage(chatBitmap))
            {
                for (int i = 0; i < chatBitmap.Height - ChatHeight; i += 3)
                {
                    var targetColor = chatColor.Split(10, i, ChatWidth, ChatHeight);
                    var isChat = false;
                    // Horizontal inspection
                    while (targetColor.Cast<Color>().Where(x => x.IsGrayColor(1) && x.IsWhite(100)).Count() > targetColor.Length * 0.8)
                    {
                        isChat = true;
                        targetColor = chatColor.Split(10, i, targetColor.GetLength(0) + 5, targetColor.GetLength(1));
                    }

                    if (isChat)
                    {
                        targetColor = chatColor.Split(10, i, targetColor.GetLength(0), targetColor.GetLength(1) + 5);
                        var target2Color = chatColor.Split(10, i + targetColor.GetLength(1), targetColor.GetLength(0), 3);

                        int p = 1;
                        int lastChatHeight = ChatHeight;
                        // Vertical inspection
                        while (target2Color.Cast<Color>().Where(x => x.IsGrayColor(1) && x.IsBlack(50)).Count() < targetColor.Length * 0.05)
                        {
                            if (i + ChatHeightMultiLine(p) + 3 > chatBitmap.Height)
                            {
                                lastChatHeight = chatBitmap.Height - i - 4;
                                break;
                            }
                            else
                            {
                                lastChatHeight = ChatHeightMultiLine(p);
                            }

                            target2Color = chatColor.Split(10, i + lastChatHeight, target2Color.GetLength(0), 3);
                            p++;
                        }
                        Pen pen = new Pen(Brushes.Red, 1);
                        g.DrawRectangle(pen, new Rectangle(10, i, target2Color.GetLength(0) - 1, lastChatHeight - 1));
                        i += lastChatHeight;
                        CurrentChatCount++;
                    }
                }
            }
            chatRoomImages.Add(chatBitmap);

            /* Merge */
            ChatRoomImage = chatRoomImages.Merge(MergeType.Horizontal);
        }

        public static void ExportMode()
        {
            var rect = KakaoTalkChatApi.GetChatListRect(Window);

            //ScreenShot.SaveAsFile(rect.left + 14, rect.top, 43, rect.bottom - rect.top, "C:\\", "aa.png", ImageFormat.Png);

            int width = 43;
            int height = rect.bottom - rect.top;
            int profileSize = width;
            var profileSection = ScreenShot.Take(rect.left + 14, rect.top, width, height);
            var colors = profileSection.GetPixelColor2D();

            using (Graphics g = Graphics.FromImage(profileSection))
            {
                for (int i = 0; i < height - profileSize; i += 3)
                {
                    var pixelLength = profileSize * profileSize;
                    var targetColors = colors.Split(0, i, profileSize, profileSize);
                    //var targetColors = colors.Skip(i * width).Take(pixelLength);
                    if (targetColors.Cast<Color>().Where(x => x.IsBlack(50)).Count() < pixelLength * 0.35)
                    {
                        Pen pen = new Pen(Brushes.Red, 1);
                        g.DrawRectangle(pen, new Rectangle(0, i, profileSize - 1, profileSize - 1));

                        // profile picture click
                        InputSimulator.MouseClick(rect.left + width / 2 + 5, rect.top + i + width / 2 + 5);

                        // check yellow crown
                        //int crownSize = 30;
                        //var crownSection = ScreenShot.Take(rect.left - 200, rect.top + i + width / 2 - 40, crownSize, crownSize);
                        //crownSection.Save("C:\\AATEST\\CROWN.png");

                        // export click
                        i += profileSize;
                    }
                }
            }

            //profileSection.Save("C:\\BB.png");
        }

        public static void ParrotMode()
        {
            for (int i = pointerIndex; i < Messages.Count; i++, pointerIndex++)
            {
                if (i <= InitMessasgeCount)
                {
                    continue;
                }
                var message = Messages[i];
                if (message.Type == MessageType.Talk && message.UserName != Window.MyNickname)
                {
                    KakaoTalkChatApi.SendChatMessage(Window, message.Content);
                }
                Thread.Sleep(10);
            }
        }

        public static void EncryptMode()
        {
            for (int i = pointerIndex; i < Messages.Count; i++, pointerIndex++)
            {
                if (i <= InitMessasgeCount)
                {
                    continue;
                }
                var message = Messages[i];
                if (message.Type == MessageType.Talk && message.UserName != Window.MyNickname)
                {
                    var builder = new StringBuilder();
                    for (int j = 0; j < message.Content.Length; j++)
                    {
                        builder.Append(message.Content[r.Next(message.Content.Length)].ToString());
                    }
                    string newMessage = builder.ToString();
                    KakaoTalkChatApi.SendChatMessage(Window, newMessage);
                }
                Thread.Sleep(10);
            }
        }

        public static void KoreanNameMode()
        {
            for (int i = pointerIndex; i < Messages.Count; i++, pointerIndex++)
            {
                if (i <= InitMessasgeCount)
                {
                    continue;
                }
                var message = Messages[i];
                if (message.Type == MessageType.Talk && message.UserName != Window.MyNickname)
                {
                    string newMessage = Dummy.OfKoreanName();
                    KakaoTalkChatApi.SendChatMessage(Window, newMessage);
                }
                Thread.Sleep(10);
            }
        }

        public static void BlindMode()
        {
            var rect = KakaoTalkChatApi.GetChatListRect(Window);

            //for (int i = pointerIndex; i < Messages.Count; i++, pointerIndex++)
            int i = Messages.Count - 1;

            {
                if (i <= InitMessasgeCount)
                {
                    return;
                }
                var message = Messages[i];
                if (message.Type == MessageType.Talk && message.UserName != Window.MyNickname && !IsAdmin(message.UserName))
                {
                    InputSimulator.MouseClick(rect.left + 70, rect.bottom - 10);
                    Thread.Sleep(20);
                    InputSimulator.MouseRightClick(rect.left + 70, rect.bottom - 10);
                    Thread.Sleep(300);
                    InputSimulator.MouseClick(rect.left + 90, rect.bottom + 215);
                    Thread.Sleep(300);
                    InputSimulator.MouseClick(rect.left + 200, rect.bottom + 215);
                    Thread.Sleep(300);
                    InputSimulator.MouseClick(rect.left + 70, rect.bottom - 30);

                    //KakaoTalkChatApi.SendChatMessage(Window, message.Content);
                }
                Thread.Sleep(10);
            }
        }

        public static bool IsAdmin(string nickname)
        {
            return Window.AdminNicknames.Contains(nickname);
        }

        public static List<KakaoTalkChatMessage> SearchByKeyword(string keyword)
        {
            return Messages.FindAll(x => x.Content.Contains(keyword));
        }

        public static List<KakaoTalkChatMessage> SearchByUserName(string userName)
        {
            return Messages.FindAll(x => x.UserName.Equals(userName));
        }

        public static List<KakaoTalkChatMessage> SearchByMessageType(MessageType messageType)
        {
            return Messages.FindAll(x => x.Type.Equals(messageType));
        }
    }
}
