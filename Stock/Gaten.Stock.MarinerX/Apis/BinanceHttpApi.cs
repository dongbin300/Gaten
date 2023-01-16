using Gaten.Net.Network;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.MarinerX.Apis
{
    public class BinanceHttpApi
    {
        public static List<SymbolMarketCap>? GetSymbolMarketCap()
        {
            string url = "https://www.binance.com/exchange-api/v2/public/asset-service/product/get-products";

            WebCrawler.Open(url);
            var obj = JsonConvert.DeserializeObject<GetProducts_Json>(WebCrawler.Source);

            if(obj == null)
            {
                return null;
            }

            var usdt = obj.data.Where(x => x.s.EndsWith("USDT") && x.marketCapWon > 100_000_000).ToList();
            return usdt.Select(x => new SymbolMarketCap() { Symbol = x.s, marketCapWon = x.marketCapWon, marketCapWonString = x.marketCapWonString }).ToList();
        }

        public class SymbolMarketCap
        {
            public string Symbol { get; set; } = default!;
            public decimal marketCapWon { get; set; }
            public string marketCapWonString { get; set; } = default!;
        }

        public class GetProducts_SymbolInfo
        {
            public string s { get; set; } = default!;
            public string st { get; set; } = default!;
            public string b { get; set; } = default!;
            public string q { get; set; } = default!;
            public string ba { get; set; } = default!;
            public string qa { get; set; } = default!;
            public string i { get; set; } = default!;
            public string ts { get; set; } = default!;
            public string an { get; set; } = default!;
            public string qn { get; set; } = default!;
            public string o { get; set; } = default!;
            public string h { get; set; } = default!;
            public string l { get; set; } = default!;
            public string c { get; set; } = default!;
            public string v { get; set; } = default!;
            public string qv { get; set; } = default!;
            public int y { get; set; } = default!;
            public double @as { get; set; } = default!;
            public string pm { get; set; } = default!;
            public string pn { get; set; } = default!;
            public object cs { get; set; } = default!;
            public IList<string> tags { get; set; } = default!;
            public bool pom { get; set; } = default!;
            public object pomt { get; set; } = default!;
            public bool lc { get; set; } = default!;
            public bool g { get; set; } = default!;
            public bool sd { get; set; } = default!;
            public bool r { get; set; } = default!;
            public bool hd { get; set; } = default!;
            public bool rb { get; set; } = default!;
            public bool etf { get; set; } = default!;

            public decimal marketCap => decimal.Parse(c) * decimal.Parse(cs == null ? "0" : cs.ToString());
            public decimal marketCapWon => marketCap * 1350;
            public string marketCapWonString => $"{marketCap * 1350:#,###}";
        }

        public class GetProducts_Json
        {
            public string code { get; set; } = default!;
            public object message { get; set; } = default!;
            public object messageDetail { get; set; } = default!;
            public IList<GetProducts_SymbolInfo> data { get; set; } = default!;
            public bool success { get; set; }
        }
    }
}
