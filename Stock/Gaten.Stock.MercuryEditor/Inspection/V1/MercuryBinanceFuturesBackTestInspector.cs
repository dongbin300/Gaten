using Gaten.Net.Extensions;
using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Formulae;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Intervals;
using Gaten.Net.Stock.MercuryTradingModel.Orders;
using Gaten.Net.Stock.MercuryTradingModel.Signals;
using Gaten.Net.Stock.MercuryTradingModel.TradingModels;
using Gaten.Stock.MercuryEditor.Editor;

using K4os.Compression.LZ4.Streams;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.MercuryEditor.Inspection.V1
{
    /// <summary>
    /// 10k->10000
    /// </summary>
    internal class MercuryBinanceFuturesBackTestInspector
    {
        private int lineNumber = 0;
        public MercuryBackTestTradingModel TradingModel { get; private set; } = new MercuryBackTestTradingModel();

        public MercuryBinanceFuturesBackTestInspector()
        {
        }

        public MercuryBinanceFuturesBackTestInspector(int lineNumber)
        {
            this.lineNumber = lineNumber;
        }

        public string Run(List<TextLine> code)
        {
            try
            {
                var assetResult = ParseAsset(code);
                if (assetResult != string.Empty)
                {
                    return assetResult;
                }

                var periodResult = ParsePeriod(code);
                if (periodResult != string.Empty)
                {
                    return periodResult;
                }

                var intervalResult = ParseInterval(code);
                if (intervalResult != string.Empty)
                {
                    return intervalResult;
                }

                var targetResult = ParseTarget(code);
                if (targetResult != string.Empty)
                {
                    return targetResult;
                }

                var scenarioResult = ParseScenario(code);
                if (scenarioResult != string.Empty)
                {
                    return scenarioResult;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ParseAsset(List<TextLine> code)
        {
            TextLine? assetCode = null;
            try
            {
                assetCode = code.Find(x => x.Text.StartsWith("asset"));
                if (assetCode == null)
                {
                    TradingModel.Asset = 100000;
                    return string.Empty;
                }
                lineNumber = assetCode.LineNumber;
                var assetValue = assetCode.Text.Split('=')[1].Trim();
                var asset = decimal.Parse(assetValue);
                TradingModel.Asset = asset;
                return string.Empty;
            }
            catch
            {
                return $"asset 형식의 오류입니다. :: {assetCode}";
            }
        }

        public string ParsePeriod(List<TextLine> code)
        {
            TextLine? periodCode = null;
            try
            {
                periodCode = code.Find(x => x.Text.StartsWith("period"));
                if (periodCode == null)
                {
                    TradingModel.StartTime = DateTime.Now.AddDays(-7);
                    TradingModel.Period = new TimeSpan(7, 0, 0, 0);
                    return string.Empty;
                }
                lineNumber = periodCode.LineNumber;
                var periodValue = periodCode.Text.Split('=')[1].Trim();
                var startTimeString = periodValue.Split(':')[0];
                var periodString = periodValue.Split(':')[1];
                var startTimeSegments = startTimeString.Split(',');
                var periodSegments = periodString.Split(',');
                var startTime = new DateTime(
                    int.Parse(startTimeSegments[0]),
                    int.Parse(startTimeSegments[1]),
                    int.Parse(startTimeSegments[2]),
                    int.Parse(startTimeSegments[3]),
                    int.Parse(startTimeSegments[4]),
                    0
                    );
                var period = new TimeSpan(
                    int.Parse(periodSegments[0]) * 365 + int.Parse(periodSegments[1]) * 30 + int.Parse(periodSegments[2]),
                    int.Parse(periodSegments[3]),
                    int.Parse(periodSegments[4]),
                    0
                    );
                TradingModel.StartTime = startTime;
                TradingModel.Period = period;
                return string.Empty;
            }
            catch
            {
                return $"period 형식의 오류입니다. :: {periodCode}";
            }
        }

        public string ParseInterval(List<TextLine> code)
        {
            TextLine? intervalCode = null;
            try
            {
                intervalCode = code.Find(x => x.Text.StartsWith("interval"));
                if (intervalCode == null)
                {
                    TradingModel.Interval = Binance.Net.Enums.KlineInterval.OneMinute;
                    return string.Empty;
                }
                lineNumber = intervalCode.LineNumber;
                var intervalValue = intervalCode.Text.Split('=')[1].Trim();
                var interval = intervalValue.ToKlineInterval();
                TradingModel.Interval = interval;
                return string.Empty;
            }
            catch
            {
                return $"interval 형식의 오류입니다. :: {intervalCode}";
            }
        }

        public string ParseTarget(List<TextLine> code)
        {
            TextLine? targetCode = null;
            try
            {
                targetCode = code.Find(x => x.Text.StartsWith("target"));
                if (targetCode == null)
                {
                    TradingModel.Targets = new List<string>() { "BTCUSDT" };
                    return string.Empty;
                }
                lineNumber = targetCode.LineNumber;
                var targetValue = targetCode.Text.Split('=')[1].Trim();
                var target = targetValue.ToUpper();
                TradingModel.Targets.Add(target);
                return string.Empty;
            }
            catch
            {
                return $"target 형식의 오류입니다. :: {targetCode}";
            }
        }

        public string ParseScenario(List<TextLine> code)
        {
            TextLine? scenarioCode = null;
            try
            {
                for (int i = lineNumber; i < code.Max(x => x.LineNumber); i++)
                {
                    scenarioCode = code[i];
                    if (string.IsNullOrEmpty(scenarioCode.Text) || !scenarioCode.Text.Contains('='))
                    {
                        continue;
                    }
                    var key = scenarioCode.Text.Split('=')[0].Trim();
                    var value = scenarioCode.Text.Split('=')[1].Trim();

                    var strategyResult = ParseStrategy(key, value);
                    if (!string.IsNullOrEmpty(strategyResult))
                    {
                        return strategyResult + scenarioCode.ToString();
                    }
                }
                return string.Empty;
            }
            catch
            {
                return $"scenario 형식의 오류입니다. :: {scenarioCode}";
            }
        }

        public string ParseStrategy(string key, string value)
        {
            try
            {
                var keySegments = key.Split('.');
                switch (keySegments[2])
                {
                    case "signal":
                        var formula = ParseFormula(value);
                        if (formula == null)
                        {
                            return $"signal formula 형식의 오류입니다. :: ";
                        }
                        var signal = new Signal(formula);
                        TradingModel.AddSignal(keySegments[0], keySegments[1], signal);
                        break;
                    case "order":
                        var order = ParseOrder(value);
                        if (order == null)
                        {
                            return $"order 형식의 오류입니다. :: ";
                        }
                        TradingModel.AddOrder(keySegments[0], keySegments[1], order);
                        break;
                    default:
                        return $"scenario key 형식의 오류입니다. :: ";
                }
                return string.Empty;
            }
            catch
            {
                return $"strategy 형식의 오류입니다. :: ";
            }
        }

        public IFormula? ParseFormula(string signalValue)
        {
            try
            {
                var segments1 = signalValue.SplitKeep(new string[] { ">=", "<=", "!=" }).Select(x => x.Trim()).ToArray();
                //var segments1 = signalValue.Split(new string[] { ">=", "<=", "!=" }, StringSplitOptions.None);
                if (segments1.Length == 1)
                {
                    var segments2 = signalValue.SplitKeep(new string[] { ">", "<", "=" }).Select(x => x.Trim()).ToArray();
                    //var segments2 = signalValue.Split(new string[] { ">", "<", "=" }, StringSplitOptions.None);
                    if (segments2.Length == 1)
                    {
                        return null;
                    }
                    var chartElement = (ChartElement)Enum.Parse(typeof(ChartElement), segments2[0]);
                    var comparison = FormulaUtil.ToComparison(segments2[1]);
                    var value = double.Parse(segments2[2]);
                    return new ComparisonFormula(chartElement, comparison, value);
                }
                var chartElement2 = (ChartElement)Enum.Parse(typeof(ChartElement), segments1[0]);
                var comparison2 = FormulaUtil.ToComparison(segments1[1]);
                var value2 = double.Parse(segments1[2]);
                return new ComparisonFormula(chartElement2, comparison2, value2);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// long, 1, market (Fixed Symbol)
        /// long, 10t, market (Fixed (Tether))
        /// long, seed, 0.1, market (Seed)
        /// long, balance, 0.1, market (Balance)
        /// long, asset, 0.1, market (Asset)
        /// long, balancesymbol, 0.1, market (Balance Symbol)
        /// long, 20, limit, 42.50 (Limit(only fixed symbol))
        /// open, 0.1 (Open)
        /// close, 0.1 (Close)
        /// </summary>
        /// <param name="orderValue"></param>
        /// <returns></returns>
        public BackTestOrder? ParseOrder(string orderValue)
        {
            try
            {
                var segments = orderValue.Split(',').Select(x => x.Trim()).ToArray();
                if (segments.Length < 3)
                {
                    return null;
                }

                var positionSide = segments[0] switch
                {
                    "long" => PositionSide.Long,
                    "short" => PositionSide.Short,
                    "open" => PositionSide.Open,
                    "close" => PositionSide.Close,
                    _ => PositionSide.None
                };

                if (positionSide == PositionSide.Open || positionSide == PositionSide.Close)
                {
                    var _value = decimal.Parse(segments[1]);
                    return new BackTestOrder(OrderType.Market, positionSide, new OrderAmount(OrderAmountType.None, _value));
                }

                OrderType orderType = OrderType.None;
                OrderAmountType orderAmountType = OrderAmountType.None;
                decimal value = 0m;
                decimal? price = null;

                // Fixed Symbol
                if (decimal.TryParse(segments[1], out decimal d1))
                {
                    orderAmountType = OrderAmountType.FixedSymbol;
                    value = d1;

                    orderType = segments[2] switch
                    {
                        "market" => OrderType.Market,
                        "limit" => OrderType.Limit,
                        _ => OrderType.None
                    };
                    if (orderType == OrderType.Limit)
                    {
                        price = decimal.Parse(segments[3]);
                    }
                }
                // Fixed
                else if (decimal.TryParse(segments[1].Replace("t", ""), out decimal d2))
                {
                    orderAmountType = OrderAmountType.Fixed;
                    value = d2;

                    orderType = segments[2] switch
                    {
                        "market" => OrderType.Market,
                        _ => OrderType.None
                    };
                }
                else
                {
                    switch (segments[1])
                    {
                        case "seed":
                            orderAmountType = OrderAmountType.Seed;
                            value = decimal.Parse(segments[2]);
                            break;

                        case "balance":
                            orderAmountType = OrderAmountType.Balance;
                            value = decimal.Parse(segments[2]);
                            break;

                        case "asset":
                            orderAmountType = OrderAmountType.Asset;
                            value = decimal.Parse(segments[2]);
                            break;

                        case "balancesymbol":
                            orderAmountType = OrderAmountType.BalanceSymbol;
                            value = decimal.Parse(segments[2]);
                            break;
                    }

                    orderType = segments[3] switch
                    {
                        "market" => OrderType.Market,
                        _ => OrderType.None
                    };
                }

                var orderAmount = new OrderAmount(orderAmountType, value);
                return new BackTestOrder(orderType, positionSide, orderAmount, price);
            }
            catch
            {
                return null;
            }
        }
    }
}
