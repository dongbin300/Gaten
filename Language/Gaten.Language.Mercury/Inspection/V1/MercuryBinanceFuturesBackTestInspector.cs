using Gaten.Language.Mercury.Editor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Language.Mercury.Inspection.V1
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
        

        public MercuryBinanceFuturesBackTestInspector()
        {

        }

        public void Run(List<TextLine> code)
        {
            var assetCode = code.Find(x => x.Text.StartsWith("asset"));
            if(assetCode == null)
            {

            }
        }
    }
}
