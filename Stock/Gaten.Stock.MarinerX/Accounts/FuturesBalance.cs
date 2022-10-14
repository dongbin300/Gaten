namespace Gaten.Stock.MarinerX.Accounts
{
    internal class FuturesBalance
    {
        public string AssetName { get; set; }
        public decimal Wallet { get; set; }
        public decimal Available { get; set; }
        public decimal UnrealizedPnl { get; set; }

        public FuturesBalance(string assetName, decimal wallet, decimal available, decimal unrealizedPnl)
        {
            AssetName = assetName;
            Wallet = wallet;
            Available = available;
            UnrealizedPnl = unrealizedPnl;
        }
    }
}
