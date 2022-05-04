using System.Text;
using System.Text.RegularExpressions;
using System;

namespace Gaten.Net.Extension
{
    public static class StringExtension
    {
        public static bool IsNumericString(this string str)
        {
            return decimal.TryParse(str, out decimal _);
        }

        public static bool IsHexaDecimalString(this string str)
        {
            if (str.StartsWith("0X") || str.EndsWith("H")) // hexa-decimal
            {
                return Regex.IsMatch(str.Replace("0X", "").Replace("H", ""), @"^[A-F0-9]+$");
            }
            else // decimal
            {
                return IsNumericString(str);
            }
        }

        public static byte ToByte(this string str) => (byte)(str[0].ToByte() * 16 + str[1].ToByte());

        public static byte[] ToBytes(this string str)
        {
            string str2 = str.ToUpper().Replace(" ", "");
            int length = str2.Length;

            if (length % 2 == 1)
            {
                str2 = "0" + str2;
                length++;
            }

            byte[] bytes = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = (byte)((byte)(str2[i].ToByte() << 4) + str2[i + 1].ToByte());
            }

            return bytes;
        }

        /// <summary>
        /// "ABCD" -> { 41, 42, 43, 44 }
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] AsciiToBytes(this string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        public static short ToShort(this string str, bool isLittleEndian = false)
        {
            return BitConverter.ToInt16(isLittleEndian ? str.ToBytes() : str.ToBytes().ReverseBytes());
        }

        public static ushort ToUShort(this string str, bool isHexString = false, bool isLittleEndian = false)
        {
            if (isHexString)
            {
                return BitConverter.ToUInt16(isLittleEndian ? str.ToBytes() : str.ToBytes().ReverseBytes());
            }
            else
            {
                ushort result = 0;

                string str2 = str[..Math.Min(2, str.Length)];
                for (int i = 0; i < str2.Length; i++)
                {
                    result += (ushort)(str2[i] << (ushort)(8 * i));
                }

                return result;
            }
        }

        public static int ToInt(this string str, bool isLittleEndian = false)
        {
            string str2 = new string('0', 8 - str.Length) + str;

            return BitConverter.ToInt32(isLittleEndian ? str2.ToBytes() : str2.ToBytes().ReverseBytes());
        }

        public static uint ToUInt(this string str, bool isHexString = false, bool isLittleEndian = false)
        {
            if (isHexString)
            {
                return BitConverter.ToUInt32(isLittleEndian ? str.ToBytes() : str.ToBytes().ReverseBytes());
            }
            else
            {
                uint result = 0;

                string str2 = str[..Math.Min(4, str.Length)];
                for (int i = 0; i < str2.Length; i++)
                {
                    result += (uint)str2[i] << 8 * i;
                }

                return result;
            }
        }

        public static long ToLong(this string str, bool isLittleEndian = false)
        {
            return BitConverter.ToInt64(isLittleEndian ? str.ToBytes() : str.ToBytes().ReverseBytes());
        }

        public static ulong ToULong(this string str, bool isHexString = false, bool isLittleEndian = false)
        {
            if (isHexString)
            {
                return BitConverter.ToUInt64(isLittleEndian ? str.ToBytes() : str.ToBytes().ReverseBytes());
            }
            else
            {
                ulong result = 0;

                string str2 = str[..Math.Min(8, str.Length)];
                for (int i = 0; i < str2.Length; i++)
                {
                    result += (ulong)str2[i] << 8 * i;
                }

                return result;
            }
        }

        /// <summary>
        /// C:\osu\Songs\Venom
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDirectory(this string path)
        {
            string[] data = path.Split('\\');
            return path.Replace(data[^1], "");
        }

        /// <summary>
        /// Venom (gaten) [Insane].osu
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileName(this string path)
        {
            string[] data = path.Split('\\');
            return data[^1];
        }

        /// <summary>
        /// .osu
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetExtension(this string path)
        {
            return path[path.LastIndexOf('.')..];
        }

        /// <summary>
        /// Venom (gaten) [Insane]
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetOnlyFileName(this string path)
        {
            string data = GetFileName(path);
            return data.Replace(GetExtension(path), "");
        }

        /// <summary>
        /// Venom (gaten)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetExceptDifficulty(this string path)
        {
            string[] data = GetOnlyFileName(path).Split('[');
            return data[0].Trim();
        }

        /// <summary>
        /// 문자열 왼쪽 이동 (circular)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ShiftLeft(this string s, int n = 1)
        {
            return (s + s[..n])[n..];
        }

        /// <summary>
        /// 문자열 오른쪽 이동 (circular)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ShiftRight(this string s, int n = 1)
        {
            return string.Concat(s.AsSpan(s.Length - n, n), s)[..s.Length];
        }

        /// <summary>
        /// 문자열 역순
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Reverse(this string s)
        {
            string t = string.Empty;
            for (int i = 0; i < s.Length; i++)
                t += s[s.Length - 1 - i];
            return t;
        }

        /// <summary>
        /// 0~9 숫자를 하나 이상씩 포함하는지
        /// ex) str="019876543212345" => true
        /// </summary>
        /// <param name="str">검사 대상 문자열</param>
        /// <returns></returns>
        public static bool IsWidePandigitalNumber(this string str)
        {
            bool[] ch = new bool[10];
            foreach (char c in str)
                ch[int.Parse(c.ToString())] = true;

            return !ch.Where(b => b == false).Any();
        }
    }
}