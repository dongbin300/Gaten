using Gaten.Net.Data.Diagnostics;
using Gaten.Net.Data.IO;
using Gaten.Net.Network;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// HardwarePrice.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HardwarePrice : Window
    {
        public static List<Device> Devices = new();
        public static bool First = true;

        public HardwarePrice()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        public static void Init()
        {
            LoadTextFile();
        }

        public static void SaveTextFile()
        {
            DateTime now = DateTime.Now;
            StringBuilder builder = new();
            builder.AppendLine("저장: " + now.ToString());
            builder.AppendLine();
            foreach (Device d in Devices)
            {
                switch (d.type)
                {
                    case Device.Types.Product:
                        builder.AppendLine($"P|{d.name}|{d.url}|{d.price}|{d.cashPrice}|{d.changePrice}|{d.changeCash}");
                        break;
                    case Device.Types.Sum:
                        builder.AppendLine($"S|{d.name}|{d.price}|{d.cashPrice}|{d.changePrice}|{d.changeCash}");
                        break;
                }
            }

            File.WriteAllText(Path.Combine(GResource.GetPath("hm"), "" + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + ".txt"), builder.ToString());
        }

        public static void LoadTextFile()
        {
            var files = new DirectoryInfo(GResource.GetPath("hm")).GetFiles("*.txt").ToList();
            var filePath = files[Enumerable.Range(0, files.Count).Aggregate((max, i) => files[max].LastWriteTime > files[i].LastWriteTime ? max : i)].FullName;

            var data = File.ReadAllLines(filePath);
            foreach (var d in data)
            {
                var d2 = d.Split('|');
                switch (d2[0])
                {
                    case "P":
                        Devices.Add(new Device
                        {
                            type = Device.Types.Product,
                            name = d2[1],
                            url = d2[2],
                            forePrice = d2[3],
                            foreCashPrice = d2[4]
                        });
                        break;
                    case "S":
                        Devices.Add(new Device
                        {
                            type = Device.Types.Sum,
                            name = d2[1],
                            forePrice = d2[2],
                            foreCashPrice = d2[3]
                        });
                        break;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveTextFile();
        }

        private void HardwareDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GProcess.Start(Devices[HardwareDataGrid.Items.IndexOf(HardwareDataGrid.CurrentItem)].url);
        }

        public void SearchHardwarePrice()
        {
            try
            {
                HardwareDataGrid.Items.Clear();

                foreach (Device device in Devices)
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

                    HardwareDataGrid.Items.Add(new string[] { device.name, device.price, device.changePrice });
                }
                First = false;
            }
            catch
            {

            }
        }

        public void RefreshHardwarePrice()
        {
            // 이전에 조사했던 가격은 이전가격으로 설정
            foreach (Device device in Devices)
            {
                if (device.price == null) continue;
                device.forePrice = device.price;
                if (device.cashPrice == null) continue;
                device.foreCashPrice = device.cashPrice;
            }

            // 지우고
            HardwareDataGrid.Items.Clear();

            // 새롭게 조사
            SearchHardwarePrice();
        }

        //public static string GetSumPrice(DataGridView dataGridView)
        //{
        //    int cpu = int.Parse(dataGridView.Rows[9].Cells[1].Value.ToString().Split('(')[0].Replace(",", ""));
        //    int mainBoard = int.Parse(dataGridView.Rows[14].Cells[1].Value.ToString().Split('(')[0].Replace(",", ""));
        //    int ram = int.Parse(dataGridView.Rows[2].Cells[1].Value.ToString().Split('(')[0].Replace(",", ""));
        //    int ssd = int.Parse(dataGridView.Rows[15].Cells[1].Value.ToString().Split('(')[0].Replace(",", ""));
        //    int power = int.Parse(dataGridView.Rows[16].Cells[1].Value.ToString().Split('(')[0].Replace(",", ""));

        //    int sum = cpu + mainBoard + ram + ssd + power;

        //    return sum.ToString();
        //}
    }

    public class Device
    {
        public enum Types { Product, Sum }
        public Types type;
        public string name;
        public string url;
        public string price, forePrice, changePrice;
        public string cashPrice, foreCashPrice, changeCash;
    }
}
