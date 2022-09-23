using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Assets
{
    public class Position
    {
        public PositionSide Side { get; set; }
        public decimal Amount { get; set; }

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

        public decimal ToDecimal()
        {
            return decimal.Parse(ToString());
        }

        public override string ToString()
        {
            return (Side == PositionSide.Long ? "+" : "-") + Amount;
        }
    }
}
