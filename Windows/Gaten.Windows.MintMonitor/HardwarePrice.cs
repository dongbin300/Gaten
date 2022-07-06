using Gaten.Net.Data.IO;
using Gaten.Net.Network;

using System.Text;

namespace Gaten.Windows.MintMonitor
{
    internal class Device
    {
        public enum Types { Product, Sum }
        public Types type;
        public string name;
        public string url;
        public string price, forePrice, changePrice;
        public string cashPrice, foreCashPrice, changeCash;
    }

    internal class HardwarePrice
    {
        public static List<Device> Devices = new List<Device>();
        public static bool first = true;

        public static void Init()
        {
            LoadTextFile();
        }

        public static void SaveTextFile()
        {
            DateTime now = DateTime.Now;
            StringBuilder builder = new StringBuilder();
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

        public static string GetSumPrice(DataGridView dataGridView)
        {
            int cpu = int.Parse(dataGridView.Rows[9].Cells[1].Value.ToString().Split('(')[0].Replace(",", ""));
            int mainBoard = int.Parse(dataGridView.Rows[14].Cells[1].Value.ToString().Split('(')[0].Replace(",", ""));
            int ram = int.Parse(dataGridView.Rows[2].Cells[1].Value.ToString().Split('(')[0].Replace(",", ""));
            int ssd = int.Parse(dataGridView.Rows[15].Cells[1].Value.ToString().Split('(')[0].Replace(",", ""));
            int power = int.Parse(dataGridView.Rows[16].Cells[1].Value.ToString().Split('(')[0].Replace(",", ""));

            int sum = cpu + mainBoard + ram + ssd + power;

            return sum.ToString();
        }
    }
}
