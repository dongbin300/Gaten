
using Gaten.Stock.MockTrader.Api;
using Gaten.Stock.MockTrader.BinanceTrade;
using Gaten.Stock.MockTrader.Chart;

namespace Gaten.Stock.MockTrader
{
    internal class Assets
    {
        /// <summary>
        /// 시드($)
        /// </summary>
        public double Seed { get; set; }

        /// <summary>
        /// 잔액($)
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 분할 매매(1/n)
        /// </summary>
        //public double DivisionRate { get; set; }

        /// <summary>
        /// 코인 자산
        /// </summary>
        public Dictionary<string, double> CoinSize { get; set; } = new Dictionary<string, double>();

        public void Init()
        {
            //var symbols = BinanceClientApi.GetExchangeInfo().Symbols
            //    .Where(s => s.Name.EndsWith("USDT"))
            //    .SkipLast(4);

            var symbols = LocalStorageApi.GetSymbols();

            foreach (var symbol in symbols)
            {
                CoinSize.Add(symbol, 0);
            }

            //CoinSize.Remove("LINKUSDT");
        }

        public void InitTemp()
        {
            CoinSize.Add("BTCUSDT", 0);
        }

        /// <summary>
        /// 포지션 정리
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="candle"></param>
        public void ClosePosition(string symbol, Candle candle)
        {
            if (IsLongPosition(symbol))
            {
                //TradeMarket.Sell(symbol, candle, AbsoluteSize(symbol));
            }
            else
            {
                //TradeMarket.Buy(symbol, candle, AbsoluteSize(symbol));
            }
        }

        public double AbsoluteSize(string symbol) => Math.Abs(CoinSize[symbol]);
        public bool IsLongPosition(string symbol) => CoinSize[symbol] > 0;
        public double EvaluatedAmount(string symbol, Candle candle) => Amount + CoinSize[symbol] * candle.Close;
    }
}
