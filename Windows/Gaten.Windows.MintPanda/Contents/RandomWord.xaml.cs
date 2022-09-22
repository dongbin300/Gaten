using Gaten.Net.Diagnostics;
using Gaten.Net.Network;

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// RandomWord.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RandomWord : Window
    {
        public RandomWord()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(RandomWord), MethodBase.GetCurrentMethod()?.Name, ex);
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
                GLogger.Log(nameof(RandomWord), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        public static string Get()
        {
            try
            {
                WebCrawler.SetUrl("https://randomword.com/");
                string word = WebCrawler.SelectNode("div", "id", "random_word").InnerText;
                string meaning = WebCrawler.SelectNode("div", "id", "random_word_definition").InnerText;

                return word + "\n" + meaning;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(RandomWord), MethodBase.GetCurrentMethod()?.Name, ex);
            }

            return string.Empty;
        }

        public void Refresh()
        {
            try
            {
                RandomWordText.Text = Get();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(RandomWord), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void RandomWordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Refresh();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(RandomWord), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
