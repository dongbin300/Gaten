using Gaten.Net.Network;

namespace Gaten.Windows.MintPanda.Contents
{
    internal class Stock
    {
        public static string Get()
        {
            WebCrawler.SetUrl("https://finance.naver.com/item/sise.naver?code=005380");
            var value1 = WebCrawler.SelectNode("strong", "id", "_nowVal").InnerText.Trim();
            var rate1 = WebCrawler.SelectNode("strong", "id", "_rate").InnerText.Trim();

            WebCrawler.SetUrl("https://finance.naver.com/item/sise.naver?code=092300");
            var value2 = WebCrawler.SelectNode("strong", "id", "_nowVal").InnerText.Trim();
            var rate2 = WebCrawler.SelectNode("strong", "id", "_rate").InnerText.Trim();

            WebCrawler.SetUrl("https://finance.naver.com/item/sise.naver?code=096690");
            var value3 = WebCrawler.SelectNode("strong", "id", "_nowVal").InnerText.Trim();
            var rate3 = WebCrawler.SelectNode("strong", "id", "_rate").InnerText.Trim();

            //var client = new WebClient();
            //client.Headers.Add("X-CMC_PRO_API_KEY", "87a98fa9-1a64-4b88-8148-079b2ed2fe14");
            //client.Headers.Add("Accepts", "application/json");
            //var source = client.DownloadString("https://coinmarketcap.com/ko/currencies/green-satoshi-token/");

            return $"현대차 {value1} {rate1}\r\n" +
                $"현우산업 {value2} {rate2}\r\n" +
                $"에이루트 {value3} {rate3}";
        }
    }
}
