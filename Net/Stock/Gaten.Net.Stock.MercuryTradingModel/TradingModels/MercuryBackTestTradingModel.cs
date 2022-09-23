using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Stock.MercuryTradingModel.TradingModels
{
    /// <summary>
    /// default value
    /// asset: 100000
    /// period: -7일~현재
    /// interval: 1m
    /// target: btcusdt
    /// 
    /// 10k->10000
    /// 
    /// </summary>
    public class MercuryBackTestTradingModel
    {
        public decimal Asset { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Period { get; set; }
        public string Interval { get; set; }
        public IList<string> Targets { get; set; }
        public IList<IScenario> Scenarios { get; set; }

        public MercuryBackTestTradingModel()
        {

        }
    }
}
