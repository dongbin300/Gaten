using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface IOrder
    {
        public OrderType Type { get; set; }
        public PositionSide Side { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Price { get; set; }

        public string Run(Asset asset, ChartInfo chart);
    }
}
