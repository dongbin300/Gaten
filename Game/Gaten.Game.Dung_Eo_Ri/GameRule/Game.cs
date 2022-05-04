﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gaten.Game.Dung_Eo_Ri.GameRule
{
	public class Game
	{
		public User Player { get; set; }
		public Dictionary<int, List<Mob>> Mobs { get; set; }
		public Dictionary<string, Mob> BossMobs { get; set; }
		public Dictionary<string, Dungeon> Dungeons { get; set; }

        public Game()
        {
			Player = new User("가튼맨", ImageUtil.GetResourceImage("Player/가튼맨.png"));

			Mobs = new Dictionary<int, List<Mob>>();
			Mobs.Add(1, new List<Mob>());
			Mobs[1].Add(new Mob("몀킷", ImageUtil.GetResourceImage("Mobs/몀킷.png"), 1, new List<Equip>()));
			Mobs[1].Add(new Mob("메리", ImageUtil.GetResourceImage("Mobs/메리.png"), 1, new List<Equip>()));
			Mobs[1].Add(new Mob("제리", ImageUtil.GetResourceImage("Mobs/제리.png"), 1, new List<Equip>()));
			for (int i = 2; i <= 200; i++)
			{
				Mobs.Add(i, new List<Mob>());
				foreach (Mob mob in Mobs[1])
				{
					Mobs[i].Add(new Mob(mob.Name, mob.Picture, i, mob.Equips));
				}
            }

			BossMobs = new Dictionary<string, Mob>();
			BossMobs.Add("비누", new Mob("비누", ImageUtil.GetResourceImage("Mobs/BossMobs/비누.png"), 10, new List<Equip>()));

			Dungeons = new Dictionary<string, Dungeon>();
			Dungeons.Add("튜토리얼 던전", new Dungeon("튜토리얼 던전", 1, BossMobs["비누"]));

        }

		public Game(User player, Dictionary<int, List<Mob>> mobs, Dictionary<string, Mob> bossMobs, Dictionary<string, Dungeon> dungeons)
		{
			Player = player;
			Mobs = mobs;
			BossMobs = bossMobs;
			Dungeons = dungeons;
		}
	}
}
