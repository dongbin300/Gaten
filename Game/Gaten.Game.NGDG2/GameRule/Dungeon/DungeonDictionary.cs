using System.Text;

namespace Gaten.Game.NGDG2
{
    public class DungeonDictionary
    {
        public static Dictionary<string, Dungeon> Data = new Dictionary<string, Dungeon>();

        public DungeonDictionary()
        {
            ReadNFD();
        }

        public void ReadNFD()
        {
            using (FileStream stream = new FileStream(PathUtil.NFDPath + "Dungeon.nfd", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    List<string> dungeonString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach (string dungeon in dungeonString)
                    {
                        string[] data2 = dungeon.Split(':');
                        Data.Add(data2[0], new Dungeon(data2[0], data2[1]));
                    }
                }
            }
        }

        public static Dungeon MakeDungeon(string name)
        {
            return new Dungeon().Make(Data[name]);
        }
    }
}
