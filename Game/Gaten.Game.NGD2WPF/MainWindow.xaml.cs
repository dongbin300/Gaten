using Gaten.Game.NGD2WPF.View;
using Gaten.Net.GameRule.NGD2;
using Gaten.Net.GameRule.NGD2.AbilitySystem;
using Gaten.Net.GameRule.NGD2.UISystem;

using System;
using System.Windows;
using System.Windows.Input;

namespace Gaten.Game.NGD2WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StatusView statusView;
        private SpiritView spiritView;
        private System.Timers.Timer timer;
        private long xpBeforeAttack = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 노가다게임 매니저 게임 시작
            NGDManager.GameStart();

            statusView = new StatusView();
            spiritView = new SpiritView();

            Refresh();

            // 타이머 시작
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            xpBeforeAttack = Character.Xp;
            Character.Attack();

            Refresh();
        }

        void Refresh()
        {
            Character.Calculate();

            _ = Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
            {
                timer.Interval = 15; // Character.Effect.AttackSpeedIM;

                LevelText.Text = "레벨 " + Character.Level;
                XpText.Text = $"{Display(Character.Xp)} / {Display(Character.RequireXp)} ({Character.XpPercent:0.00}%)";
                XpBarBorder1.Offset = XpBarBorder2.Offset = Character.XpPercent / 100;
                XpChangeText.Text = "+" + Display(Character.Xp - xpBeforeAttack);
                MpText.Text = $"{Display(Character.Mp)}";
                MpBarBorder1.Offset = MpBarBorder2.Offset = Character.MpPercent / 100;
                SpiritText.Text = Display(Spirit.Value);

                /* 컨텐츠 새로고침 */
                SpiritBorder.Visibility = Character.Level >= Spirit.RequireLevel ? Visibility.Visible : Visibility.Collapsed;

                /* 서브 뷰 새로고침 */
                if (CurrentControl.Content == statusView)
                {
                    statusView.Refresh();
                }

                /* 로그 새로고침 */
                if (LogQueue.Have())
                {
                    Log? log = LogQueue.Get();
                    _ = LogBox.Items.Add($"[{log.Time:HH:mm:ss}] {log.Text}");
                    LogBox.Items.MoveCurrentToLast();
                    LogBox.ScrollIntoView(LogBox.Items.CurrentItem);
                }
            }));
        }

        public static string Display(int value) => value.ToString("#,#;#,#;0");

        public static string Display(long value) => value.ToString("#,#;#,#;0");

        private void Window_Closed(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
        }

        public void SetCurrentControl(object obj)
        {
            CurrentControl.Content = obj;
        }

        private void CharacterBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SetCurrentControl(statusView);
        }

        private void SpiritBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SetCurrentControl(spiritView);
        }
    }
}
