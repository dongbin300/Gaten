using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Orders
{
    public class BackTestOrder
    {
        /// <summary>
        /// 현금 잔고
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 포지션
        /// </summary>
        public Position Position { get; set; } = new();

        public void Run(OrderType type, PositionSide side, decimal price, decimal quantity)
        {

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
