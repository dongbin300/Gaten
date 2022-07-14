using Gaten.Net.Image;
using Gaten.Net.Extension;

using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using Gaten.Net.Data.Math;
using System.Text;

namespace Gaten.Net.Windows.KakaoTalk.Chat
{
    public class KakaoTalkChatBot
    {
        public static bool IsRunning { get; private set; }
        public static KakaoTalkChatWindow Window { get; set; }
        public static List<KakaoTalkChatMessage> Messages { get; private set; }
        //static System.Timers.Timer timer = new System.Timers.Timer(2000);
        static Thread worker;
        private static int pointerIndex = 0;
        private readonly static int InitMessasgeCount = 8;
        private static SmartRandom r = new SmartRandom();

        public KakaoTalkChatBot()
        {

        }

        public static void Init(KakaoTalkChatWindow window)
        {
            Messages = new List<KakaoTalkChatMessage>();
            //timer.Elapsed += Timer_Elapsed;
            worker = new Thread(new ThreadStart(DoWork));
            Window = window;
        }

        public static void Start()
        {
            //pointerIndex = 0;
            //timer.Start();
            worker.Start();
            IsRunning = true;
        }

        public static void Stop()
        {
            //timer.Stop();
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
                    }

                    Thread.Sleep(2000);
                }
                catch
                {
                }
            }
        }

        //private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        //{

        //}

        public static void ExportMode()
        {
            var rect = KakaoTalkChatApi.GetChatListRect(Window);

            //ScreenShot.SaveAsFile(rect.left + 14, rect.top, 43, rect.bottom - rect.top, "C:\\AATEST\\", "aa.png", ImageFormat.Png);

            int width = 43;
            int height = rect.bottom - rect.top;
            int profileSize = width;
            var profileSection = ScreenShot.Take(rect.left + 14, rect.top, width, height);
            var colors = profileSection.GetPixelColor();

            //using (Graphics g = Graphics.FromImage(profileSection))
            {
                for (int i = 0; i < height - profileSize; i += 3)
                {
                    var pixelLength = profileSize * profileSize;
                    var targetColors = colors.Skip(i * width).Take(pixelLength);
                    if (targetColors.Where(x => x.IsBlack(50)).Count() < pixelLength * 0.35)
                    {
                        //Pen pen = new Pen(Brushes.Red, 1);
                        //g.DrawRectangle(pen, new Rectangle(0, i, profileSize - 1, profileSize - 1));

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

            //profileSection.Save("C:\\AATEST\\BB.png");


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
