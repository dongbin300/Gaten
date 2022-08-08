using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Extensions
{
    public static class ShortExtension
    {
        public static short ReverseBytes(this short value) => (short)((value & 0xFF) << 8 | (value & 0xFF00) >> 8);

        public static ushort ReverseBytes(this ushort value) => (ushort)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
    }
}
