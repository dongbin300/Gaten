using Gaten.Net.Windows.KakaoTalk.Chat;
using Gaten.Net.Wpf;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gaten.Windows.MintKakao
{
    /// <summary>
    /// BotWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BotWindow : Window
    {
        KakaoTalkChatWindow window = new();
        List<KakaoTalkChatMessage> latestMessages = new();
        System.Timers.Timer mainTimer = new(500);

        public BotWindow()
        {
            InitializeComponent();

            RoomNameTextBox.Text = Settings.Default.TargetRoomName;
            MyNicknameTextBox.Text = Settings.Default.MyNickname;
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
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KakaoTalkChatBot.Stop();
            mainTimer.Stop();

            Settings.Default.TargetRoomName = RoomNameTextBox.Text;
            Settings.Default.MyNickname = MyNicknameTextBox.Text;
            Settings.Default.MonitorInterval = MonitorIntervalTextBox.Text;
            Settings.Default.Save();
        }

        private void BotStartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is not Button button)
                {
                    return;
                }
                var tag = button.Tag.ToString();

                if (KakaoTalkChatBot.IsRunning)
                {
                    KakaoTalkChatBot.Stop();
                    button.Content = tag switch
                    {
                        "Chosung" => "초성퀴즈",
                        "StockGame" => "주식게임",
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
                    window.BotMode = (BotMode)Enum.Parse(typeof(BotMode), tag);
                    switch (button.Tag)
                    {
                        case "Chosung":
                            KakaoTalkChatBot.InitChosung(window);
                            break;

                        case "StockGame":
                            KakaoTalkChatBot.InitStock(window);
                            break;

                        case "Hol":
                            KakaoTalkChatBot.InitHol(window);
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
