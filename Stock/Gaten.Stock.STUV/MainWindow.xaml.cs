using Gaten.Net.Stock;

using System.Windows;

namespace Gaten.Stock.STUV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            STUVStockManager.Init();
            STUVStockManager.SelectedStock = STUVStockManager.GetStockItem("01");
            SelectedStockChanged();
        }

        void SelectedStockChanged()
        {
            StockCodeText.Text = STUVStockManager.SelectedStock.Code;
            StockNameText.Text = STUVStockManager.SelectedStock.Name;
        }
    }
}
