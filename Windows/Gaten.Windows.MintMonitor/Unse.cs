using Gaten.Net.Network;

namespace Gaten.Windows.MintMonitor
{
    internal class Unse
    {
        public static string Get()
        {
            try
            {
                WebCrawler.SetUrl($"https://www.ytn.co.kr/_ln/0121_{DateTime.Now:yyyyMMdd}0000000001");
                
                string[] splitSource = WebCrawler.Source.Substring(WebCrawler.Source.IndexOf("[개띠]"), 500).Split(new string[] { "<br />" }, StringSplitOptions.RemoveEmptyEntries);

                var allDog = splitSource[1].Replace("\n", "");
                var Dog94 = splitSource[6].Replace("1994년생, ", "").Replace("\n", "");

                return allDog + "\n" + Dog94;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
