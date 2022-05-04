namespace Gaten.Stock.MockTrader.Chart
{
    internal class Band
    {
        public double Upper { get; set; }
        public double Middle { get; set; }
        public double Lower { get; set; }

        public Band(double upper, double middle, double lower)
        {
            Upper = upper;
            Middle = middle;
            Lower = lower;
        }
    }
}
