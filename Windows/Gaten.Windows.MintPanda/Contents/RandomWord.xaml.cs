using Gaten.Net.Network;

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
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        public static string Get()
        {
            WebCrawler.SetUrl("https://randomword.com/");
            string word = WebCrawler.SelectNode("div", "id", "random_word").InnerText;
            string meaning = WebCrawler.SelectNode("div", "id", "random_word_definition").InnerText;

            return word + "\n" + meaning;
        }

        public void Refresh()
        {
            RandomWordText.Text = Get();
        }

        private void RandomWordButton_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
