namespace Gaten.Stock.BinanceBrowser.Models
{
    public class FuturesPosition
    {
        public string Symbol { get; set; }
        public int Leverage { get; set; }
        public decimal Quantity { get; set; }
        public decimal EntryPrice { get; set; }
        public decimal MarkPrice { get; set; }
        public decimal UnrealizedPnl { get; set; }
        public decimal LiquidationPrice { get; set; }

        public FuturesPosition(string symbol, int leverage, decimal quantity, decimal entryPrice, decimal markPrice, decimal unrealizedPnl, decimal liquidationPrice)
        {
            Symbol = symbol;
            Leverage = leverage;
            Quantity = quantity;
            EntryPrice = entryPrice;
            MarkPrice = markPrice;
            UnrealizedPnl = unrealizedPnl;
            LiquidationPrice = liquidationPrice;
        }
    }
}
