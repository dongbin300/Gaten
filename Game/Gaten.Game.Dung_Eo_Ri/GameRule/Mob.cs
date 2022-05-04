using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Game.Dung_Eo_Ri.GameRule
{
    public class Mob : Organism
    {
        public int RewardExp { get; set; }

        public Mob(string name, Image picture, int level, int baseHitPoints, int baseDamage, List<Equip> equips) : base(name, picture, level, baseHitPoints, baseDamage, equips)
        {
        }

        public Mob(string name, Image picture, int level, List<Equip> equips) : base(name, picture, level, equips)
        {
            BaseHitPoints = level * 5 + 5;
            CurrentHitPoints = GetMaxHitPoints();
            BaseDamage = level + 4;
            RewardExp = level * level;
        }
    }
}
