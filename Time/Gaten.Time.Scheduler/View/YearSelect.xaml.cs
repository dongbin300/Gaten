using Gaten.Time.Scheduler.Data;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gaten.Time.Scheduler.View
{
    /// <summary>
    /// YearSelect.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class YearSelect : UserControl
    {
        int n1, n2, n3, n4, year;

        public YearSelect()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            year = CalendarCreator.SelectedDate.Year;
            n1 = year / 1000;
            n2 = year % 1000 / 100;
            n3 = year % 100 / 10;
            n4 = year % 10;

            RefreshText();
        }

        void RefreshText()
        {
            N1Text.Text = n1.ToString();
            N2Text.Text = n2.ToString();
            N3Text.Text = n3.ToString();
            N4Text.Text = n4.ToString();
        }

        private void UpDown_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string text = (sender as FrameworkElement).Name.Substring(0, 2);

            switch (text)
            {
                case "U1": n1++; n1 %= 10; break;
                case "U2": n2++; n2 %= 10; break;
                case "U3": n3++; n3 %= 10; break;
                case "U4": n4++; n4 %= 10; break;
                case "D1": n1--; n1 = (n1 + 10) % 10; break;
                case "D2": n2--; n2 = (n2 + 10) % 10; break;
                case "D3": n3--; n3 = (n3 + 10) % 10; break;
                case "D4": n4--; n4 = (n4 + 10) % 10; break;
            }

            RefreshText();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            year = n1 * 1000 + n2 * 100 + n3 * 10 + n4;

            if(year < CalendarCreator.MIN_YEAR || year > CalendarCreator.MAX_YEAR)
            {
                MessageBox.Show($"{CalendarCreator.MIN_YEAR}년 부터 {CalendarCreator.MAX_YEAR}년 까지만 설정 가능합니다.");
                return;
            }

            CalendarCreator.SetSelectYear(year);
            ViewManager.MainWindow.Refresh();
            ViewManager.MainWindow.SetContent(ViewManager.Calendar);
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.MainWindow.SetContent(ViewManager.Calendar);
        }
    }
}
