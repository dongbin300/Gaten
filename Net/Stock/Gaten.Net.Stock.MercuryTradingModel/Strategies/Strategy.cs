using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Orders;
using Gaten.Net.Stock.MercuryTradingModel.Signals;

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

        public Strategy(string name) : this()
        {
            Name = name;
        }

        public Strategy(string name, ISignal signal) : this(name)
        {
            Signal = signal;
        }

        public Strategy(string name, IOrder order) : this(name)
        {
            Order = order;
        }

        public Strategy(string name, ISignal signal, IOrder order) : this(name)
        {
            Signal = signal;
            Order = order;
        }
    }
}
