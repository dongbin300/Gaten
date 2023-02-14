using Gaten.Net.IO;
using Gaten.Net.Network;
using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Extensions;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// MonitorTicker.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MonitorTicker : Window
    {
        private List<string> stocks = new List<string>();
        private string symbol = string.Empty;
        private System.Timers.Timer timer = new System.Timers.Timer();

        public MonitorTicker()
        {
            InitializeComponent();
            Left = 1700;
            Top = 900;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int euckrCodePage = 51949;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodePage);

            stocks = GResource.GetTextLines("monitor_stock.txt").ToList();

            timer.Interval = 200;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DispatcherService.Invoke(() =>
            {
                MainGrid.Children.Clear();
            });
            timer.Interval = 60000;
            for (int i = 0; i < stocks.Count; i++)
            {
                WebCrawler.Open($"https://finance.naver.com/item/main.naver?code={stocks[i]}");
                var source = WebCrawler.Source;
                var stockTitleSegments = WebCrawler.SelectNode("div", "class", "wrap_company").InnerText.Replace("\t", "").Split("\n", System.StringSplitOptions.RemoveEmptyEntries);
                var segments = WebCrawler.SelectNode("div", "class", "today").InnerText.Replace("\t", "").Split("\n", System.StringSplitOptions.RemoveEmptyEntries);

                DispatcherService.Invoke(() =>
                {
                    TextBlock textBlock1 = new TextBlock
                    {
                        FontSize = 11,
                        FontFamily = new FontFamily("Verdana"),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        FontWeight = FontWeights.Bold,
                        Text = stockTitleSegments[0]
                    };

                    TextBlock textBlock2 = new TextBlock
                    {
                        FontSize = 11,
                        FontFamily = new FontFamily("Verdana"),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Text = segments[0],
                        Foreground = segments[7] == "+" ? new SolidColorBrush(Color.FromRgb(59, 207, 134)) : new SolidColorBrush(Color.FromRgb(237, 49, 97))
                    };

                    TextBlock textBlock3 = new TextBlock
                    {
                        FontSize = 11,
                        FontFamily = new FontFamily("Verdana"),
                        HorizontalAlignment = HorizontalAlignment.Right,
                        Text = segments[7] + segments[8] + segments[10],
                        Foreground = segments[7] == "+" ? new SolidColorBrush(Color.FromRgb(59, 207, 134)) : new SolidColorBrush(Color.FromRgb(237, 49, 97))
                    };

                    textBlock1.SetValue(Grid.RowProperty, i);
                    textBlock2.SetValue(Grid.RowProperty, i);
                    textBlock3.SetValue(Grid.RowProperty, i);
                    textBlock1.SetValue(Grid.ColumnProperty, 0);
                    textBlock2.SetValue(Grid.ColumnProperty, 1);
                    textBlock3.SetValue(Grid.ColumnProperty, 2);

                    MainGrid.Children.Add(textBlock1);
                    MainGrid.Children.Add(textBlock2);
                    MainGrid.Children.Add(textBlock3);
                });
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemPlus)
            {
                var textBlocks = this.FindVisualChilds<TextBlock>();
                foreach (TextBlock textBlock in textBlocks)
                {
                    textBlock.FontSize++;
                }
            }
            else if (e.Key == Key.OemMinus)
            {
                var textBlocks = this.FindVisualChilds<TextBlock>();
                foreach (TextBlock textBlock in textBlocks)
                {
                    textBlock.FontSize--;
                }
            }
        }
    }
}
