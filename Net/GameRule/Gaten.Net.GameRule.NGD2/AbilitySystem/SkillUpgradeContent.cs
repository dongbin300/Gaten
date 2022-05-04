namespace Gaten.Net.GameRule.NGD2.AbilitySystem
{
    public class SkillUpgradeContent
    {
        public bool On { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int CardValue { get; set; }
        public int CardPrice { get; set; }
        public int SpiritPrice { get; set; }
        public int PlusValue { get; set; }
        public int PlusValue2 { get; set; }
        public int PlusMpValue { get; set; }
        public int MaxLevel { get; set; }

        public int TotalValue => Level * PlusValue;
        public int TotalValue2 => Level * PlusValue2;
        public int TotalMpValue => Level * PlusMpValue;
        public int TotalCardPrice => Level * CardPrice;
        public int TotalSpiritPrice => Level * SpiritPrice;

        public SkillUpgradeContent(string name, int cardPrice, int spiritPrice, int plusValue, int plusMpValue, int maxLevel = 1000000)
        {
            Name = name;
            Level = 0;
            CardValue = 0;
            CardPrice = cardPrice;
            SpiritPrice = spiritPrice;
            PlusValue = plusValue;
            PlusMpValue = plusMpValue;
            MaxLevel = maxLevel;
        }

        public SkillUpgradeContent(string name, int cardPrice, int spiritPrice, int plusValue, int plusValue2, int plusMpValue, int maxLevel = 1000000)
        {
            Name = name;
            Level = 0;
            CardValue = 0;
            CardPrice = cardPrice;
            SpiritPrice = spiritPrice;
            PlusValue = plusValue;
            PlusValue2 = plusValue2;
            PlusMpValue = plusMpValue;
            MaxLevel = maxLevel;
        }
    }
}
