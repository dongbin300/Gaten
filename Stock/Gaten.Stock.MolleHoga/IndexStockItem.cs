using Gaten.Net.Stock;

namespace Gaten.Stock.MolleHoga
{
    internal class IndexStockItem
    {
        /// <summary>
        /// 인덱스
        /// </summary>
        public int Index { get; set; }

        public StockItem Item { get; set; } = new();
    }
}
