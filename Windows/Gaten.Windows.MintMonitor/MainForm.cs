using Gaten.Net.Data;
using Gaten.Net.Network;

using System.Text;

namespace Gaten.Windows.MintMonitor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainTimer.Stop();
            ClockTimer.Stop();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WebCrawler.Open();
            WeatherText.Text = Weather.Get();
            StockText.Text = Stock.Get();
            HardwarePrice.Init();
            SearchHardwarePrice();
            DiskDriveText.Text = DiskDrive.Get();
            UnseText.Text = Unse.Get();

            DictListBox.HorizontalScrollbar = true;
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            if (now.Minute == 1)
            {
                WeatherText.Text = Weather.Get();
                RefreshHardwarePrice();
            }

            if (now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday)
            {
                if (now.Hour >= 9 && now.Hour <= 16)
                {
                    if (now.Minute % 5 == 0)
                    {
                        StockText.Text = Stock.Get();
                    }
                }
            }

            if(now.Hour == 0 && now.Minute == 10)
            {
                DiskDriveText.Text = DiskDrive.Get();
                UnseText.Text = Unse.Get();
            }
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            ClockText.Text = $"{DateTime.Now:yyyy'년' MMM d'일' dddd tt hh:mm:ss}";
        }

        private void ColorPickButton_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
        }

        private void BadukButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((sender as Button).Text);
        }

        private void BadukButtonChange_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Clipboard.GetText().Replace("韩", "ㅁ").Replace("中", "韩").Replace("ㅁ", "中"));
        }

        private void DictTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DictTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                WebCrawler.SetUrl($"https://dict.naver.com/search.nhn?dicQuery={DictTextBox.Text}&query={DictTextBox.Text}&target=dic&ie=utf8&query_utf=&isOnlyViewEE=");

                DictListBox.Items.Clear();
                var nodes = WebCrawler.SelectNodes("//dl[@class='dic_search_result']/dd");
                foreach (var node in nodes)
                {
                    DictListBox.Items.Add(
                        node.InnerText.Trim()
                        .Replace("\t ", "")
                        .Replace("\t", "")
                        .Replace("\r\n", ""));
                }
            }
        }

        #region Hardware Price Monitoring
        private void HardwareTextFileButton_Click(object sender, EventArgs e)
        {
            HardwarePrice.SaveTextFile();
        }

        private void HardwarePriceDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Process.Start(HardwarePrice.Devices[e.RowIndex].url);
        }

        public void SearchHardwarePrice()
        {
            try
            {
                foreach (Device device in HardwarePrice.Devices)
                {
                    WebCrawler.SetUrl(device.url);
                    var a = WebCrawler.SelectNode("//div[contains(@class,'lowest_price')]//em[@class='prc_c']");
                    device.price = a == null ? "0" : a.InnerText;
                    a = WebCrawler.SelectNode("//div[contains(@id,'lowPriceCash')]//em[@class='prc_c']");
                    device.cashPrice = a == null ? "0" : a.InnerText;

                    int gap = int.Parse(device.price.Replace(",", "")) - int.Parse(device.forePrice.Replace(",", ""));
                    device.changePrice = gap >= 0 ? $"▲{Math.Abs(gap)}" : $"▼{Math.Abs(gap)}";
                    gap = int.Parse(device.cashPrice.Replace(",", "")) - int.Parse(device.foreCashPrice.Replace(",", ""));
                    device.changeCash = gap >= 0 ? $"▲{Math.Abs(gap)}" : $"▼{Math.Abs(gap)}";

                    HardwarePriceDataGridView.Rows.Add(new string[] { device.name, device.price, device.cashPrice, device.changePrice, device.changeCash });
                }
                HardwarePrice.first = false;
            }
            catch
            {

            }
        }

        public void RefreshHardwarePrice()
        {
            // 이전에 조사했던 가격은 이전가격으로 설정
            foreach (Device device in HardwarePrice.Devices)
            {
                if (device.price == null) continue;
                device.forePrice = device.price;
                if (device.cashPrice == null) continue;
                device.foreCashPrice = device.cashPrice;
            }

            // 지우고
            HardwarePriceDataGridView.Rows.Clear();

            // 새롭게 조사
            SearchHardwarePrice();
        }
        #endregion

    }
}