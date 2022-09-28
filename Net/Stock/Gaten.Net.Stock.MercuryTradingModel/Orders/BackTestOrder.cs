using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Orders
{
    public class BackTestOrder : IOrder
    {
        public ChartInfo Chart { get; set; } = new ChartInfo("", new Skender.Stock.Indicators.Quote());

        /// <summary>
        /// 현금 잔고
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 포지션
        /// </summary>
        public Position Position { get; set; } = new();

        public OrderType Type { get; set; } = OrderType.None;
        public PositionSide Side { get; set; } = PositionSide.None;
        public decimal Quantity { get; set; }
        public decimal? Price { get; set; } = null;

        public BackTestOrder()
        {

        }

        public BackTestOrder(ChartInfo chart)
        {
            Chart = chart;
        }

        public BackTestOrder(OrderType type, PositionSide side, decimal quantity, decimal? price = null)
        {
            Type = type;
            Side = side;
            Quantity = quantity;
            Price = price;
        }

        public void Run()
        {
            if (Type == OrderType.Market)
            {
                Price = Chart.Quote.Close;
            }

            if (Price == null)
            {
                return;
            }

            switch (Side)
            {
                case PositionSide.Long:
                    Buy(Price.Value, Quantity);
                    break;

                case PositionSide.Short:
                    Sell(Price.Value, Quantity);
                    break;
            }
        }

        public void Buy(decimal price, decimal quantity)
        {
            Balance -= price;
            Position.Long(quantity);
        }

        public void Sell(decimal price, decimal quantity)
        {
            Balance += price;
            Position.Short(quantity);
        }
    }
}
