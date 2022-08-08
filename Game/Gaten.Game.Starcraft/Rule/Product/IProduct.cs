namespace Gaten.Game.Starcraft.Rule.Product
{
    internal interface IProduct
    {
        public enum Direction
        {
            Ground,
            Air
        };

        /// <summary>
        /// ID<br/>
        /// ------<br/>
        /// 1 - 저그<br/>
        /// 2 - 테란<br/>
        /// 3 - 프로토스<br/>
        /// ------<br/>
        /// 1 - 건물<br/>
        /// 2 - 유닛<br/>
        /// 3 - 업글<br/>
        /// ------<br/>
        /// 01~99 - 종류<br/>
        /// </summary>
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
        public Direction PlaceDirection { get; set; }
        public Direction AttackDirection { get; set; }
    }
}
