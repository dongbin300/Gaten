using Gaten.Game.Starcraft.Rule.Product.Terran.Building;
using Gaten.Game.Starcraft.Rule.Product.Terran.Unit;

namespace Gaten.Game.Starcraft.Rule.Product
{
    internal class ProductDictionary
    {
        public List<IProduct> Products { get; }

        public ProductDictionary()
        {
            Products = new List<IProduct>
            {
                new TerranCommandCenter(),
                new TerranSupplyDepot(),
                new TerranBarracks(),
                new TerranSCV()
            };
        }
    }
}
