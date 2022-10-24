namespace Gaten.Net.Stock.MercuryTradingModel.Maths
{
    public class KellyCriterion
    {
        public static double Calculate(double probability, double proportion)
        {
            if (proportion <= 0)
            {
                return 0;
            }

            return (probability * (proportion + 1) - 1) / proportion;
        }
    }
}
