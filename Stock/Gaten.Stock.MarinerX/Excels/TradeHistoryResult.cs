using System;

namespace Gaten.Stock.MarinerX.Excels
{
    public class TradeHistoryResult
    {
        public string Symbol { get; set; }
        public double Fee { get; set; }
        public string FeeCoin { get; set; }
        public double RealizedProfit { get; set; }
        /// <summary>
        /// Exclude Fee
        /// </summary>
        public double RealRealizedProfit => Math.Round(FeeCoin == "BNB" ? RealizedProfit - Fee * Common.BnbPrice : RealizedProfit - Fee, Common.DecimalCount);

        public TradeHistoryResult(string symbol, double fee, string feeCoin, double realizedProfit)
        {
            Symbol = symbol;
            Fee = fee;
            FeeCoin = feeCoin;
            RealizedProfit = realizedProfit;
        }

        public new string ToString()
        {
            return $"[{Symbol}] {RealRealizedProfit}USDT";
        }
    }
}
