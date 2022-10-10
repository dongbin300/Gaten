using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Assets
{
    public class Position
    {
        public PositionSide Side { get; set; } = PositionSide.None;
        public decimal Amount { get; set; } = 0m;
        public decimal Value => Side == PositionSide.Short ? -Amount : Amount;

        public void Long(decimal quantity)
        {
            if (Side == PositionSide.Long)
            {
                Amount += quantity;
            }
            else
            {
                Amount -= quantity;
                if (Amount < 0)
                {
                    Side = PositionSide.Long;
                    Amount = -Amount;
                }
            }
        }

        public void Short(decimal quantity)
        {
            if (Side == PositionSide.Short)
            {
                Amount += quantity;
            }
            else
            {
                Amount -= quantity;
                if (Amount < 0)
                {
                    Side = PositionSide.Short;
                    Amount = -Amount;
                }
            }
        }

        public override string ToString()
        {
            return (Side == PositionSide.Long ? "+" : "-") + Amount;
        }
    }
}
