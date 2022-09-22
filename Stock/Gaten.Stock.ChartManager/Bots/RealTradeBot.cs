using Gaten.Stock.ChartManager.Interfaces;

namespace Gaten.Stock.ChartManager.Bots
{
    internal class RealTradeBot : IBot
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
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
