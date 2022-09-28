namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface ISignal
    {
        public bool Flare => IsFlare();

        public abstract bool IsFlare();
    }
}
