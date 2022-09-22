using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Stock.ChartManager.Interfaces;
using Gaten.Stock.ChartManager.Markets;

using System.Collections.Generic;
using System.Threading;

namespace Gaten.Stock.ChartManager.Bots
{
    internal class BackTestBot : IBot
    {
        private bool disposedValue;
        private Thread MainThread { get; set; }

        public List<FuturesSymbol> Symbols { get; set; } = new();
        public ITradingModel TradingModel { get; set; }
        public bool IsRunning { get; set; }

        public BackTestBot(List<FuturesSymbol> symbols, ITradingModel tradingModel)
        {
            Symbols = symbols;
            TradingModel = tradingModel;

            MainThread = new Thread(new ThreadStart(Run));
            MainThread.Start();
        }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Run()
        {
            while (true)
            {
                while (IsRunning)
                {
                    if(TradingModel.ScenarioNameInProgress != string.Empty)
                    {
                        // 진행중인 시나리오가 있음
                    }
                    else
                    {
                        foreach(var scenario in TradingModel.Scenarios)
                        {
                            foreach(var trigger in scenario.Triggers)
                            {

                            }
                        }
                    }
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    MainThread.Join();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
