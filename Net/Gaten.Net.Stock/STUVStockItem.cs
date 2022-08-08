using Gaten.Net.Network.MySql;

namespace Gaten.Net.Stock
{
    public class STUVStockItem
    {
        /// <summary>
        /// 종목코드
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 종목명
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 현재가
        /// </summary>
        public int CurrentPrice { get; set; }

        /// <summary>
        /// 전일대비
        /// </summary>
        public int PreDay { get; set; }

        /// <summary>
        /// 등락률
        /// </summary>
        public double FlucRate { get; set; }

        /// <summary>
        /// 거래량
        /// </summary>
        public double TradingVolume { get; set; }

        /// <summary>
        /// 거래내역(Big Data)
        /// </summary>
        public List<TransactionInfo> TransactionData { get; set; } = new();

        public TransactionInfo LatestTransaction => GetLatestTransactionDataFromDb();

        public STUVStockItem(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public TransactionInfo GetLatestTransactionDataFromDb()
        {
            try
            {
                var manager = new MySqlManager("EXTERNAL");
                var data = manager.SelectByTableName("STUV" + Code, "ORDER BY time DESC LIMIT 1");

                string[] timeData = data[0]["time"].Split('-');
                var time = new DateTime(int.Parse(timeData[0]), int.Parse(timeData[1]), int.Parse(timeData[2]), int.Parse(timeData[3]), int.Parse(timeData[4]), int.Parse(timeData[5]));

                return new TransactionInfo()
                {
                    Time = time,
                    Price = int.Parse(data[0]["price"]),
                    Volume = int.Parse(data[0]["volume"]),
                    TransactionType = data[0]["type"] == "1" ? TransactionType.Buy : TransactionType.Sell,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
