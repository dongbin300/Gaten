﻿namespace Gaten.Net.Stock.MercuryTradingModel.Assets
{
    public class Asset
    {
        /// <summary>
        /// 현금 잔고
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 포지션
        /// </summary>
        public Position Position { get; set; } = new();

        public void Buy(decimal price, decimal quantity)
        {
            Balance -= price;
            Position.Long(quantity);
        }

        public void Sell(decimal price, decimal quantity)
        {
            Balance += price;
            Position.Short(quantity);
        }
    }
}