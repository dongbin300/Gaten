using Gaten.Net.IO;

using OfficeOpenXml;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.BinanceHelper
{
    internal class TradeHistoryParser
    {
        private static readonly string DefaultTargetPath = GPath.Desktop.Down("Export Trade History.xlsx");
        private const string TargetSheetName = "sheet1";
        private const int MaxLoopCount = 10000; // Dummy Value just in case

        private static readonly IList<TradeHistory> tradeHistoriesList = new List<TradeHistory>();
        private static readonly IDictionary<string, List<TradeHistory>> tradeHistoriesDict = new Dictionary<string, List<TradeHistory>>();

        private static int lastExcelSheetDataRow;
        private static string currentTargetPath;

        private void ClearHistory()
        {
            tradeHistoriesList.Clear();
            tradeHistoriesDict.Clear();
        }

        public void ParseContent(string targetPath = "")
        {
            ClearHistory();

            if (string.IsNullOrEmpty(targetPath))
            {
                targetPath = DefaultTargetPath;
                currentTargetPath = DefaultTargetPath;
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage package = new(targetPath);
            ExcelWorksheet? targetSheet = package.Workbook.Worksheets[TargetSheetName];

            lastExcelSheetDataRow = 0;
            do
            {
                if (++lastExcelSheetDataRow >= MaxLoopCount)
                {
                    throw new Exception("MaxLoopCount 초과 (행 개수 오류)");
                }
            }
            while (targetSheet.Cells[lastExcelSheetDataRow, 1].Value != null);
            if (--lastExcelSheetDataRow <= 1)
            {
                throw new Exception("분석할 행이 존재하지 않음 (행 개수 오류)");
            }

            for (int row = 2; row <= lastExcelSheetDataRow; row++)
            {
                string symbol = targetSheet.Cells[row, 2].Value.ToString();
                TradeHistory? tradeHistory = new(
                    symbol,
                    double.Parse(targetSheet.Cells[row, 7].Value.ToString()),
                    targetSheet.Cells[row, 8].Value.ToString(),
                    double.Parse(targetSheet.Cells[row, 9].Value.ToString())
                );

                tradeHistoriesList.Add(tradeHistory);

                if (!tradeHistoriesDict.ContainsKey(symbol))
                {
                    tradeHistoriesDict[symbol] = new List<TradeHistory>();
                }
                tradeHistoriesDict[symbol].Add(tradeHistory);
            }

            IEnumerable<TradeHistoryResult>? test = tradeHistoriesList
                .GroupBy(x => x.Symbol)
                .Select(x => new TradeHistoryResult(
                    symbol: x.First().Symbol,
                    fee: x.Sum(y => y.Fee),
                    feeCoin: x.First().FeeCoin,
                    realizedProfit: x.Sum(y => y.RealizedProfit)
                    ));
        }

        private class TradeHistory
        {
            public string Symbol { get; set; }
            public double Fee { get; set; }
            public string FeeCoin { get; set; }
            public double RealizedProfit { get; set; }

            public TradeHistory(string symbol, double fee, string feeCoin, double realizedProfit)
            {
                Symbol = symbol;
                Fee = fee;
                FeeCoin = feeCoin;
                RealizedProfit = realizedProfit;
            }
        }

        private class TradeHistoryResult
        {
            public string Symbol { get; set; }
            public double Fee { get; set; }
            public string FeeCoin { get; set; }
            public double RealizedProfit { get; set; }

            public TradeHistoryResult(string symbol, double fee, string feeCoin, double realizedProfit)
            {
                Symbol = symbol;
                Fee = fee;
                FeeCoin = feeCoin;
                RealizedProfit = realizedProfit;
            }

            public new string ToString()
            {
                return $"[{Symbol}] {RealizedProfit - Fee}{FeeCoin} ({RealizedProfit} - {Fee})";
            }
        }
    }
}
