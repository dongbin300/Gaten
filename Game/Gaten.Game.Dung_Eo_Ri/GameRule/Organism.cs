using System;
using System.Collections.Generic;
using System.Text;

namespace Gaten.Game.Dung_Eo_Ri.GameRule
{
	public abstract class Organism
	{
		public string Name { get; set; }
		public Image Picture { get; set; }
		public int Level { get; set; }
		public int BaseHitPoints { get; set; }
		public int BaseDamage { get; set; }
		public int CurrentHitPoints { get; set; }
		public List<Equip> Equips { get; set; }

		public Organism(string name, Image picture, int level, int baseHitPoints, int baseDamage, List<Equip> equips)
		{
			Name = name;
			Picture = picture;
			Level = level;
			BaseHitPoints = baseHitPoints;
			BaseDamage = baseDamage;
			Equips = equips;
		}

		public Organism(string name, Image picture, int level, List<Equip> equips)
		{
			Name = name;
			Picture = picture;
			Level = level;
			Equips = equips;
		}

		public Organism(string name, Image picture)
		{
			Name = name;
			Picture = picture;
			Equips = new List<Equip>();
		}

		public Dictionary<string, int> Attack(Organism target)
		{
			int myFinalDamage = BaseDamage;
			foreach (Equip equip in Equips)
			{
				myFinalDamage += equip.BonusDamage;
			}

			int finalTargetHitPoints = Math.Max(0, target.CurrentHitPoints - myFinalDamage);
			target.CurrentHitPoints = finalTargetHitPoints;

			int myHitPoints = CurrentHitPoints;

			Dictionary<string, int> result = new Dictionary<string, int>();
			result.Add("myFinalDamage", myFinalDamage);
			result.Add("finalTargetHitPoints", finalTargetHitPoints);
			result.Add("myHitPoints", myHitPoints);

			return result;
		}

		public void RestoreAllHitPoints()
		{
			CurrentHitPoints = GetMaxHitPoints();
		}

		public int GetMaxHitPoints()
		{
			int maxHitPoints = BaseHitPoints;
			foreach (Equip equip in Equips)
			{
				maxHitPoints += equip.BonusHitPoints;
			}

			return maxHitPoints;
		}
	}
}
