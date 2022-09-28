namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface ISignal
    {
        public bool Flare => IsFlare();
        public IFormula Formula { get; set; }

        public abstract bool IsFlare();
    }
}
