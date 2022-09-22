using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Extensions
{
    public static class DataTypeExtension
    {
        public static T Cast<T>(this object input)
        {
            return (T)input;
        }

        public static T Convert<T>(this object input)
        {
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
