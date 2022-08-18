namespace Gaten.Net.Extensions
{
    public static class IListExtension
    {
        public static void AddToCollectionRecursive(this IList<int[]> collection, params int[] counts)
        {
            AddTo(collection, new List<int>(), counts, counts.Length - 1);
        }

        public static void AddTo(this IList<int[]> collection, IEnumerable<int> value, IEnumerable<int> counts, int left)
        {
            for (var i = 0; i < counts.First(); i++)
            {
                var list = value.ToList();

                list.Add(i);

                if (left == 0)
                {
                    collection.Add(list.ToArray());
                }
                else
                {
                    AddTo(collection, list, counts.Skip(1), left - 1);
                }
            }
        }
    }
}
