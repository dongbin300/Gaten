using Gaten.Net.Stock;
using Gaten.Net.Windows;

using System;

namespace Gaten.Stock.MolleHoga
{
    public partial class MainForm : Form
    {
        List<StockItem> items;
        List<IndexStockItem> monitorItems;

        public MainForm()
        {
            InitializeComponent();

            ContextMenuStrip = Menu;
            toolStripMenuItem6_Click(null, null);

            items = new List<StockItem>();
            monitorItems = new List<IndexStockItem>();
        }

        public void Init()
        {
            for (int i = 1; i <= 10; i++)
            {
                string keyword = "StockName" + i.ToString();
                string name = Settings.Default[keyword].ToString();
                if (string.IsNullOrEmpty(name))
                {
                    break;
                }

                switch (i)
                {
                    case 1: Name1.Text = name; break;
                    case 2: Name2.Text = name; break;
                    case 3: Name3.Text = name; break;
                    case 4: Name4.Text = name; break;
                    case 5: Name5.Text = name; break;
                        //case 6: Name6.Text = name; break;
                        //case 7: Name7.Text = name; break;
                        //case 8: Name8.Text = name; break;
                        //case 9: Name9.Text = name; break;
                        //case 10: Name10.Text = name; break;
                }

                var item = items.Find(t => t.Name.Equals(name));

                if (item == null)
                {
                    continue;
                }

                monitorItems.Add(new IndexStockItem()
                {
                    Index = i,
                    Item = item
                });
            }
            MainTimer.Start();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinApi.ReleaseCapture();
                WinApi.SendMessage(Handle, WinApi.WM_NCLBUTTONDOWN, WinApi.HT_CAPTION, 0);
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip.Show();
            }
            else
            {
                ContextMenuStrip.Hide();
            }
        }

        #region Menu Item
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void AllClear()
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
            toolStripMenuItem9.Checked = false;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem11.Checked = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Opacity = 0.1;
            AllClear();
            toolStripMenuItem2.Checked = true;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Opacity = 0.2;
            AllClear();
            toolStripMenuItem3.Checked = true;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Opacity = 0.3;
            AllClear();
            toolStripMenuItem4.Checked = true;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Opacity = 0.4;
            AllClear();
            toolStripMenuItem5.Checked = true;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Opacity = 0.5;
            AllClear();
            toolStripMenuItem6.Checked = true;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Opacity = 0.6;
            AllClear();
            toolStripMenuItem7.Checked = true;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Opacity = 0.7;
            AllClear();
            toolStripMenuItem8.Checked = true;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Opacity = 0.8;
            AllClear();
            toolStripMenuItem9.Checked = true;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Opacity = 0.9;
            AllClear();
            toolStripMenuItem10.Checked = true;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Opacity = 1.0;
            AllClear();
            toolStripMenuItem11.Checked = true;
        }
        #endregion

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            // 개장시간에는 2초마다 새로고침
            if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour <= 15)
            {
                MainTimer.Interval = 2000;
            }
            else
            {
                MainTimer.Interval = 100000;
            }

            try
            {
                // 모니터아이템 최신화
                monitorItems.Clear();
                AddMonitorItem(1, Name1.Text);
                AddMonitorItem(2, Name2.Text);
                AddMonitorItem(3, Name3.Text);
                AddMonitorItem(4, Name4.Text);
                AddMonitorItem(5, Name5.Text);

                // 모니터아이템 주식정보 조회
                foreach (var item in monitorItems)
                {
                    if (item.Item == null)
                    {
                        break;
                    }
                }

                RefreshItemInfo(1, Name1.Text, Spot1, UpDown1);
                RefreshItemInfo(2, Name2.Text, Spot2, UpDown2);
                RefreshItemInfo(3, Name3.Text, Spot3, UpDown3);
                RefreshItemInfo(4, Name4.Text, Spot4, UpDown4);
                RefreshItemInfo(5, Name5.Text, Spot5, UpDown5);
            }
            catch
            {

            }


        }

        void AddMonitorItem(int index, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                monitorItems.Add(new IndexStockItem()
                {
                    Index = index,
                    Item = items.Find(t => t.Name.Equals(text))
                });
            }
        }

        void RefreshItemInfo(int index, string text, Label label1, Label label2)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var item = monitorItems.Find(m => m.Index.Equals(index)).Item;

                if (item == null)
                {
                    return;
                }

                label1.Text = item.SpotPriceString;
                label2.Text = item.DayOnDayPercentString;
            }
        }

        //private void OnReceive(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        //{
        //    if (e.sRQName.Equals("주식기본정보"))
        //    {
        //        string code = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();
        //        string spotPrice = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim();
        //        string dod = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "전일대비").Trim();
        //        string dodp = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "등락율").Trim();

        //        var preItem = monitorItems.Find(m => m.Item != null && m.Item.Code.Equals(code));
        //        if (preItem == null)
        //        {
        //            return;
        //        }

        //        var item = preItem.Item;
        //        item.SpotPrice = int.Parse(spotPrice);
        //        item.DayOnDay = int.Parse(dod);
        //        item.DayOnDayPercent = double.Parse(dodp);
        //        item.IsPlus = dod[0] == '+';
        //    }
        //}

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default["StockName1"] = Name1.Text;
            Settings.Default["StockName2"] = Name2.Text;
            Settings.Default["StockName3"] = Name3.Text;
            Settings.Default["StockName4"] = Name4.Text;
            Settings.Default["StockName5"] = Name5.Text;
            Settings.Default.Save();
            MainTimer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //foreach (var item in monitorItems)
            //{
            //    axKHOpenAPI.SetInputValue("종목코드", item.Item.Code);
            //    int rv = axKHOpenAPI.CommRqData("주식기본정보", "OPT10001", 0, "1002");
            //    if (rv < 0)
            //    {
            //        MessageBox.Show("주식기본정보 조회 실패");
            //    }
            //}
        }

        private void 초기화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //axKHOpenAPI.OnReceiveTrData += OnReceive;

            //// 코스피 종목 조회
            //string[] data = axKHOpenAPI.GetCodeListByMarket("0").Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var d in data)
            //{
            //    string name = axKHOpenAPI.GetMasterCodeName(d);
            //    items.Add(new StockItem()
            //    {
            //        Code = d,
            //        Name = name
            //    });
            //}
            //// 코스닥 종목 조회
            //data = axKHOpenAPI.GetCodeListByMarket("10").Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var d in data)
            //{
            //    string name = axKHOpenAPI.GetMasterCodeName(d);
            //    items.Add(new StockItem()
            //    {
            //        Code = d,
            //        Name = name
            //    });
            //}

            Init();
        }
    }
}