using Gaten.Net.Diagnostics;
using Gaten.Net.IO;
using Gaten.Net.Network;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
                switch (d.Type)
                {
                    case Device.Types.Product:
                        builder.AppendLine($"P|{d.Name}|{d.Url}|{d.Price}|{d.CashPrice}|{d.ChangePrice}|{d.ChangeCash}");
                        break;
                    case Device.Types.Sum:
                        builder.AppendLine($"S|{d.Name}|{d.Price}|{d.CashPrice}|{d.ChangePrice}|{d.ChangeCash}");
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
                            Type = Device.Types.Product,
                            Name = d2[1],
                            Url = d2[2],
                            PrevPrice = d2[3],
                            PrevCashPrice = d2[4]
                        });
                        break;
                    case "S":
                        Devices.Add(new Device
                        {
                            Type = Device.Types.Sum,
                            Name = d2[1],
                            PrevPrice = d2[2],
                            PrevCashPrice = d2[3]
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
            GProcess.Start(Devices[HardwareDataGrid.Items.IndexOf(HardwareDataGrid.CurrentItem)].Url);
        }

        public void SearchHardwarePrice()
        {
            try
            {
                HardwareDataGrid.Items.Clear();
                foreach (Device device in Devices)
                {
                    WebCrawler.SetUrl(device.Url);
                    var a = WebCrawler.SelectNode("//div[contains(@class,'lowest_price')]//em[@class='prc_c']");
                    device.Price = a == null ? "0" : a.InnerText;
                    a = WebCrawler.SelectNode("//div[contains(@id,'lowPriceCash')]//em[@class='prc_c']");
                    device.CashPrice = a == null ? "0" : a.InnerText;

                    int gap = int.Parse(device.Price.Replace(",", "")) - int.Parse(device.PrevPrice.Replace(",", ""));
                    device.ChangePrice = gap >= 0 ? $"▲{Math.Abs(gap)}" : $"▼{Math.Abs(gap)}";
                    gap = int.Parse(device.CashPrice.Replace(",", "")) - int.Parse(device.PrevCashPrice.Replace(",", ""));
                    device.ChangeCash = gap >= 0 ? $"▲{Math.Abs(gap)}" : $"▼{Math.Abs(gap)}";

                    HardwareDataGrid.Items.Add(new { Name = device.Name, Price = device.Price, ChangePrice = device.ChangePrice });
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
                if (device.Price == null) continue;
                device.PrevPrice = device.Price;
                if (device.CashPrice == null) continue;
                device.PrevCashPrice = device.CashPrice;
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
        public enum Types
        { 
            Product,
            Sum 
        }

        public Types Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string PrevPrice { get; set; } = string.Empty;
        public string ChangePrice { get; set; } = string.Empty;
        public string CashPrice { get; set; } = string.Empty;
        public string PrevCashPrice { get; set; } = string.Empty;
        public string ChangeCash { get; set; } = string.Empty;
    }
}
