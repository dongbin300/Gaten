using System.Collections.Generic;
using System.Linq;

namespace Gaten.Game.Combineit.Base
{
    public class TickMaster
    {
        public TickMaster()
        {

        }

        public static void Tick(int tickMs)
        {
            Module(200, 100);
            Module(220, 101);

            for (int i = 0; i < ItemDictionary.Items.Count; i++)
            {
                Item? item = ItemDictionary.Items[i];
                if (item.Status == Item.ItemStatus.Run)
                {
                    item.Tick += tickMs;

                    if (item.Tick >= item.CombineTime)
                    {
                        Character.GetItem(item.Id, item.Bundle);
                        item.Tick = 0;
                        item.Status = Item.ItemStatus.Idle;
                    }
                }
            }
        }

        public static void Module(int moduleId, int productId)
        {
            IEnumerable<PossessionItem>? module = Character.PossessionItems.Where(i => i.Item.Id.Equals(moduleId));
            if (module.First().Count > 0)
            {
                Item? item = ItemDictionary.GetItem(productId);
                if (item.Status == Item.ItemStatus.Idle)
                {
                    item.Status = Item.ItemStatus.Run;
                }
            }
        }
    }
}
