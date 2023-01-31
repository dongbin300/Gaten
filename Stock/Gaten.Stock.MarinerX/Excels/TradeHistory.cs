namespace Gaten.Stock.MarinerX.Excels
{
    public class TradeHistory
    {
        public string Symbol { get; set; }
        public double Fee { get; set; }
        public string FeeCoin { get; set; }
        public double RealizedProfit { get; set; }

        public TradeHistory(string symbol, double fee, string feeCoin, double realizedProfit)
        {
            Symbol = symbol;
            Fee = fee;
            FeeCoin = feeCoin;
            RealizedProfit = realizedProfit;
        }
    }
}