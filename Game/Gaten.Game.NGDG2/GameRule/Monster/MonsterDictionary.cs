using System.Text;

namespace Gaten.Game.NGDG2
{
    public class MonsterDictionary
    {
        public static Dictionary<string, Monster> Data = new Dictionary<string, Monster>();

        public MonsterDictionary()
        {
            ReadNFD();
        }

        public void ReadNFD()
        {
            using (FileStream stream = new FileStream(PathUtil.NFDPath + "Monster.nfd", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    List<string> monsterString = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach (string monster in monsterString)
                    {
                        string[] data2 = monster.Split(':');
                        Data.Add(data2[0], new Monster(data2[0], long.Parse(data2[1]), long.Parse(data2[2]), long.Parse(data2[3]), long.Parse(data2[4]), long.Parse(data2[5]), long.Parse(data2[6]), long.Parse(data2[7]), long.Parse(data2[8]), data2[9]));
                    }
                }
            }
        }

        public static Monster MakeMonster(string name)
        {
            return new Monster().Make(Data[name]);
        }
    }
}
