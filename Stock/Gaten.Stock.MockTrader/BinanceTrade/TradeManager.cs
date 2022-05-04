using Binance.Net.Enums;

using Gaten.Stock.MockTrader.Chart;
using Gaten.Stock.MockTrader.Strategies;

namespace Gaten.Stock.MockTrader.BinanceTrade
{
    internal class TradeManager
    {
        public static readonly double BuyFee = 0.0004;
        public static readonly double SellFee = 0.0002;
        public static bool TradeLogger;

        public static void Init()
        {

        }

        public static Trade Buy(string symbol, Candle candle, double quantity)
        {
            double tradeAmount = candle.Close * quantity;
            Assets.Amount -= tradeAmount + Math.Round(tradeAmount * BuyFee, 8);
            Assets.CoinSize[symbol] += quantity;

            return new Trade(symbol, candle.Close, quantity, SideType.Long);
            
        }

        public static Trade Sell(string symbol, Candle candle, double quantity)
        {
            double tradeAmount = candle.Close * quantity;
            Assets.Amount += tradeAmount - Math.Round(tradeAmount * SellFee, 8);
            Assets.CoinSize[symbol] -= quantity;

            return new Trade(symbol, candle.Close, quantity, SideType.Short);
        }

        /// <summary>
        /// 매매 시뮬레이션
        /// </summary>
        public static TradingResult SimulateTrading(string symbol, DateTime startDate, KlineInterval candleInterval)
        {
            try
            {
                TradingResult tradingResult = new TradingResult(symbol, startDate);
                List<Trade> trades = new List<Trade>();

                var chartInfo = ChartManager.AnalyzeChart(symbol, startDate, candleInterval);

                int rsiFlag = 0;
                int combo = 0;
                for (int i = 0; i < chartInfo.CandleCount; i++)
                {
                    var candle = chartInfo.Candles[i];
                    var rsi = chartInfo.RSI.ToList()[i].Rsi;
                    var bb1up = Convert.ToDouble(chartInfo.BollingerBands.ToList()[i].UpperBand);
                    var bb1lo = Convert.ToDouble(chartInfo.BollingerBands.ToList()[i].LowerBand);
                    var bb2up = Convert.ToDouble(chartInfo.BollingerBands2.ToList()[i].UpperBand);
                    var bb2lo = Convert.ToDouble(chartInfo.BollingerBands2.ToList()[i].LowerBand);

                    var trade =
                    //CommonStrategy.Rsi_1(chartInfo.Symbol, candle, rsi, ref rsiFlag, ref combo);
                    //CommonStrategy.Rsi_2(chartInfo.Symbol, candle, rsi, ref rsiFlag);
                    CommonStrategy.Bb_1(chartInfo.Symbol, candle, bb1up, bb1lo, bb2up, bb2lo);

                    if(trade != null)
                    {
                        trades.Add(trade);
                    }
                }

                tradingResult.Trades = trades;
                tradingResult.EstimatedAssets = Assets.EvaluatedAmount(chartInfo.Symbol, chartInfo.Candles[^1]);

                return tradingResult;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
           
        }
    }
}
