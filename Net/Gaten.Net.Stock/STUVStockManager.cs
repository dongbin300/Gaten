using Gaten.Net.Network.MySql;

namespace Gaten.Net.Stock
{
    public class STUVStockManager
    {
        public static List<STUVStockItem> StockItems { get; set; }
        public static STUVStockItem SelectedStock { get; set; }

        public static void Init()
        {
            GetStockInfo();
        }

        static void GetStockInfo()
        {
            StockItems = new List<STUVStockItem>();

            var manager = new MySqlManager("EXTERNAL");
            var data = manager.SelectByTableName("STUV");

            foreach (var item in data)
            {
                STUVStockItem stock = new(item["code"], item["name"]);
                StockItems.Add(stock);
            }
        }

        public static STUVStockItem GetStockItem(string code)
        {
            return StockItems.Find(s => s.Code.Equals(code, StringComparison.Ordinal));
        }
    }
}
