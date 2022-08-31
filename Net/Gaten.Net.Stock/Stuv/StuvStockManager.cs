using Gaten.Net.Network.MySql;

namespace Gaten.Net.Stock.STUV
{
    public class STUVStockManager
    {
        public static List<StuvStockItem> StockItems { get; set; } = new();
        public static StuvStockItem SelectedStock { get; set; } = default!;

        public static void Init()
        {
            GetStockInfo();
        }

        static void GetStockInfo()
        {
            var manager = new MySqlManager("EXTERNAL");
            var data = manager.SelectByTableName("STUV");

            foreach (var item in data)
            {
                StuvStockItem stock = new(item["code"], item["name"]);
                StockItems.Add(stock);
            }
        }

        public static StuvStockItem GetStockItem(string code)
        {
            return StockItems.Find(s => s.Code.Equals(code, StringComparison.Ordinal)) ?? default!;
        }
    }
}
