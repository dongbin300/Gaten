using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Extension
{
    public static class DataTypeExtension
    {
        public static T Cast<T>(this object input)
        {
            return (T)input;
        }

        public static T Convert<T>(this object input)
        {
            return (T)System.Convert.ChangeType(input, typeof(T));
        }
    }
}
