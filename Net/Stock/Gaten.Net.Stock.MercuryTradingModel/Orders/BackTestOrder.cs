using Gaten.Net.Extensions;
using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

using Newtonsoft.Json;

namespace Gaten.Net.Stock.MercuryTradingModel.Orders
{
    public class BackTestOrder : IOrder
    {
        public OrderType Type { get; set; } = OrderType.None;
        public PositionSide Side { get; set; } = PositionSide.None;
        public OrderAmount Amount { get; set; } = new OrderAmount(OrderAmountType.None, 0m);
        public decimal? Price { get; set; } = null;
        [JsonIgnore]
        public decimal MakerFee => 0.00075m; // use BNB(0.075%)
        [JsonIgnore]
        public decimal TakerFee => 0.00075m; // use BNB(0.075%)

        public BackTestOrder(OrderType type, PositionSide side, OrderAmount amount, decimal? price = null)
        {
            Type = type;
            Side = side;
            Amount = amount;
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

            decimal quantity;
            switch (Amount.OrderType)
            {
                case OrderAmountType.Fixed:
                    quantity = decimal.Round(Amount.Value / Price.Value, 2);
                    break;

                case OrderAmountType.FixedSymbol:
                    quantity = Amount.Value;
                    break;

                case OrderAmountType.Seed:
                    var transactionAmount = decimal.Round(asset.Seed * Amount.Value, 2);
                    quantity = decimal.Round(transactionAmount / Price.Value, 2);
                    break;

                case OrderAmountType.Balance:
                    var transactionAmount2 = decimal.Round(asset.Balance * Amount.Value, 2);
                    quantity = decimal.Round(transactionAmount2 / Price.Value, 2);
                    break;

                case OrderAmountType.Asset:
                    var estimatedAsset = Price.Value * asset.Position.ToDecimal() + asset.Balance;
                    var transactionAmount3 = decimal.Round(estimatedAsset * Amount.Value, 2);
                    quantity = decimal.Round(transactionAmount3 / Price.Value, 2);
                    break;

                case OrderAmountType.BalanceSymbol:
                    var symbolAmount = asset.Position.Amount;
                    var transactionAmount4 = decimal.Round(symbolAmount * Amount.Value, 2);
                    quantity = decimal.Round(transactionAmount4 / Price.Value, 2);
                    break;

                default:
                    quantity = 0;
                    break;
            }

            switch (Side)
            {
                case PositionSide.Long:
                    var buyFee = Buy(asset, Price.Value, quantity);
                    var estimatedAsset = Price.Value * asset.Position.ToDecimal() + asset.Balance;
                    return $"{chart.DateTime.ToStandardString()},Buy,{Price},{quantity} (Fee {buyFee:#.##}USDT)" +
                        $" | {asset.Balance:#.##} USDT, {asset.Position} {chart.BaseAsset} ({estimatedAsset:#.##}USDT?)";

                case PositionSide.Short:
                    var sellFee = Sell(asset, Price.Value, quantity);
                    var estimatedAsset2 = Price.Value * asset.Position.ToDecimal() + asset.Balance;
                    return $"{chart.DateTime.ToStandardString()},Sell,{Price},{quantity} (Fee {sellFee:#.##}USDT)" +
                        $" | {asset.Balance:#.##} USDT, {asset.Position} {chart.BaseAsset} ({estimatedAsset2:#.##}USDT?)";

                case PositionSide.Open:
                    if(asset.Position.Side == PositionSide.None || asset.Position.Amount < 0.0001m)
                    {
                        return "";
                    }
                    else if(asset.Position.Side == PositionSide.Long)
                    {
                        quantity = asset.Position.Amount * Amount.Value;
                        var openBuyFee = Buy(asset, Price.Value, quantity);
                        var openEstimatedAsset = Price.Value * asset.Position.ToDecimal() + asset.Balance;
                        return $"{chart.DateTime.ToStandardString()},Buy,{Price},{quantity} (Fee {openBuyFee:#.##}USDT)" +
                        $" | {asset.Balance:#.##} USDT, {asset.Position} {chart.BaseAsset} ({openEstimatedAsset:#.##}USDT?)";
                    }
                    else
                    {
                        quantity = asset.Position.Amount * Amount.Value;
                        var openSellFee = Sell(asset, Price.Value, quantity);
                        var openEstimatedAsset2 = Price.Value * asset.Position.ToDecimal() + asset.Balance;
                        return $"{chart.DateTime.ToStandardString()},Sell,{Price},{quantity} (Fee {openSellFee:#.##}USDT)" +
                        $" | {asset.Balance:#.##} USDT, {asset.Position} {chart.BaseAsset} ({openEstimatedAsset2:#.##}USDT?)";
                    }

                case PositionSide.Close:
                    if (asset.Position.Side == PositionSide.None || asset.Position.Amount < 0.0001m)
                    {
                        return "";
                    }
                    else if (asset.Position.Side == PositionSide.Short)
                    {
                        quantity = asset.Position.Amount * Amount.Value;
                        var closeBuyFee = Buy(asset, Price.Value, quantity);
                        var closeEstimatedAsset = Price.Value * asset.Position.ToDecimal() + asset.Balance;
                        return $"{chart.DateTime.ToStandardString()},Buy,{Price},{quantity} (Fee {closeBuyFee:#.##}USDT)" +
                        $" | {asset.Balance:#.##} USDT, {asset.Position} {chart.BaseAsset} ({closeEstimatedAsset:#.##}USDT?)";
                    }
                    else
                    {
                        quantity = asset.Position.Amount * Amount.Value;
                        var closeSellFee = Sell(asset, Price.Value, quantity);
                        var closeEstimatedAsset2 = Price.Value * asset.Position.ToDecimal() + asset.Balance;
                        return $"{chart.DateTime.ToStandardString()},Sell,{Price},{quantity} (Fee {closeSellFee:#.##}USDT)" +
                        $" | {asset.Balance:#.##} USDT, {asset.Position} {chart.BaseAsset} ({closeEstimatedAsset2:#.##}USDT?)";
                    }
            }

            return string.Empty;
        }

        public decimal Buy(Asset asset, decimal price, decimal quantity)
        {
            var transactionAmount = price * quantity;
            var fee = transactionAmount * TakerFee;
            asset.Balance -= transactionAmount + fee;
            asset.Position.Long(quantity);

            return fee;
        }

        public decimal Sell(Asset asset, decimal price, decimal quantity)
        {
            var transactionAmount = price * quantity;
            var fee = transactionAmount * TakerFee;
            asset.Balance += transactionAmount;
            asset.Balance -= fee;
            asset.Position.Short(quantity);

            return fee;
        }
    }
}
