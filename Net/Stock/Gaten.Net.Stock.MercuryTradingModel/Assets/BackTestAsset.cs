namespace Gaten.Net.Stock.MercuryTradingModel.Assets
{
    public class BackTestAsset : Asset
    {
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
