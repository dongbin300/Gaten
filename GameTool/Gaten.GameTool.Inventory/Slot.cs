namespace Gaten.GameTool.Inventory
{
    public class Slot
    {
        public int Index { get; }
        public ItemObject Object { get; set; }
        public int Count { get; set; }

        public Slot(int index, ItemObject obj)
        {
            Index = index;
            Object = obj;
        }

        /// <summary>
        /// 오브젝트 획득
        /// </summary>
        /// <param name="obj"></param>
        public bool GetObject(ItemObject obj)
        {
            /*
             * 슬롯에 있는 오브젝트와 같은 오브젝트를 얻었을 경우
             * 오브젝트 슬롯최대개수보다 작으면
             * 카운트 1 증가
             * 
             * 다른 오브젝트를 얻었을 경우
             * 슬롯에 오브젝트가 있으면
             * 아무 것도 하지 않음
             * 
             * 슬롯에 오브젝트가 없으면
             * 오브젝트를 추가
             */
            if (obj == Object)
            {
                if (Count < obj.MaxOneSlot)
                    Count++;
                else
                    return false;
            }
            else
            {
                if (Object != new NullObject()) return false;
                Object = obj;
                Count = 1;
            }
            
            return true;
        }

        /// <summary>
        /// 오브젝트 폐기
        /// </summary>
        public bool ThrowObject()
        {
            /*
             * 슬롯에 있는 오브젝트를 1개 버린다
             * 
             * 오브젝트가 없으면
             * 아무 것도 하지 않음
             * 
             * 1개 버리고 난 뒤 0개면
             * 오브젝트를 없앰
             */
            if (Object == new NullObject()) return false;

            if (--Count == 0)
                Object = new NullObject();

            return true;
        }

        /// <summary>
        /// 오브젝트 모두 폐기
        /// </summary>
        public void ThrowAllObjects()
        {
            /*
             * 슬롯에 있는 오브젝트를 모두 버린다
             */

            Count = 0;
            Object = new NullObject();
        }
    }
}
