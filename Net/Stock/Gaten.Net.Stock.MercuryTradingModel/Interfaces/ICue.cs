﻿using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;

namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface ICue
    {
        public IFormula Formula { get; set; }
        public int Life { get; set; }
        public int CurrentLife { get; set; }
        public abstract bool CheckFlare(Asset asset, ChartInfo chart);
        public abstract void Expire();
    }
}
