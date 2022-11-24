using Gaten.Net.Network;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.MarinerX.Apis
{
    public class BinanceHttpApi
    {
        public static void GetSymbolMarketCap()
        {
            string url = "https://www.binance.com/exchange-api/v2/public/asset-service/product/get-products";

            WebCrawler.Open(url);
            var obj = JsonConvert.DeserializeObject<GetProducts_Json>(WebCrawler.Source);
            var usdt = obj.data.Where(x => x.s.EndsWith("USDT") && x.marketCapWon > 100_000_000).ToList();
            var result = usdt.Select(x => new SymbolMarketCap() { Symbol = x.s, marketCapWon = x.marketCapWon, marketCapWonString = x.marketCapWonString }).ToList();
        }

        public class SymbolMarketCap
        {
            public string Symbol { get; set; }
            public decimal marketCapWon { get; set; }
            public string marketCapWonString { get; set; }
        }

        public class GetProducts_SymbolInfo
        {
            public string s { get; set; }
            public string st { get; set; }
            public string b { get; set; }
            public string q { get; set; }
            public string ba { get; set; }
            public string qa { get; set; }
            public string i { get; set; }
            public string ts { get; set; }
            public string an { get; set; }
            public string qn { get; set; }
            public string o { get; set; }
            public string h { get; set; }
            public string l { get; set; }
            public string c { get; set; }
            public string v { get; set; }
            public string qv { get; set; }
            public int y { get; set; }
            public double @as { get; set; }
            public string pm { get; set; }
            public string pn { get; set; }
            public object cs { get; set; }
            public IList<string> tags { get; set; }
            public bool pom { get; set; }
            public object pomt { get; set; }
            public bool lc { get; set; }
            public bool g { get; set; }
            public bool sd { get; set; }
            public bool r { get; set; }
            public bool hd { get; set; }
            public bool rb { get; set; }
            public bool etf { get; set; }

            public decimal marketCap => decimal.Parse(c) * decimal.Parse(cs == null ? "0" : cs.ToString());
            public decimal marketCapWon => marketCap * 1350;
            public string marketCapWonString => $"{marketCap * 1350:#,###}";
        }

        public class GetProducts_Json
        {
            public string code { get; set; }
            public object message { get; set; }
            public object messageDetail { get; set; }
            public IList<GetProducts_SymbolInfo> data { get; set; }
            public bool success { get; set; }
        }
    }
}
