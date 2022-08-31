namespace Gaten.Net.Stock.Extensions
{
    public class StockUtil
    {
        public static string POE(double start, double end)
        {
            double value = System.Math.Round((end - start) / start * 100, 2);
            return value >= 0 ? "+" + value + "%" : value + "%";
        }
    }
}
