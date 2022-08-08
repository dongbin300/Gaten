using Gaten.Game.NGDG2.GameRule.Monster;
using Gaten.Net.Math;

namespace Gaten.Game.NGDG2.GameRule.Dungeon
{
    public class NgdgDungeonWave
    {
        /// <summary>
        /// 웨이브 이름(ID)
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// [랜덤]던전 몬스터
        /// </summary>
        public List<Monster.NgdgMonster> Monsters = new();

        public NgdgDungeonWave()
        {

        }

        public NgdgDungeonWave(List<Monster.NgdgMonster> monsterList, int monsterCount)
        {
            SmartRandom r = new();
            for (int i = 0; i < monsterCount; i++)
            {
                Monsters.Add(NgdgMonsterDictionary.MakeMonster(monsterList[r.Next(monsterList.Count)].Name));
            }
        }
    }
}
