namespace Gaten.Net.Extensions
{
    public static class DataTypeExtension
    {
        public static T? Cast<T>(this object? input)
        {
            return (T)(input ?? default!);
        }

        public static T? Convert<T>(this object? input)
        {
            if (input == null)
            {
                return default;
            }

            Type type = typeof(T);

            if (type.BaseType?.FullName?.Equals("System.Enum") ?? true)
            {
                return (T)Enum.Parse(type, input.ToString() ?? string.Empty);
            }
            else
            {
                return (T)System.Convert.ChangeType(input, type);
            }
        }
    }
}
