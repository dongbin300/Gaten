using Gaten.Net.Math;
using Gaten.Net.Windows.KakaoTalk.Chat;
using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Extensions;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

using static Gaten.Net.Windows.WinApi;

namespace Gaten.Windows.MintKakao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KakaoTalkChatWindow window = new();
        List<KakaoTalkChatMessage> latestMessages = new();
        System.Timers.Timer mainTimer = new(500);

        public MainWindow()
        {
            InitializeComponent();

            RoomNameTextBox.Text = Settings.Default.TargetRoomName;
            MyNicknameTextBox.Text = Settings.Default.MyNickname;
            AdminTextBox1.Text = Settings.Default.AdminNickname1;
            AdminTextBox2.Text = Settings.Default.AdminNickname2;
            AdminTextBox3.Text = Settings.Default.AdminNickname3;
            AdminTextBox4.Text = Settings.Default.AdminNickname4;
            AdminTextBox5.Text = Settings.Default.AdminNickname5;
            MonitorIntervalTextBox.Text = Settings.Default.MonitorInterval;

            mainTimer.Elapsed += MainTimer_Elapsed;
            mainTimer.Start();
        }

        private void MainTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DispatcherService.Invoke(() =>
            {
                if (int.TryParse(MonitorIntervalTextBox.Text, out int interval))
                {
                    KakaoTalkChatBot.WorkInterval = interval;
                }
                else
                {
                    KakaoTalkChatBot.WorkInterval = 2000;
                }
                
                DebugText.Text = $"{KakaoTalkChatBot.CurrentProfileCount}명, {KakaoTalkChatBot.CurrentChatCount}개";

                if (KakaoTalkChatBot.ChatRoomImage != null)
                {
                    ChatRoomMonitorImage.Source = KakaoTalkChatBot.ChatRoomImage.ToImageSource();
                }
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KakaoTalkChatBot.Stop();
            mainTimer.Stop();

            Settings.Default.TargetRoomName = RoomNameTextBox.Text;
            Settings.Default.MyNickname = MyNicknameTextBox.Text;
            Settings.Default.AdminNickname1 = AdminTextBox1.Text;
            Settings.Default.AdminNickname2 = AdminTextBox2.Text;
            Settings.Default.AdminNickname3 = AdminTextBox3.Text;
            Settings.Default.AdminNickname4 = AdminTextBox4.Text;
            Settings.Default.AdminNickname5 = AdminTextBox5.Text;
            Settings.Default.MonitorInterval = MonitorIntervalTextBox.Text;
            Settings.Default.Save();
        }
        
        private void SendMacroButton1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KakaoTalkChatApi.SendChatMessage(window, SendMacroTextBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendMacroButton2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KakaoTalkChatApi.SendChatMessage(window, SendMacroTextBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendMacroButton3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KakaoTalkChatApi.SendChatMessage(window, SendMacroTextBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BotStartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(sender is not Button button)
                {
                    return;
                }
                var tag = button.Tag.ToString();

                if (KakaoTalkChatBot.IsRunning)
                {
                    KakaoTalkChatBot.Stop();
                    button.Content = tag switch
                    {
                        "Parrot" => "앵무새",
                        "Blind" => "가리기",
                        "Export" => "내보내기",
                        "Encrypt" => "랜덤",
                        "KoreanName" => "이름",
                        "Test" => "테스트",
                        "Hol" => "홀짝게임",
                        _ => "에러"
                    };
                    MainBorder.BorderBrush = new SolidColorBrush(Colors.White);
                }
                else
                {
                    var windows = KakaoTalkChatApi.GetChatWindows(RoomNameTextBox.Text);

                    if (windows.Count == 0)
                    {
                        MessageBox.Show("방 정보를 얻지 못했어요. 카톡방을 열고 다시 시도 해 주세요.");
                        return;
                    }

                    window = windows[0];
                    window.MyNickname = MyNicknameTextBox.Text;
                    window.AdminNicknames = new List<string>
                    {
                        AdminTextBox1.Text,
                        AdminTextBox2.Text,
                        AdminTextBox3.Text,
                        AdminTextBox4.Text,
                        AdminTextBox5.Text
                    };
                    window.BotMode = (BotMode)Enum.Parse(typeof(BotMode), tag);
                    switch (window.BotMode)
                    {
                        case BotMode.Hol:
                            KakaoTalkChatBot.InitHol(window);
                            break;
                        case BotMode.Chosung:
                            KakaoTalkChatBot.InitChosung(window);
                            break;
                        case BotMode.StockGame:
                            KakaoTalkChatBot.InitStock(window);
                            break;
                        default:
                            KakaoTalkChatBot.Init(window);
                            break;
                    }
                    KakaoTalkChatBot.Start();
                    button.Content = "중지";
                    MainBorder.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
