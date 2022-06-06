namespace Gaten.Stock.MockTrader.BinanceTrade
{
    enum SideType
    {
        Long,
        Short
    }

    internal class Trade
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public SideType Side { get; set; }

        public Trade(string symbol, double price, double size, SideType side)
        {
            Symbol = symbol;
            Price = price;
            Size = size;
            Side = side;
        }
        
        public new string ToString()
        {
            return "";
            //return $"{Price}, {(Side == SideType.Long ? "+" : "-")}{Size}, {Assets.CoinSize[Symbol]} {Symbol}, {Assets.Amount + Assets.CoinSize[Symbol] * Price} USDT";
        }
    }
}
