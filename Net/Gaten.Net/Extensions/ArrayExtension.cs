namespace Gaten.Net.Extensions
{
    public static class ArrayExtension
    {
        public static void Fill<T>(this T[] array, T value)
        {
            Array.Fill(array, value);
        }

        public static void Fill<T>(this T[] array, T value, int startIndex, int count)
        {
            Array.Fill(array, value, startIndex, count);
        }

        public static void Fill<T>(this T[,] array, T value)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = value;
                }
            }
        }

        public static T[,] Split<T>(this T[,] array, int startX, int startY, int width, int height)
        {
            T[,] results = new T[width, height];

            for (var i = startX; i < startX + width; i++)
            {
                for (var j = startY; j < startY + height; j++)
                {
                    results[i - startX, j - startY] = array[i, j];
                }
            }

            return results;
        }

        public static T[] GetColumn<T>(this T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public static T[] GetRow<T>(this T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}
