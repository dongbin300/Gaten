using System;
using System.Collections.Generic;
using System.Text;

namespace Gaten.Game.Dung_Eo_Ri.GameRule
{
	public class Dungeon
	{
		public string Name { get; set; }
		public int MinMobLevel { get; set; }
		public Mob BossMob { get; set; }
		public List<DungeonLevel> DungeonLevels { get; set; }
		public List<Equip> RewardEquips { get; set; }
		public Mob CurrentMob { get; set; }

		private Random r = new Random();

		public Dungeon(string name, int minMobLevel, Mob bossMob)
		{
			Name = name;
			BossMob = bossMob;
			MinMobLevel = minMobLevel;

			Initialize();
		}

		public void Initialize()
        {
			DungeonLevels = new List<DungeonLevel>();
			for(int i = 0; i < 5; i++)
            {
				DungeonLevels.Add(new DungeonLevel(3, 3, r.Next(3), r.Next(3)));
			}
		}

        public int GetNewMobLevel(int dungeonLevel)
        {
			int minLevel = (dungeonLevel - 1) * 2 + MinMobLevel;
			int maxLevel = dungeonLevel * 2 + MinMobLevel;

			return r.Next(minLevel, maxLevel + 1);
        }
    }
}
