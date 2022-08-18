using Gaten.Net.Extensions;

using System.Collections;

namespace Gaten.Net.Collections
{
    public static class BitArrayExtension
    {
        public static void Set(this BitArray array, bool[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                array.Set(i, values[i]);
            }
        }

        public static void Set(this BitArray array, int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                array.Set(i, values[i] != 0);
            }
        }

        public static void Set(this BitArray array, string values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                array.Set(i, values[i].Convert<int>().Convert<bool>());
            }
        }
    }
}
