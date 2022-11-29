using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Trades;

namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface IOrder
    {
        public OrderType Type { get; set; }
        public PositionSide Side { get; set; }
        public OrderAmount Amount { get; set; }
        public decimal? Price { get; set; }
        public decimal MakerFee { get; }
        public decimal TakerFee { get; }

        public BackTestTradeInfo Run(Asset asset, ChartInfo chartm, string tag);
    }
}
