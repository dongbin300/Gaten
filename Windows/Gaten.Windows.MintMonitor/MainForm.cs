using Gaten.Net.Network;

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
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            if (now.Minute == 1)
            {
                WeatherText.Text = Weather.Get();
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

        
    }
}