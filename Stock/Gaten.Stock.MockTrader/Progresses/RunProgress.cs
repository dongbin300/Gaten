namespace Gaten.Stock.MockTrader.Progresses
{
    internal class RunProgress
    {
        public int Max { get; }
        public int Value { get; private set; }
        public double Percent => 100 * Value / Max;

        public RunProgress(int max)
        {
            Max = max;
            Value = 0;
        }

        public void Progress()
        {
            Value++;
        }
    }
}
