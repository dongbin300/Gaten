namespace Gaten.Game.Dung_Eo_Ri.GameRule
{
    public class Equip
    {
        public string Name { get; set; }
        public int BonusHitPoints { get; set; }
        public int BonusDamage { get; set; }

        public Equip(string name, int bonusHitPoints, int bonusDamage)
        {
            Name = name;
            BonusHitPoints = bonusHitPoints;
            BonusDamage = bonusDamage;
        }
    }
}
