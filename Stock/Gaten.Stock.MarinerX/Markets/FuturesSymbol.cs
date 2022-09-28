using Binance.Net.Enums;

using System;

namespace Gaten.Stock.MarinerX.Markets
{
    internal class FuturesSymbol
    {
        public string Name { get; set; }
        public decimal LiquidationFee { get; set; }
        public DateTime ListingDate { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
        public decimal TickSize { get; set; }
        public decimal MaxQuantity { get; set; }
        public decimal MinQuantity { get; set; }
        public decimal StepSize { get; set; }
        public int PricePrecision { get; set; }
        public int QuantityPrecision { get; set; }
        public UnderlyingType UnderlyingType { get; set; }

        public FuturesSymbol(string name, decimal liquidationFee, DateTime listingDate, decimal maxPrice, decimal minPrice, decimal tickSize, decimal maxQuantity, decimal minQuantity, decimal stepSize, int pricePrecision, int quantityPrecision, UnderlyingType underlyingType)
        {
            Name = name;
            LiquidationFee = liquidationFee;
            ListingDate = listingDate;
            MaxPrice = maxPrice;
            MinPrice = minPrice;
            TickSize = tickSize;
            MaxQuantity = maxQuantity;
            MinQuantity = minQuantity;
            StepSize = stepSize;
            PricePrecision = pricePrecision;
            UnderlyingType = underlyingType;
        }
    }
}
