
using Gaten.Game.NGDG2.Util.Environment;

using System.Text;

namespace Gaten.Game.NGDG2.GameRule.Dungeon
{
    public class NgdgDungeonDictionary
    {
        public static Dictionary<string, NgdgDungeon> Data = new();

        public NgdgDungeonDictionary()
        {
            ReadNFD();
        }

        public void ReadNFD()
        {
            using FileStream stream = new(PathUtil.NFDPath + "Dungeon.nfd", FileMode.Open);
            using StreamReader reader = new(stream, Encoding.UTF8);
            string data = reader.ReadToEnd();
            List<string> dungeonString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string dungeon in dungeonString)
            {
                string[] data2 = dungeon.Split(':');
                Data.Add(data2[0], new NgdgDungeon(data2[0], data2[1]));
            }
        }

        public static NgdgDungeon MakeDungeon(string name)
        {
            return new NgdgDungeon().Make(Data[name]);
        }
    }
}
