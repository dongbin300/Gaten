namespace Gaten.Game.NGDG2
{
    public class DungeonWave
    {
        /// <summary>
        /// 웨이브 이름(ID)
        /// </summary>
        public string Name;

        /// <summary>
        /// [랜덤]던전 몬스터
        /// </summary>
        public List<Monster> Monsters;

        public DungeonWave()
        {

        }

        public DungeonWave(List<Monster> monsterList, int monsterCount)
        {
            var r = new SmartRandom();

            Monsters = new List<Monster>();
            for (int i = 0; i < monsterCount; i++)
            {
                Monsters.Add(MonsterDictionary.MakeMonster(monsterList[r.Next(monsterList.Count)].Name));
            }
        }
    }
}
