using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Orders;
using Gaten.Net.Stock.MercuryTradingModel.Signals.Primitives;

namespace Gaten.Net.Stock.MercuryTradingModel.Triggers
{
    public class Strategy : IStrategy
    {
        public string Name { get; set; } = string.Empty;
        public ISignal Signal { get; set; } = new Signal();
        public IOrder Order { get; set; } = new Order();

        public Strategy()
        {

        }

        public Strategy(string name)
        {
            Name = name;
        }
    }
}
