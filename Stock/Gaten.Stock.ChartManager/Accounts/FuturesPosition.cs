using Binance.Net.Enums;

namespace Gaten.Stock.ChartManager.Accounts
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
    }
}
