using Gaten.Game.NGDG2.Util.Environment;

using System.Text;

namespace Gaten.Game.NGDG2.GameRule.Item
{
    public class NgdgItemDictionary
    {
        public static Dictionary<string, NgdgItem> Data = new();

        public NgdgItemDictionary()
        {
            ReadNFD();
        }

        public void ReadNFD()
        {
            using (FileStream stream = new(PathUtil.NFDPath + "Material.nfd", FileMode.Open))
            {
                using StreamReader reader = new(stream, Encoding.UTF8);
                string data = reader.ReadToEnd();
                List<string> materialString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (string material in materialString)
                {
                    string[] data2 = material.Split(':');
                    Data.Add(data2[0], new NgdgItem(data2[0], data2[1], data2[2], int.Parse(data2[3]), int.Parse(data2[4])));
                }
            }

            using (FileStream stream = new(PathUtil.NFDPath + "Equipment.nfd", FileMode.Open))
            {
                using StreamReader reader = new(stream, Encoding.UTF8);
                string data = reader.ReadToEnd();
                List<string> equipmentString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (string equipment in equipmentString)
                {
                    string[] data2 = equipment.Split(':');
                    Data.Add(data2[0], new NgdgItem(data2[0], int.Parse(data2[1]), data2[2], data2[3], data2[4]));
                }
            }

            using (FileStream stream = new(PathUtil.NFDPath + "Potion.nfd", FileMode.Open))
            {
                using StreamReader reader = new(stream, Encoding.UTF8);
                string data = reader.ReadToEnd();
                List<string> potionString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (string potion in potionString)
                {
                    string[] data2 = potion.Split(':');
                    Data.Add(data2[0], new NgdgItem(data2[0], data2[1], data2[2], int.Parse(data2[3]), int.Parse(data2[4]), data2[5]));
                }
            }
        }

        public static NgdgItem MakeItem(string name)
        {
            NgdgItem? item = Data[name];

            return (object)item.Type switch
            {
                NgdgItem.ItemType.Material => new NgdgItem().MakeMaterial(item),
                NgdgItem.ItemType.Equipment => new NgdgItem().MakeEquipment(item),
                NgdgItem.ItemType.Potion => new NgdgItem().MakePotion(item),
                _ => item,
            };
        }
    }
}
