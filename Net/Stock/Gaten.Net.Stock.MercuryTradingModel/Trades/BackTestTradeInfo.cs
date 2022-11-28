using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Trades
{
    public class BackTestTradeInfo
    {
        public string Symbol { get; set; }
        public string TradeTime { get; set; }
        public string Side { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Fee { get; set; }
        public string Balance { get; set; }
        public string Position { get; set; }
        public string BaseAsset { get; set; }
        public string EstimatedAsset { get; set; }
        public string Tag { get; set; }

        public BackTestTradeInfo(string symbol, string tradeTime, string side, string price, string quantity, string fee, string balance, string position, string baseAsset, string estimatedAsset, string tag)
        {
            Symbol = symbol;
            TradeTime = tradeTime;
            Side = side;
            Price = price;
            Quantity = quantity;
            Fee = fee;
            Balance = balance;
            Position = position;
            BaseAsset = baseAsset;
            EstimatedAsset = estimatedAsset;
            Tag = tag;
        }
    }
}
