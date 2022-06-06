namespace Gaten.Stock.MockTrader.Chart
{
    /// <summary>
    /// 지금은 사용하지 않음
    /// </summary>
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
