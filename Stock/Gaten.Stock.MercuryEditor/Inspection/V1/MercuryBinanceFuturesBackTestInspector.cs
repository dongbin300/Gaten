using Gaten.Net.Stock.MercuryTradingModel.Intervals;
using Gaten.Net.Stock.MercuryTradingModel.Orders;
using Gaten.Net.Stock.MercuryTradingModel.Signals.Primitives;
using Gaten.Net.Stock.MercuryTradingModel.TradingModels;
using Gaten.Stock.MercuryEditor.Editor;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.MercuryEditor.Inspection.V1
{
    /// <summary>
    /// default value
    /// asset: 100000
    /// period: -7일~현재
    /// interval: 1m
    /// target: btcusdt
    /// 
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
                if(assetResult != string.Empty)
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
                var periodSegments = periodValue.Split(',');
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
                var target = targetValue;
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
                for (int i = lineNumber + 1; i <= code.Max(x => x.LineNumber); i++)
                {
                    scenarioCode = code[i];
                    if (string.IsNullOrEmpty(scenarioCode.Text))
                    {
                        continue;
                    }
                    var key = scenarioCode.Text.Split('=')[0].Trim();
                    var value = scenarioCode.Text.Split('=')[1].Trim();

                    var keyResult = ParseKeyPart(key);
                    if (!string.IsNullOrEmpty(keyResult))
                    {
                        return keyResult + scenarioCode.ToString();
                    }
                    var valueResult = ParseValuePart(value);
                    if (!string.IsNullOrEmpty(valueResult))
                    {
                        return valueResult + scenarioCode.ToString();
                    }
                }
                return string.Empty;
            }
            catch
            {
                return $"scenario 형식의 오류입니다. :: {scenarioCode}";
            }
        }

        public string ParseKeyPart(string keyString)
        {
            try
            {
                var keySegments = keyString.Split('.');
                switch (keySegments[2])
                {
                    case "signal":
                        TradingModel.AddSignal(keySegments[0], keySegments[1], new Signal()); // TODO
                        break;
                    case "order":
                        TradingModel.AddOrder(keySegments[0], keySegments[1], new Order()); // TODO
                        break;
                    default:
                        return $"scenario key 형식의 오류입니다. :: ";
                }
                return string.Empty;
            }
            catch
            {
                return $"scenario key 형식의 오류입니다. :: ";
            }
        }

        public string ParseValuePart(string valueString)
        {
            try
            {
                return string.Empty;
            }
            catch
            {
                return $"scenario value 형식의 오류입니다. :: ";
            }
        }
    }
}
