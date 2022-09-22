using Gaten.Net.Diagnostics;
using Gaten.Net.Network;

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// Dictionary.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Dictionary : Window
    {
        public Dictionary()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Dictionary), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    DragMove();
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Dictionary), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void DictTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    WebCrawler.SetUrl($"https://dict.naver.com/search.nhn?dicQuery={DictTextBox.Text}&query={DictTextBox.Text}&target=dic&ie=utf8&query_utf=&isOnlyViewEE=");

                    DictListBox.Items.Clear();
                    var nodes = WebCrawler.SelectNodes("//dl[@class='dic_search_result']/dd");
                    foreach (var node in nodes)
                    {
                        DictListBox.Items.Add(
                            node.InnerText.Trim()
                            .Replace("\t ", "")
                            .Replace("\t", "")
                            .Replace("\r\n", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Dictionary), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
