using HtmlAgilityPack;

using System;
using System.Net;
using System.Text;
using System.Windows;

namespace Gaten.Stock.APStocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer;
        int count;

        public MainWindow()
        {
            InitializeComponent();

            timer = new System.Timers.Timer(3000);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            count++;
            CountText.Text = count.ToString();

            try
            {
                string id = IdTextBox.Text;
                using (WebClient client = new())
                {
                    client.Encoding = Encoding.UTF8;
                    string source = client.DownloadString($"http://www.fantastock.co.kr/bbs/board.php?bo_table=free_list21&wr_id={id}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StartParseButton_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            timer.Start();
        }

        private void StopParseButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void InstanceParseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = IdTextBox.Text;
                using (WebClient client = new())
                {
                    client.Encoding = Encoding.UTF8;
                    string source = client.DownloadString($"http://www.fantastock.co.kr/bbs/board.php?bo_table=free_list21&wr_id={id}");

                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(source);
                    var nodes = doc.DocumentNode.SelectNodes(".//div[@class='cmt_contents']");

                    foreach (var node in nodes)
                    {
                        string text = node.InnerText;

                        if (string.IsNullOrWhiteSpace(text)) continue;
                        text = text.Replace("&nbsp;", "").Replace("\n", "");

                        AllListBox.Items.Add(text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
