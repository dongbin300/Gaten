namespace Gaten.Game.Starcraft.Rule.Product.Terran.Building
{
    internal class TerranCommandCenter : IBuilding
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int MineralCost { get; set; }
        public int GasCost { get; set; }
        public int MineralIncome { get; set; }
        public int GasIncome { get; set; }
        public int PopulationBonus { get; set; }
        public int Armor { get; set; }
        public int ArmorBonus { get; set; }
        public int GroundPower { get; set; }
        public int GroundPowerBonus { get; set; }
        public int AirPower { get; set; }
        public int AirPowerBonus { get; set; }
        public IProduct.Direction PlaceDirection { get; set; }
        public IProduct.Direction AttackDirection { get; set; }

        public TerranCommandCenter()
        {
            Id = 2101;
            Name = "커맨드 센터";
            MaxHp = 1500;
            MineralCost = 400;
            GasCost = 0;
            PlaceDirection = IProduct.Direction.Ground;
            PopulationBonus = 10;
        }
    }
}
