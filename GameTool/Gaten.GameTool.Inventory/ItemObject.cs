namespace Gaten.GameTool.Inventory
{
#pragma warning disable CS0660 // 형식은 == 연산자 또는 != 연산자를 정의하지만 Object.Equals(object o)를 재정의하지 않습니다.
#pragma warning disable CS0661 // 형식은 == 연산자 또는 != 연산자를 정의하지만 Object.GetHashCode()를 재정의하지 않습니다.
    public class ItemObject
#pragma warning restore CS0661 // 형식은 == 연산자 또는 != 연산자를 정의하지만 Object.GetHashCode()를 재정의하지 않습니다.
#pragma warning restore CS0660 // 형식은 == 연산자 또는 != 연산자를 정의하지만 Object.Equals(object o)를 재정의하지 않습니다.
    {
        public int Index { get; set; } // 정렬용
        public int Id { get; set;  } // 구분용
        public string Name { get; private set; } = string.Empty;
        public int Width { get; }
        public int Height { get; }
        public int SlotNumber { get; set; }
        public int Max { get; }
        public int MaxOneSlot { get; }

        public ItemObject() { }

        public ItemObject(int index, int id, string name, int width, int height, int max, int maxOneSlot)
        {
            Index = index;
            Id = id;
            Name = name;
            Width = width;
            Height = height;
            Max = max;
            MaxOneSlot = maxOneSlot;
        }

        public static bool operator ==(ItemObject a, ItemObject b)
        {
            return a.Id.Equals(b.Id);
        }

        public static bool operator !=(ItemObject a, ItemObject b)
        {
            return !a.Id.Equals(b.Id);
        }
    }

    public class NullObject : ItemObject
    {
        public NullObject()
        {
            Index = 999999999;
            Id = 999999999;
        }
    }
} 