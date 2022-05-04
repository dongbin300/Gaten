using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace MintChocoLibrary.Resources.Utils
{
    public class DataUtil
    {
        /// <summary>
        /// 바이트 배열에서 일정 바이트 배열을 추출
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static byte[] GetBytes(byte[] data, int startIndex, int count)
        {
            byte[] data2 = new byte[count];
            Buffer.BlockCopy(data, startIndex, data2, 0, count);

            return data2;
        }

        /// <summary>
        /// 바이트 배열을 역변환
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] ReverseBytes(byte[] bytes)
        {
            Array.Reverse(bytes, 0, bytes.Length);
            return bytes;
        }

        public static short ReverseBytes(short value)
        {
            return (short)((value & 0xFF) << 8 | (value & 0xFF00) >> 8);
        }

        public static ushort ReverseBytes(ushort value)
        {
            return (ushort)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        public static int ReverseBytes(int value)
        {
            return (value & 0x000000FF) << 24 | (value & 0x0000FF00) << 8 |
                    (value & 0x00FF0000) >> 8 | ((int)(value & 0xFF000000)) >> 24;
        }

        public static uint ReverseBytes(uint value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        public static long ReverseBytes(long value)
        {
            return (value & 0x00000000000000FFL) << 56 | (value & 0x000000000000FF00L) << 40 |
                   (value & 0x0000000000FF0000L) << 24 | (value & 0x00000000FF000000L) << 8 |
                   (value & 0x000000FF00000000L) >> 8 | (value & 0x0000FF0000000000L) >> 24 |
                   (value & 0x00FF000000000000L) >> 40 | ((long)((ulong)value & 0xFF00000000000000L)) >> 56;
        }

        public static ulong ReverseBytes(ulong value)
        {
            return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        }

        public static void ConcatenateBytes(ref byte[] bytes, int index, object target, bool isLittleEndian = false)
        {
            byte[] targetBytes = null;
            Type t = target.GetType();

            switch (t.Name)
            {
                case "byte":
                case "Byte":
                    targetBytes = new byte[] { (byte)target };
                    break;
                case "byte[]":
                case "Byte[]":
                    targetBytes = (byte[])target;
                    break;
                case "short":
                case "Int16":
                    targetBytes = BitConverter.GetBytes((short)target);
                    break;
                case "ushort":
                case "UInt16":
                    targetBytes = BitConverter.GetBytes((ushort)target);
                    break;
                case "int":
                case "Int32":
                    targetBytes = BitConverter.GetBytes((int)target);
                    break;
                case "uint":
                case "UInt32":
                    targetBytes = BitConverter.GetBytes((uint)target);
                    break;
                case "long":
                case "Int64":
                    targetBytes = BitConverter.GetBytes((long)target);
                    break;
                case "ulong":
                case "UInt64":
                    targetBytes = BitConverter.GetBytes((ulong)target);
                    break;
                default:
                    break;
            }

            if (isLittleEndian)
            {
                targetBytes = ReverseBytes(targetBytes);
            }

            Buffer.BlockCopy(targetBytes, 0, bytes, index, targetBytes.Length);
        }

        public static uint StringToUInt(string data)
        {
            uint result = 0;

            string str = data.Substring(0, Math.Min(4, data.Length));
            for (int i = 0; i < str.Length; i++)
            {
                result += (uint)str[i] << 8 * i;
            }

            return result;
        }

        public static uint[] LongStringToUInts(string data)
        {
            int uintValueCount = (data.Length - 1) / 4 + 1;
            uint[] result = new uint[uintValueCount];

            for (int i = 0; i < uintValueCount; i++)
            {
                string splitData = data.Substring(i * 4, Math.Min(4, data.Length - i * 4));
                result[i] = StringToUInt(splitData);
            }

            return result;
        }

        public static Encoding GetEncoding(string filename)
        {
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.Default;
        }

        public static uint GetUInt32(byte[] bytes, int startIndex, bool isLittleEndian = false)
        {
            return isLittleEndian ?
                BitConverter.ToUInt32(bytes, startIndex) :
                ReverseBytes(BitConverter.ToUInt32(bytes, startIndex));
        }

        public static char ByteToHexChar(byte b)
        {
            return b < 10 ? (char)(b + 48) : (char)(b + 55);
        }

        public static byte HexCharToByte(char c)
        {
            return c < 65 ? (byte)(c - 48) : (byte)(c - 55);
        }

        /// <summary>
        /// only trim start
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] TrimBytes(byte[] data)
        {
            while (data[0] == 0)
            {
                data = GetBytes(data, 1, data.Length - 1);
            }

            return data;
        }

        public static string GetHexString(object input, bool autoSize = false)
        {
            char[] ch;
            int len;

            Type t = input.GetType();

            switch (t.Name)
            {
                case "byte":
                case "Byte":
                    len = 2;
                    ch = new char[len--];
                    for (int i = len; i >= 0; i--)
                    {
                        ch[len - i] = ByteToHexChar((byte)((uint)((byte)input >> 4 * i) & 15));
                    }
                    break;

                case "byte[]":
                case "Byte[]":
                    var byteLength = ((byte[])input).Length;
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < byteLength; i++)
                    {
                        builder.Append(GetHexString(((byte[])input)[i]));
                    }
                    return builder.ToString();

                case "short":
                case "Int16":
                    len = 4;
                    ch = new char[len--];
                    if (autoSize)
                    {
                        return GetHexString(TrimBytes(ReverseBytes(BitConverter.GetBytes((short)input))));
                    }
                    else
                    {
                        for (int i = len; i >= 0; i--)
                        {
                            ch[len - i] = ByteToHexChar((byte)((uint)((short)input >> 4 * i) & 15));
                        }
                    }
                    break;

                case "ushort":
                case "UInt16":
                    len = 4;
                    ch = new char[len--];
                    if (autoSize)
                    {
                        return GetHexString(TrimBytes(ReverseBytes(BitConverter.GetBytes((ushort)input))));
                    }
                    else
                    {
                        for (int i = len; i >= 0; i--)
                        {
                            ch[len - i] = ByteToHexChar((byte)((uint)((ushort)input >> 4 * i) & 15));
                        }
                    }
                    break;

                case "int":
                case "Int32":
                    len = 8;
                    ch = new char[len--];
                    if (autoSize)
                    {
                        return GetHexString(TrimBytes(ReverseBytes(BitConverter.GetBytes((int)input))));
                    }
                    else
                    {
                        for (int i = len; i >= 0; i--)
                        {
                            ch[len - i] = ByteToHexChar((byte)((uint)((int)input >> 4 * i) & 15));
                        }
                    }
                    break;

                case "uint":
                case "UInt32":
                    len = 8;
                    ch = new char[len--];
                    if (autoSize)
                    {
                        return GetHexString(TrimBytes(ReverseBytes(BitConverter.GetBytes((uint)input))));
                    }
                    else
                    {
                        for (int i = len; i >= 0; i--)
                        {
                            ch[len - i] = ByteToHexChar((byte)(((uint)input >> 4 * i) & 15));
                        }
                    }
                    break;

                case "long":
                case "Int64":
                    len = 16;
                    ch = new char[len--];
                    if (autoSize)
                    {
                        return GetHexString(TrimBytes(ReverseBytes(BitConverter.GetBytes((long)input))));
                    }
                    else
                    {
                        for (int i = len; i >= 0; i--)
                        {
                            ch[len - i] = ByteToHexChar((byte)((uint)((long)input >> 4 * i) & 15));
                        }
                    }
                    break;

                case "ulong":
                case "UInt64":
                    len = 16;
                    ch = new char[len--];
                    if (autoSize)
                    {
                        return GetHexString(TrimBytes(ReverseBytes(BitConverter.GetBytes((ulong)input))));
                    }
                    else
                    {
                        for (int i = len; i >= 0; i--)
                        {
                            ch[len - i] = ByteToHexChar((byte)((uint)((ulong)input >> 4 * i) & 15));
                        }
                    }
                    break;

                default:
                    return string.Empty;
            }

            return new string(ch);
        }

        public static byte[] HexStringToBytes(string str)
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
                if (!((str2[i] >= '0' && str2[i] <= '9') || (str2[i] >= 'A' && str2[i] <= 'F')))
                {
                    bytes[i / 2] = 0;
                    continue;
                }

                if (!((str2[i + 1] >= '0' && str2[i + 1] <= '9') || (str2[i + 1] >= 'A' && str2[i + 1] <= 'F')))
                {
                    bytes[i / 2] = 0;
                    continue;
                }
                bytes[i / 2] = (byte)((byte)(HexCharToByte(str2[i]) << 4) + HexCharToByte(str2[i + 1]));
            }

            return bytes;
        }
    }
}
