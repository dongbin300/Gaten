using System;
using System.Collections.Generic;
using System.Text;

namespace Gaten.Game.Dung_Eo_Ri.GameRule
{
	public class Dungeon
	{
		public string Name { get; set; }
		public int MinMobLevel { get; set; }
		public int BaseWidth { get; set; }
		public int BaseHeight { get; set; }
		public int Depth { get; set; }
		public Mob BossMob { get; set; }
		public List<DungeonLevel> DungeonLevels { get; set; }
		public List<Equip> RewardEquips { get; set; }
		public Mob CurrentMob { get; set; }
		public int AccumulatedRewardExp { get; set; }

		private Random r = new Random();

		public Dungeon(string name, int minMobLevel, int baseWidth, int baseHeight, int depth, Mob bossMob)
		{
			Name = name;
			MinMobLevel = minMobLevel;
			BaseWidth = baseWidth;
			BaseHeight = baseHeight;
			Depth = depth;
			BossMob = bossMob;

			Initialize();
		}

		public void Initialize()
        {
			DungeonLevels = new List<DungeonLevel>();
			for(int i = 0; i < Depth - 1; i++)
            {
				DungeonLevels.Add(new DungeonLevel(BaseWidth, BaseHeight, r.Next(BaseWidth), r.Next(BaseHeight)));
			}
			DungeonLevels.Add(new DungeonLevel(BaseWidth, BaseHeight, -1, -1));
		}

        public int GetNewMobLevel(int dungeonLevel)
        {
			int minLevel = MinMobLevel + (dungeonLevel - 1);
			int maxLevel = minLevel + 2;

			return r.Next(minLevel, maxLevel + 1);
        }
    }
}
