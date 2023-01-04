using Gaten.Net.Extensions;

using Newtonsoft.Json;

namespace Gaten.Web.Tarinance.Models.Market
{
    public class Asset
    {
        public string Id { get; set; }

        /// <summary>
        /// 코인 보유 수
        /// </summary>
        public string Quantity { get; set; }
        [JsonIgnore]
        public decimal _Quantity => Quantity.Convert<decimal>();

        /// <summary>
        /// 코인 총 매입금액
        /// </summary>
        public string Amount { get; set; }
        [JsonIgnore]
        public decimal _Amount => Amount.Convert<decimal>();

        public Asset()
        {

        }

        public Asset(string id, string quantity, string amount)
        {
            Id = id;
            Quantity = quantity;
            Amount = amount;
        }
    }
}
