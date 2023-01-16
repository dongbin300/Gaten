using System;

namespace Gaten.Stock.MarinerX.Markets
{
    public class SymbolBenchmark
    {
        public string Symbol { get; set; } = string.Empty;
        public decimal Volatility { get; set; } = decimal.Zero;
        public decimal MarketCapWon { get; set; } = decimal.Zero;
        public int MaxLeverage { get; set; } = 0;
        public string MaxLeverageString => "X" + MaxLeverage;
        public double BenchmarkScore => CalculateBenchmarkScore();

        public SymbolBenchmark(string symbol, decimal volatility, decimal marketCapWon, int maxLeverage)
        {
            Symbol = symbol;
            Volatility = volatility;
            MarketCapWon = marketCapWon;
            MaxLeverage = maxLeverage;
        }

        public double CalculateBenchmarkScore()
        {
            return Math.Round(Math.Pow((double)MarketCapWon, 0.25) * (1 / (double)Volatility) * 100);
        }
    }
}
