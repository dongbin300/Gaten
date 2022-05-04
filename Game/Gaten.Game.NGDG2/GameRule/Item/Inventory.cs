namespace Gaten.Game.NGDG2
{
    public class Inventory
    {
        public List<Slot> Slots;

        public Inventory(int slotMaxCount)
        {
            Slots = new List<Slot>();

            for (int i = 0; i < slotMaxCount; i++)
            {
                Slots.Add(new Slot());
            }
        }

        /// <summary>
        /// 적절한 슬롯에 아이템을 추가한다.
        /// </summary>
        /// <param name="item">아이템</param>
        /// <param name="count">아이템 개수</param>
        public void Add(Item item, int count = 1)
        {
            Slot slot = GetSlot(item);

            // 해당 아이템이 있으면 개수만 더함
            if (slot != null)
            {
                slot.ItemCount += count;
            }
            // 없으면 아이템을 추가함
            else
            {
                Slots.Find(s => s.IsEmpty()).Fill(item, count);
            }
        }

        /// <summary>
        /// 인벤토리에 해당 아이템을 제거한다.
        /// </summary>
        /// <param name="item">아이템</param>
        /// <param name="count">아이템 개수</param>
        public void Remove(Item item, int count = 1)
        {
            Slot slot = GetSlot(item);

            // 해당 아이템이 있으면 개수만큼 제거함
            if (slot != null)
            {
                slot.ItemCount -= count;

                // 개수만큼 제거했더니 하나도 없으면 아예 슬롯을 비움
                if (slot.ItemCount <= 0)
                {
                    slot.Empty();
                }
            }
        }

        /// <summary>
        /// 인벤토리에 해당 아이템을 모두 제거한다.
        /// </summary>
        /// <param name="item">아이템</param>
        public void RemoveAll(Item item)
        {
            Slot slot = GetSlot(item);

            // 해당 아이템이 있으면 제거함
            if (slot != null)
            {
                slot.Empty();
            }
        }

        /// <summary>
        /// 인벤토리에 있는 모든 아이템을 제거한다.
        /// </summary>
        public void RemoveAll()
        {
            // 슬롯을 제거하는게 아닌 아이템을 제거하는 것이다.
            foreach (Slot slot in Slots)
            {
                slot.Empty();
            }
        }

        /// <summary>
        /// 인벤토리에 해당 아이템이 있는지 확인한다.
        /// </summary>
        /// <param name="item">아이템</param>
        /// <returns>있으면 true, 없으면 false</returns>
        public bool HasItem(Item item)
        {
            return Slots.FindAll(s => !s.IsEmpty()).Find(s => s.Item.Name.Equals(item.Name)) != null ? true : false;
        }

        /// <summary>
        /// 인벤토리에 해당 아이템이 있는 슬롯을 반환한다.
        /// </summary>
        /// <param name="item">아이템</param>
        /// <returns>해당 아이템 슬롯</returns>
        public Slot GetSlot(Item item)
        {
            return Slots.FindAll(s => !s.IsEmpty()).Find(s => s.Item.Name.Equals(item.Name));
        }
    }
}
