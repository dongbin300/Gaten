namespace Gaten.Stock.MarinerX.Accounts
{
    internal class FuturesBalance
    {
        public string AssetName { get; set; }
        public decimal Wallet { get; set; }
        public decimal Available { get; set; }
        public decimal UnrealizedPnl { get; set; }
    }
}
