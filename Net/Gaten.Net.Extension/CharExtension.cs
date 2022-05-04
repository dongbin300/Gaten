using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Extension
{
    public static class CharExtension
    {
        public static byte ToByte(this char c) => c < 65 ? (byte)(c - 48) : (byte)(c - 55);

        /// <summary>
        /// 알파벳 숫자
        /// ex) A => 1, B => 2, C => 3
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int AlphabetId(this char c) => c >= 'A' && c <= 'Z' ? c - 'A' + 1 : c >= 'a' && c <= 'z' ? c - 'a' + 1 : 0;
    }
}
