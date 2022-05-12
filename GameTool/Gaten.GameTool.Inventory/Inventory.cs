using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.GameTool.Inventory
{
    public class Inventory
    {
        public int Width { get; }
        public int Height { get; }
        public List<Slot> Slots { get; } = new List<Slot>();

        /// <summary>
        /// 인벤토리 생성자
        /// 인벤토리의 가로 슬롯 개수, 세로 슬롯 개수
        /// 슬롯 생성과 동시에 NullObject추가
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Inventory(int width, int height)
        {
            Width = width;
            Height = height;
            for (int i = 0; i < Width * Height; i++)
                Slots.Add(new Slot(i, new NullObject()));
        }

        /// <summary>
        /// 오브젝트 획득
        /// </summary>
        /// <param name="obj"></param>
        public bool GetObject(ItemObject obj)
        {
            List<Slot> slots = Slots.FindAll(s => s.Object.Equals(obj));

            // 오브젝트의 개수가 최대 소지 개수면 실패
            if (GetObjectCount(obj) >= obj.Max) return false;

            // 이미 가지고 있는 오브젝트면
            if (slots.Count > 0)
            {
                // 기존에 오브젝트가 있는 슬롯에 넣기 실패하면
                if (!TryGetObject(slots, obj))
                {
                    // 비어있는 슬롯이 있으면
                    if (HasEmptySlot())
                    {
                        // 새 슬롯에 추가
                        Slots.Find(s => s.Object == new NullObject()).GetObject(obj);
                    }
                    // 비어있는 슬롯이 없으면 실패
                    else
                        return false;
                }
            }

            // 없는 오브젝트면
            else
            {
                // 새 슬롯에 추가
                Slots.Find(s => s.Object == new NullObject()).GetObject(obj);
            }

            return true;
        }

        /// <summary>
        /// 슬롯에 오브젝트 획득 처리 시도
        /// </summary>
        /// <param name="slots"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool TryGetObject(List<Slot> slots, ItemObject obj)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].GetObject(obj)) return true;
            }
            return false;
        }

        /// <summary>
        /// 빈 슬롯이 있는지 확인
        /// </summary>
        /// <returns></returns>
        public bool HasEmptySlot()
        {
            return Slots.Find(s => s.Object == new NullObject()) != null;
        }

        /// <summary>
        /// 인벤토리의 오브젝트 총 개수
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetObjectCount(ItemObject obj)
        {
            return Slots.FindAll(s => s.Object == obj).Sum(s => s.Count);
        }

        /// <summary>
        /// 오브젝트 폐기
        /// </summary>
        /// <param name="slot"></param>
        public void ThrowObject(Slot slot)
        {
            slot.ThrowAllObjects();
        }
    }
}
