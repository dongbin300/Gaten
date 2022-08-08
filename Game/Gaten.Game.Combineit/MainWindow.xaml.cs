using Gaten.Game.Combineit.Base;

using System;
using System.Windows;
using System.Windows.Threading;

namespace Gaten.Game.Combineit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static bool IntroEnd;
        //Thread timingWorker;

        private readonly DispatcherTimer t;

        public MainWindow()
        {
            InitializeComponent();

            LoadResources();

            // 1틱 = 50ms(40ms로 설정하면 대략 50ms로 실행됨), 1초 = 20틱
            // 제작/생산 시간은 0.05s 단위로 설정됨
            t = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 40), DispatcherPriority.Background, t_Tick, Dispatcher.CurrentDispatcher)
            {
                IsEnabled = true
            };
        }

        private void LoadResources()
        {
            _ = new ItemDictionary();
            _ = new Character();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InventoryBox.ItemsSource = Character.PossessionItems;
            ManualBox.ItemsSource = ItemDictionary.Items;
        }

        private void t_Tick(object sender, EventArgs e)
        {
            TickMaster.Tick(tickMs: 50);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Character.Save();
        }

        //public void ShowIntro()
        //{
        //    Intro intro = new Intro();
        //    intro.Show();
        //}

        //public void Timing()
        //{
        //    while (true)
        //    {
        //        Thread.Sleep(50);

        //        if (IntroEnd)
        //        {
        //            ShowMain();
        //            IntroEnd = false;
        //            break;
        //        }
        //    }
        //}

        //public void ShowMain()
        //{

        //}

        //private void Window_Closed(object sender, EventArgs e)
        //{
        //    if(timingWorker != null)
        //    {
        //        timingWorker.Abort();
        //    }
        //}
    }
}
