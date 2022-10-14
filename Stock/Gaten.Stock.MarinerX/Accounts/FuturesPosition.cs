using Binance.Net.Enums;

namespace Gaten.Stock.MarinerX.Accounts
{
    internal class FuturesPosition
    {
        public string Symbol { get; set; }
        public FuturesMarginType MarginType { get; set; }
        public int Leverage { get; set; }
        public PositionSide PositionSide { get; set; }
        public decimal Quantity { get; set; }
        public decimal EntryPrice { get; set; }
        public decimal MarkPrice { get; set; }
        public decimal UnrealizedPnl { get; set; }
        public decimal LiquidationPrice { get; set; }

        public FuturesPosition(string symbol, FuturesMarginType marginType, int leverage, PositionSide positionSide, decimal quantity, decimal entryPrice, decimal markPrice, decimal unrealizedPnl, decimal liquidationPrice)
        {
            Symbol = symbol;
            MarginType = marginType;
            Leverage = leverage;
            PositionSide = positionSide;
            Quantity = quantity;
            EntryPrice = entryPrice;
            MarkPrice = markPrice;
            UnrealizedPnl = unrealizedPnl;
            LiquidationPrice = liquidationPrice;
        }
    }
}
