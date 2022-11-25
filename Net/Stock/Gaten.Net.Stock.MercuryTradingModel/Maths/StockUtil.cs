using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Maths
{
    public class StockUtil
    {
        public static decimal Roe(PositionSide side, decimal start, decimal end)
        {
            return side switch
            {
                PositionSide.Long => System.Math.Round((end - start) / start * 100, 2),
                PositionSide.Short => System.Math.Round((start - end) / end * 100, 2),
                _ => 0,
            };
        }

        public static string GetRoeString(PositionSide side, decimal start, decimal end)
        {
            var value = Roe(side, start, end);
            return value >= 0 ? "+" + value + "%" : value + "%";
        }

        public static decimal GetPriceByRoe(PositionSide side, decimal start, decimal roe)
        {
            return side switch
            {
                PositionSide.Long => start * (1 + roe / 100),
                PositionSide.Short => start / (1 + roe / 100),
                _ => 0
            };
        }
    }
}
