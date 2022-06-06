
using Gaten.Net.Network;

namespace Gaten.Windows.MintMonitor
{
    internal class RandomWord
    {
        public static string Get()
        {
            WebCrawler.SetUrl("https://randomword.com/");
            string word = WebCrawler.SelectNode("div", "id", "random_word").InnerText;
            string meaning = WebCrawler.SelectNode("div", "id", "random_word_definition").InnerText;

            return word + "\n" + meaning;
        }
    }
}
