﻿namespace Gaten.Game.NGDG2
{
    /// <summary>
    /// 인벤토리 슬롯
    /// 
    /// 슬롯 하나에는 한 종류의 아이템만 넣을 수 있다.
    /// </summary>
    public class Slot
    {
        /// <summary>
        /// 아이템
        /// </summary>
        public Item Item;

        /// <summary>
        /// 아이템 개수
        /// </summary>
        public int ItemCount;

        /// <summary>
        /// 아이템이 비어있는지 확인한다.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Item == null ? true : false;

        public Slot()
        {
        }

        /// <summary>
        /// 슬롯에 아이템을 추가한다.
        /// </summary>
        /// <param name="item">아이템</param>
        /// <param name="count">아이템 개수</param>
        public void Fill(Item item, int count)
        {
            Item = item;
            ItemCount = count;
        }

        /// <summary>
        /// 슬롯에 있는 아이템을 비운다.
        /// </summary>
        public void Empty()
        {
            Item = null;
            ItemCount = 0;
        }
    }
}
