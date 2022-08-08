using Gaten.GameTool.NGD.NFDManager.Frame;

using System.Text;

namespace Gaten.GameTool.NGD.NFDManager
{
    public class NFDFileWriter
    {
        private static readonly string nfdBasePath = @".\..\..\..\NGDG2\bin\Debug\Resource\NFD\";

        public static void WriteDungeon(List<Dungeon> dungeons)
        {
            using FileStream stream = new(nfdBasePath + "Dungeon.nfd", FileMode.OpenOrCreate);
            using StreamWriter writer = new(stream, Encoding.UTF8);
            foreach (Dungeon dungeon in dungeons)
            {
                writer.WriteLine($"{dungeon.Name}:{dungeon.FormattedDungeonInfo}");
            }
        }

        public static void WriteMonster(List<Monster> monsters)
        {
            using FileStream stream = new(nfdBasePath + "Monster.nfd", FileMode.OpenOrCreate);
            using StreamWriter writer = new(stream, Encoding.UTF8);
            foreach (Monster monster in monsters)
            {
                writer.WriteLine($"{monster.Name}:{monster.Power}:{monster.Stamina}:{monster.Intelli}:{monster.Willpower}:{monster.Concentration}:{monster.Agility}:{monster.Exp}:{monster.Gold}:{monster.DropItemFormattedInfo}");
            }
        }

        public static void WriteMaterial(List<Item> materials)
        {
            using FileStream stream = new(nfdBasePath + "Material.nfd", FileMode.OpenOrCreate);
            using StreamWriter writer = new(stream, Encoding.UTF8);
            foreach (Item material in materials)
            {
                writer.WriteLine($"{material.Name}:{material.Rank}:{material.Description}:{material.Value}:{material.Level}");
            }
        }

        public static void WriteEquipment(List<Item> equipments)
        {
            using FileStream stream = new(nfdBasePath + "Equipment.nfd", FileMode.OpenOrCreate);
            using StreamWriter writer = new(stream, Encoding.UTF8);
            foreach (Item equipment in equipments)
            {
                writer.WriteLine($"{equipment.Name}:{equipment.Level}:{equipment.EqType}:{equipment.Rank}:{equipment.formattedEquipmentEffect}");
            }
        }

        public static void WritePotion(List<Item> potions)
        {
            using FileStream stream = new(nfdBasePath + "Potion.nfd", FileMode.OpenOrCreate);
            using StreamWriter writer = new(stream, Encoding.UTF8);
            foreach (Item potion in potions)
            {
                //writer.WriteLine($"{potion.Name}:{potion.Level}:{potion.EqType}:{potion.Rank}:{potion.formattedEquipmentEffect}");
            }
        }
    }
}
