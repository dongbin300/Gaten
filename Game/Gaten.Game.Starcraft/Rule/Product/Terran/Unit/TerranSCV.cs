namespace Gaten.Game.Starcraft.Rule.Product.Terran.Unit
{
    internal class TerranSCV : IUnit
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
        public int Population { get; set; }

        public TerranSCV()
        {
            Id = 2201;
            Name = "SCV";
            MaxHp = 60;
            Armor = 0;
            ArmorBonus = 0;
            GroundPower = 5;
            GroundPowerBonus = 0;
            PlaceDirection = IProduct.Direction.Ground;
            AttackDirection = IProduct.Direction.Ground;
            MineralCost = 50;
            GasCost = 0;
            MineralIncome = 8;
            Population = 1;
        }
    }
}
