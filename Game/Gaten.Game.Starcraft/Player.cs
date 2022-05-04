using Gaten.Game.Starcraft.Rule.Product;
using Gaten.Game.Starcraft.Rule.Product.Terran.Building;
using Gaten.Game.Starcraft.Rule.Product.Terran.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Game.Starcraft
{
    class Player
    {
        public enum RaceType
        {
            Zerg,
            Terran,
            Protoss
        };

        public RaceType Race { get; set; }
        public int CurrentMineral { get; set; }
        public int CurrentGas { get; set; }
        public int CurrentPopulation { get; set; }
        public int MaxPopulation { get; set; }
        public List<IProduct> Products { get; set; }

        public Player()
        {
            Race = RaceType.Terran;
            CurrentMineral = 50;
            CurrentGas = 0;

            Products = new List<IProduct>();
            Products.Add(new TerranCommandCenter());
            Products.Add(new TerranSCV());
            Products.Add(new TerranSCV());
            Products.Add(new TerranSCV());
            Products.Add(new TerranSCV());

            CalculateStatus();
        }

        /// <summary>
        /// 현재 상황을 계산한다.
        /// </summary>
        public void CalculateStatus()
        {
            CurrentPopulation = 0;
            foreach(IProduct product in Products)
            {
                if(product is IUnit unit)
                {
                    CurrentPopulation += unit.Population;
                }
            }

            MaxPopulation = 0;
            foreach (IProduct product in Products)
            {
                MaxPopulation += product.PopulationBonus;
            }
        }

        /// <summary>
        /// 자원을 캔다.
        /// </summary>
        public void GetResources()
        {
            CurrentMineral += Products.Sum(p => p.MineralIncome);
            CurrentGas += Products.Sum(p => p.GasIncome);
        }

        public int GetProductCount(int id)
        {
            return Products.Count(p => p.Id.Equals(id));
        }

        public void MakeBuilding(IProduct product)
        {
            if (CurrentMineral < product.MineralCost || CurrentGas < product.GasCost)
                return;

            CurrentMineral -= product.MineralCost;
            CurrentGas -= product.GasCost;

            Products.Add(product);
        }
    }
}
