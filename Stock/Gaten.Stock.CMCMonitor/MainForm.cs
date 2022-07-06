using CoinMarketCap;

using Gaten.Net.Data.IO;

namespace Gaten.Stock.CMCMonitor
{
    public partial class MainForm : Form
    {
        CoinMarketCapClient client;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string apiKey = GResource.GetText("coinmarketcap_api.txt");
            client = new CoinMarketCapClient(apiKey);
            var result = Task.Run(async () =>
            {
                var a = await client.GetLatestQuoteAsync(new CoinMarketCap.Models.Cryptocurrency.LatestQuoteParameters()
                {
                    Symbol = "GST"
                }, CancellationToken.None);
                return a;
            }).Result;
        }
    }
}