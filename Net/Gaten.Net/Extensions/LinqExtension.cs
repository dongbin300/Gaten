namespace Gaten.Net.Extensions
{
    public static class LinqExtension
    {
        public static IEnumerable<T> Substring<T>(this IEnumerable<T> source, int startIndex)
        {
            return source.Skip(startIndex);
        }

        public static IEnumerable<T> Substring<T>(this IEnumerable<T> source, int startIndex, int length)
        {
            return source.Skip(startIndex).Take(length);
        }

        public static T Median<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => x).ToArray()[source.Count() / 2];
        }

        public static IEnumerable<string> Remove(this IEnumerable<string> source, string value)
        {
            return source.Select(x => x.Replace(value, string.Empty));
        }

        public static IEnumerable<int> Rank<T>(this IEnumerable<T> source)
        {
            return source
                .GroupBy(x => x)
                .OrderByDescending(x => x.Key)
                .Select((x, index) => (num: x.Key, rank: index + 1))
                .Select(x => x.rank)
                .ToList();
        }
    }
}
