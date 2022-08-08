using Gaten.Net.Extensions;
using Gaten.Net.Image;
using Gaten.Net.Math;

using System.Drawing;
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
        private static int ChatHeightMultiLine(int lineCount) => ChatHeight + (lineCount - 1) * 18;

        public static Bitmap ChatRoomImage { get; set; } = default!;

        public KakaoTalkChatBot()
        {

        }

        public static void Init(KakaoTalkChatWindow window)
        {
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
                    }

                    Thread.Sleep(WorkInterval);
                }
                catch
                {
                }
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
                            if(i + ChatHeightMultiLine(p) + 3 > chatBitmap.Height)
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
                    for(int j = 0; j < message.Content.Length; j++)
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
