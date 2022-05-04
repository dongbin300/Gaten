
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
        public static double Seed { get; set; }

        /// <summary>
        /// 잔액($)
        /// </summary>
        public static double Amount { get; set; }

        /// <summary>
        /// 분할 매매(1/n)
        /// </summary>
        public static double DivisionRate { get; set; }

        /// <summary>
        /// 코인 자산
        /// </summary>
        public static Dictionary<string, double> CoinSize { get; set; } = new Dictionary<string, double>();

        public static void Init()
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

        /// <summary>
        /// 포지션 정리
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="candle"></param>
        public static void ClosePosition(string symbol, Candle candle)
        {
            if (IsLongPosition(symbol))
            {
                TradeManager.Sell(symbol, candle, AbsoluteSize(symbol));
            }
            else
            {
                TradeManager.Buy(symbol, candle, AbsoluteSize(symbol));
            }
        }

        public static double AbsoluteSize(string symbol) => Math.Abs(CoinSize[symbol]);
        public static bool IsLongPosition(string symbol) => CoinSize[symbol] > 0;
        public static double EvaluatedAmount(string symbol, Candle candle) => Amount + CoinSize[symbol] * candle.Close;
    }
}
