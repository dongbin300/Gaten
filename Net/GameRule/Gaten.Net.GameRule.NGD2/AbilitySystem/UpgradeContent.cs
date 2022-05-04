namespace Gaten.Net.GameRule.NGD2.AbilitySystem
{
    public class UpgradeContent
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MainPrice { get; set; }
        public int MainValue { get; set; }
        public int Price { get; set; }
        public int PlusValue { get; set; }
        public int MaxLevel { get; set; }
        public int TotalValue => Level * PlusValue;
        public int TotalPrice => Level * Price;

        public UpgradeContent(string name, int price, int plusValue, int maxLevel = 1000000)
        {
            Name = name;
            Level = 0;
            Price = price;
            PlusValue = plusValue;
            MaxLevel = maxLevel;
        }

        public UpgradeContent(string name, int mainPrice, int price, int plusValue, int maxLevel = 1000000)
        {
            Name = name;
            Level = 0;
            Price = price;
            MainPrice = mainPrice;
            MainValue = 0;
            PlusValue = plusValue;
            MaxLevel = maxLevel;
        }
    }
}
