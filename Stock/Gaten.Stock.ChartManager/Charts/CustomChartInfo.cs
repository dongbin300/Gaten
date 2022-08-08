
using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;

namespace Gaten.Stock.ChartManager.Charts
{
    public class CustomChartInfo
    {
        public DateTime Date { get; set; }
        public List<int> Frequencies { get; set; }

        public CustomChartInfo(DateTime date, List<Quote> quotes)
        {
            Date = date;
            Frequencies = ChartUtil.GetSwp(quotes);
        }
    }
}
