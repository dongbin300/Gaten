namespace Gaten.Stock.MoqTrader.Orders
{
    public enum PositionType
    {
        Long,
        Short
    }

    internal class Order
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public PositionType Position { get; set; }

        public Order(string symbol, double price, double size, PositionType side)
        {
            Symbol = symbol;
            Price = price;
            Size = size;
            Position = side;
        }

        public new string ToString()
        {
            return "";
            //return $"{Price}, {(Side == SideType.Long ? "+" : "-")}{Size}, {Assets.CoinSize[Symbol]} {Symbol}, {Assets.Amount + Assets.CoinSize[Symbol] * Price} USDT";
        }
    }
}
