using Gaten.Net.IO;
using Gaten.Net.Network;
using Gaten.Net.Wpf;

using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Gaten.Network.YouTubeExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        string path = GResource.GetPath("yt/log.csv");
        bool IsRunning = false;
        Thread worker;

        public MainWindow()
        {
            InitializeComponent();

            worker = new Thread(new ThreadStart(DoWork));
            worker.Start();
        }

        void DoWork()
        {
            while (true)
            {
                Thread.Sleep(500);

                while (IsRunning)
                {
                    var (videoInfo, nextUrl) = VideoParse();
                    if(nextUrl == string.Empty)
                    {
                        SeleniumWebCrawler.Refresh();
                    }
                    else
                    {
                        SeleniumWebCrawler.SetUrl(nextUrl);
                    }

                    Thread.Sleep(1500);

                    var str = string.Join(',', videoInfo.Video.Name, videoInfo.Video.Url, videoInfo.Channel.Name, videoInfo.Channel.Url, videoInfo.View, videoInfo.Upload) + "\r\n";
                    GResource.AppendText("yt/log.csv", str);
                    DispatcherService.Invoke(() =>
                    {
                        StatusText.Text = str;
                        Thread.Sleep(int.Parse(IntervalTextBox.Text));
                    });
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(path))
                {
                    GResource.SetText("yt/log.csv", "Title,Url,Channel,Channel_Url,View,Upload\r\n");
                }

                SeleniumWebCrawler.CreateNoWindow = true;
                SeleniumWebCrawler.Open("https://www.youtube.com/");
                Thread.Sleep(1500);
                var info = ThumbnailParse();
                var randomInfo = info[random.Next(info.Count)];

                SeleniumWebCrawler.SetUrl(randomInfo.Video.Url);

                IsRunning = true;
            }
            catch
            {
                MessageBox.Show($"[{DateTime.Now}] 비정상적인 종료");
            }

            MessageBox.Show($"[{DateTime.Now}] 완료");
        }

        (YouTubeVideoInfo, string) VideoParse()
        {
            var result = new YouTubeVideoInfo();
            var nextUrl = string.Empty;

            try
            {
                //var source = SeleniumWebCrawler.Source;
                var n1 = SeleniumWebCrawler.SelectNode("meta", "name", "title");
                var n2 = SeleniumWebCrawler.SelectNode("meta", "property", "og:url");
                var n3 = SeleniumWebCrawler.SelectNode("meta", "itemprop", "interactionCount");
                var n4 = SeleniumWebCrawler.SelectNode("meta", "itemprop", "uploadDate");
                var n5 = SeleniumWebCrawler.SelectNode("span", "itemprop", "author");
                var n6 = n5.FindElement(SeleniumWebCrawler.ToBy("link", "itemprop", "name"));
                var n7 = n5.FindElement(SeleniumWebCrawler.ToBy("link", "itemprop", "url"));
                //var n5 = SeleniumWebCrawler.SelectNode("div","id", "menu");
                //var n6 = n5.FindElements(By.TagName("yt-formatted-string"));
                var title = n1.GetDomAttribute("content").Replace(',', '`');
                var url = n2.GetDomAttribute("content");
                var view = n3.GetDomAttribute("content");
                var uploadDate = n4.GetDomAttribute("content");
                var channel = n6.GetDomAttribute("content");
                var channelUrl = n7.GetDomAttribute("href");
                //var like = n6[0].GetDomProperty("aria-label");

                result.Video = new UrlInfo(title, url);
                result.View = view;
                result.Upload = uploadDate;
                result.Channel = new UrlInfo(channel, channelUrl);
                //result.Like = like;

                // Next Video Click
                var n101 = SeleniumWebCrawler.SelectNodes("div", "id", "dismissible");
                nextUrl = n101.ElementAt(random.Next(n101.Count())).FindElement(SeleniumWebCrawler.ToBy("a", "id", "thumbnail")).GetDomAttribute("href");

                if(nextUrl == null)
                {
                    nextUrl = string.Empty;
                }
                else
                {
                    nextUrl = nextUrl.StartsWith("http") ? nextUrl : "https://www.youtube.com" + nextUrl;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[{DateTime.Now}] VideoParse: {ex.Message}");
            }

            return (result, nextUrl);
        }

        List<YouTubeThumbnailInfo> ThumbnailParse()
        {
            var result = new List<YouTubeThumbnailInfo>();
            try
            {
                var nodes = SeleniumWebCrawler.SelectNodes("div", "id", "dismissible");
                foreach (var node in nodes)
                {
                    try
                    {
                        var realtime = node.FindElement(SeleniumWebCrawler.ToBy("div", "class", "badge-style-type-live-now-alternate", true));
                        continue;
                    }
                    catch
                    {
                    }

                    var url = string.Empty;
                    try
                    {
                        var n1 = node.FindElement(SeleniumWebCrawler.ToBy("a", "id", "thumbnail"));
                        url = n1.GetDomProperty("href");
                    }
                    catch
                    {
                        continue;
                    }

                    var length = string.Empty;
                    try
                    {
                        var n2 = node.FindElement(SeleniumWebCrawler.ToBy("div", "id", "overlays"));
                        var n3 = n2.FindElement(By.TagName("span"));
                        length = n3.Text;
                    }
                    catch
                    {
                    }

                    var n4 = node.FindElement(By.Id("video-title"));
                    var n5 = node.FindElement(SeleniumWebCrawler.ToBy("div", "class", "ytd-channel-name", true));
                    var n6 = n5.FindElement(SeleniumWebCrawler.ToBy("a", "class", "yt-formatted-string", true));

                    var view = string.Empty;
                    var upload = string.Empty;
                    try
                    {
                        var n7 = node.FindElement(SeleniumWebCrawler.ToBy("div", "id", "metadata-line"));
                        var n8 = n7.FindElements(By.TagName("span"));
                        view = n8[0].Text.Substring(4);
                        upload = n8[1].Text;
                    }
                    catch
                    {

                    }

                    var title = n4.Text;
                    var channel = n6.Text;
                    var channelUrl = n6.GetDomProperty("href");

                    if (view == string.Empty && upload == string.Empty)
                    {
                        continue;
                    }

                    result.Add(new YouTubeThumbnailInfo(title, url, channel, channelUrl, length, view, upload));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"[{DateTime.Now}] ThumbnailParse: {ex.Message}");
            }

            return result;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            IsRunning = false;
        }
    }
}
