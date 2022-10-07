using Gaten.Net.Extensions;
using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Orders
{
    public class BackTestOrder : IOrder
    {
        public OrderType Type { get; set; } = OrderType.None;
        public PositionSide Side { get; set; } = PositionSide.None;
        public decimal Quantity { get; set; }
        public decimal? Price { get; set; } = null;

        public BackTestOrder()
        {

        }

        public BackTestOrder(OrderType type, PositionSide side, decimal quantity, decimal? price = null)
        {
            Type = type;
            Side = side;
            Quantity = quantity;
            Price = price;
        }

        public string Run(Asset asset, ChartInfo chart)
        {
            if (Type == OrderType.Market)
            {
                Price = chart.Quote.Close;
            }

            if (Price == null)
            {
                return "ERROR!";
            }

            switch (Side)
            {
                case PositionSide.Long:
                    Buy(asset, Price.Value, Quantity);
                    var estimatedAsset = Price.Value * asset.Position.ToDecimal() + asset.Balance;
                    return $"{chart.DateTime.ToStandardString()},Buy,{Price},{Quantity},현재 {asset.Balance} USDT, {asset.Position} SOL ({estimatedAsset}USDT)";

                case PositionSide.Short:
                    Sell(asset, Price.Value, Quantity);
                    var estimatedAsset2 = Price.Value * asset.Position.ToDecimal() + asset.Balance;
                    return $"{chart.DateTime.ToStandardString()},Sell,{Price},{Quantity},현재 {asset.Balance} USDT, {asset.Position} SOL ({estimatedAsset2}USDT)";
            }

            return string.Empty;
        }

        public void Buy(Asset asset, decimal price, decimal quantity)
        {
            asset.Balance -= price;
            asset.Position.Long(quantity);
        }

        public void Sell(Asset asset, decimal price, decimal quantity)
        {
            asset.Balance += price;
            asset.Position.Short(quantity);
        }
    }
}
