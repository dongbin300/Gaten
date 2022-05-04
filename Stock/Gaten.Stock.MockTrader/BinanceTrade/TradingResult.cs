using System.Text;

namespace Gaten.Stock.MockTrader.BinanceTrade
{
    internal class TradingResult
    {
        public string Symbol { get; set; }
        public DateTime Time { get; set; }
        public double EstimatedAssets { get; set; }
        public List<Trade> Trades { get; set; }

        public TradingResult(string symbol, DateTime time)
        {
            Symbol = symbol;
            Time = time;
        }

        public new string ToString()
        {
            return $"{Symbol}, {Time:yyyy-MM-dd HH:mm:ss}, {EstimatedAssets} USDT";
        }

        public new string ToTradeString()
        {
            StringBuilder builder = new StringBuilder();
            foreach(var trade in Trades)
            {
                builder.AppendLine(trade.ToString());
            }
            return builder.ToString();
        }
    }
}
