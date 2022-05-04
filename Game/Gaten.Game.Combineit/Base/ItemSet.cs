using System;
using System.Collections.Generic;
using System.Text;

namespace Gaten.Game.Combineit.Base
{
    public class ItemSet
    {
        public Item Item { get; set; }
        public int Count { get; set; }

        public ItemSet(Item item, int count)
        {
            Item = item;
            Count = count;
        }
    }
}
