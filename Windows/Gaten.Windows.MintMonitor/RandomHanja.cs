using Gaten.Net.Network;

namespace Gaten.Windows.MintMonitor
{
    internal class RandomHanja
    {
        /// <summary>
        /// U+3400 ~ U+4DBF (13312~19903) 6592
        /// U+4E00 ~ U+9FFF (19968~40959) 20992
        /// U+20000 ~ U+2A6DF (131072~173791) 42720
        /// U+2A700 ~ U+2B738 (173824~177976) 4153
        /// U+2B740 ~ U+2B81D (177984~178205) 222
        /// 74679
        /// </summary>
        /// <returns></returns>
        public static (string, string) Get()
        {
            try
            {
                //int num = new Random(DateTime.Now.Millisecond).Next(1000);
                int num = new Random(DateTime.Now.Millisecond).Next(74679);
                int convert =
                    num < 6592 ? num + 13312 :
                    num < 27584 ? num + 13376 :
                    num < 70304 ? num + 103488 :
                    num < 74457 ? num + 103520 :
                    num + 103527;
                string hex = convert.ToString("X");
                WebCrawler.SetUrl($"https://unicode-explorer.com/c/{hex}");
                string hanja = WebCrawler.SelectNode("div", "class", "char-big").InnerText;
                //WebCrawler.SetUrl($"https://hanja.dict.naver.com/#/search?query={hanja}");
                //string mean = string.Empty;
                //string entryMean = string.Empty;
                //var node = WebCrawler.SelectNode("div", "class", "mean");
                //if(node != null)
                //{
                //    mean = node.InnerText;
                //}
                //node = WebCrawler.SelectNode("div", "class", "entry_mean");
                //if(node != null)
                //{
                //    entryMean = node.InnerText;
                //}

                WebCrawler.SetUrl($"http://yoksa.aks.ac.kr/jsp/hh/HHBottom1.jsp?hh10_no=0-{hex}");
                var nodes = WebCrawler.SelectNodes("td", "align", "center");
                string dok = nodes != null && nodes.Count > 6 ? nodes[6].InnerText.Replace("nbsp;", "") : string.Empty;

                return (hanja, "U+" + hex + "\n" + dok);
            }
            catch
            {
            }

            return (string.Empty, string.Empty);
        }
    }
}
