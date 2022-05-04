using Gaten.GameTool.NGD.NFDManager.Frame;

using System.Text;

namespace Gaten.GameTool.NGD.NFDManager
{
    public class NFDFileReader
    {
        static string nfdBasePath = @".\..\..\..\NGDG2\bin\Debug\Resource\NFD\";

        public static List<Dungeon> ReadDungeon()
        {
            using(FileStream stream = new FileStream(nfdBasePath + "Dungeon.nfd", FileMode.Open))
            {
                using(StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    List<string> dungeonsString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    List<Dungeon> dungeons = new List<Dungeon>();
                    foreach(string dungeon in dungeonsString)
                    {
                        string[] data2 = dungeon.Split(':');
                        dungeons.Add(new Dungeon()
                        {
                            Name = data2[0],
                            FormattedDungeonInfo = data2[1]
                        });
                    }

                    return dungeons;
                }
            }
        }

        public static List<Monster> ReadMonster()
        {
            using (FileStream stream = new FileStream(nfdBasePath + "Monster.nfd", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    List<string> monsterString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    List<Monster> monsters = new List<Monster>();
                    foreach (string monster in monsterString)
                    {
                        string[] data2 = monster.Split(':');
                        monsters.Add(new Monster()
                        {
                            Name = data2[0],
                            Power = data2[1],
                            Stamina = data2[2],
                            Intelli = data2[3],
                            Willpower = data2[4],
                            Concentration = data2[5],
                            Agility = data2[6],
                            Exp = data2[7],
                            Gold = data2[8],
                            DropItemFormattedInfo = data2[9]
                        });
                    }

                    return monsters;
                }
            }
        }

        public static List<Item> ReadMaterial()
        {
            using (FileStream stream = new FileStream(nfdBasePath + "Material.nfd", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    List<string> materialString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    List<Item> materials = new List<Item>();
                    foreach (string material in materialString)
                    {
                        string[] data2 = material.Split(':');
                        materials.Add(new Item()
                        {
                            Name = data2[0],
                            Rank = data2[1],
                            Description = data2[2],
                            Value = data2[3],
                            Level = data2[4]
                        });
                    }

                    return materials;
                }
            }
        }

        public static List<Item> ReadEquipment()
        {
            using (FileStream stream = new FileStream(nfdBasePath + "Equipment.nfd", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    List<string> equipmentString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    List<Item> equipments = new List<Item>();
                    foreach (string equipment in equipmentString)
                    {
                        string[] data2 = equipment.Split(':');
                        equipments.Add(new Item()
                        {
                            Name = data2[0],
                            Level = data2[1],
                            EqType = data2[2],
                            Rank = data2[3],
                            formattedEquipmentEffect = data2[4]
                        });
                    }

                    return equipments;
                }
            }
        }

        public static List<Item> ReadPotion()
        {
            using (FileStream stream = new FileStream(nfdBasePath + "Potion.nfd", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    List<string> potionString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    List<Item> potions = new List<Item>();
                    foreach (string potion in potionString)
                    {
                        string[] data2 = potion.Split(':');
                        potions.Add(new Item()
                        {
                            /*Name = data2[0],
                            Level = data2[1],
                            EqType = data2[2],
                            Rank = data2[3],
                            formattedEquipmentEffect = data2[4]*/
                        });
                    }

                    return potions;
                }
            }
        }
    }
}
