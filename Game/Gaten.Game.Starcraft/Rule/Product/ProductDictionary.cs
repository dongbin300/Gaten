using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gaten.Game.Starcraft.Rule.Product.Terran.Building;
using Gaten.Game.Starcraft.Rule.Product.Terran.Unit;

namespace Gaten.Game.Starcraft.Rule.Product
{
    class ProductDictionary
    {
        public List<IProduct> Products { get; }

        public ProductDictionary()
        {
            Products = new List<IProduct>();
            Products.Add(new TerranCommandCenter());
            Products.Add(new TerranSupplyDepot());
            Products.Add(new TerranBarracks());
            Products.Add(new TerranSCV());
        }
    }
}
