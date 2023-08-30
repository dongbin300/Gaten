using Gaten.Net.IO;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using XCommas.Net;

namespace Gaten.Windows.SuperMonitor
{
    public class XCommasManager
    {
        public static XCommasApi Api { get; set; } = default!;
        private static double preTopRoe = -39909;

        public static void Init()
        {
            var keyData = File.ReadAllLines(GResource.BaseFilePath.Down("3commas.txt"));
            Api = new XCommasApi(keyData[0], keyData[1]);
        }

        public static double GetTodayRealizedProfit()
        {
            try
            {
                return (double)Math.Round(Api.GetBotStats().Data.TodayStats["USDT"], 3);
            }
            catch
            {
                return -1;
            }
        }

        public static double GetTopRoe()
        {
            try
            {
                var result = Api.GetDeals(100, 0, null, null, XCommas.Net.Objects.DealScope.Active);
                var deals = JsonConvert.DeserializeObject<IEnumerable<XcommasDeal>>(result.RawData);
                preTopRoe = deals.Max(x => double.Parse(x.actual_profit_percentage));

                return preTopRoe;
            }
            catch
            {
                return preTopRoe;
            }
        }
    }

    public class XcommasDeal
    {
        public string actual_profit_percentage { get; set; }
    }
}
