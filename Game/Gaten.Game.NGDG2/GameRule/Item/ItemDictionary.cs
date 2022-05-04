using System.Text;

namespace Gaten.Game.NGDG2
{
    public class ItemDictionary
    {
        public static Dictionary<string, Item> Data = new Dictionary<string, Item>();

        public ItemDictionary()
        {
            ReadNFD();
        }

        public void ReadNFD()
        {
            using (FileStream stream = new FileStream(PathUtil.NFDPath + "Material.nfd", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    List<string> materialString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach (string material in materialString)
                    {
                        string[] data2 = material.Split(':');
                        Data.Add(data2[0], new Item(data2[0], data2[1], data2[2], int.Parse(data2[3]), int.Parse(data2[4])));
                    }
                }
            }

            using (FileStream stream = new FileStream(PathUtil.NFDPath + "Equipment.nfd", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    List<string> equipmentString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach (string equipment in equipmentString)
                    {
                        string[] data2 = equipment.Split(':');
                        Data.Add(data2[0], new Item(data2[0], int.Parse(data2[1]), data2[2], data2[3], data2[4]));
                    }
                }
            }

            using (FileStream stream = new FileStream(PathUtil.NFDPath + "Potion.nfd", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    List<string> potionString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach (string potion in potionString)
                    {
                        string[] data2 = potion.Split(':');
                        Data.Add(data2[0], new Item(data2[0], data2[1], data2[2], int.Parse(data2[3]), int.Parse(data2[4]), data2[5]));
                    }
                }
            }
        }

        public static Item MakeItem(string name)
        {
            var item = Data[name];

            switch (item.Type)
            {
                case Item.ItemType.Material:
                    return new Item().MakeMaterial(item);

                case Item.ItemType.Equipment:
                    return new Item().MakeEquipment(item);

                case Item.ItemType.Potion:
                    return new Item().MakePotion(item);
            }

            return item;
        }
    }
}
