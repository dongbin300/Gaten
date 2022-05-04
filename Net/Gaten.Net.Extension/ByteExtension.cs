using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Extension
{
    public static class ByteExtension
    {
        /// <summary>
        /// 바이트 배열에서 일정 바이트 배열을 추출
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this byte[] bytes, int startIndex, int count)
        {
            byte[] data2 = new byte[count];
            Buffer.BlockCopy(bytes, startIndex, data2, 0, count);

            return data2;
        }

        /// <summary>
        /// 바이트 배열을 역변환
        /// (LINQ Reverse() 보다 빠름)
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] ReverseBytes(this byte[] bytes)
        {
            Array.Reverse(bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// 바이트 배열에서 특정 바이트 패턴(배열) 찾기
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="searchBytes"></param>
        /// <returns></returns>
        public static int IndexOfBytes(this byte[] bytes, byte[] searchBytes)
        {
            if (searchBytes.Length > bytes.Length)
            {
                return -1;
            }

            for (int i = 0; i < bytes.Length - searchBytes.Length; i++)
            {
                bool found = true;
                for (int j = 0; j < searchBytes.Length; j++)
                {
                    if (bytes[i + j] != searchBytes[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return i;
                }
            }
            return -1;
        }

        public static char ToChar(this byte b) => b < 10 ? (char)(b + 48) : (char)(b + 55);

        public static void CopyHexStringBytes(this byte[] bytes, int index, string target)
        {
            var targetBytes = target.ToBytes();

            Buffer.BlockCopy(targetBytes, 0, bytes, index, targetBytes.Length);
        }

        public static void CopyHexStringBytes(this List<byte> bytes, string target)
        {
            var targetBytes = target.ToBytes();

            bytes.AddRange(targetBytes.ToList());
        }

        public static void CopyBytes(this byte[] bytes, int index, object target, bool isLittleEndian = false)
        {
            byte[] targetBytes = target.ToBytes();

            if (isLittleEndian)
            {
                targetBytes = targetBytes.ReverseBytes();
            }

            Buffer.BlockCopy(targetBytes, 0, bytes, index, targetBytes.Length);
        }

        /// <summary>
        /// only trim start<br/>
        /// 0000000F -> 0F
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] Trim(this byte[] bytes)
        {
            while (bytes[0] == 0)
            {
                bytes = GetBytes(bytes, 1, bytes.Length - 1);
            }

            return bytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string UnsignedToSignedHexString(this byte[] bytes)
        {
            switch (bytes.Length)
            {
                case 1:
                    sbyte int8 = (sbyte)bytes[0];
                    return (int8 >= 0 ? "+" : "-") + Math.Abs(int8).ToHexString();

                case 2:
                    short int16 = BitConverter.ToInt16(bytes);
                    return (int16 >= 0 ? "+" : "-") + Math.Abs(int16).ToHexString();

                case 4:
                    int int32 = BitConverter.ToInt32(bytes);
                    return (int32 >= 0 ? "+" : "-") + Math.Abs(int32).ToHexString();

                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// byte[] 배열 직렬화
        /// Gaten.Net.Data.Serialization.Serializer.Serialize()보다 5배정도 빠름
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static byte[] Serialize(this byte[] b1, byte[] b2)
        {
            byte[] result = new byte[b1.Length + b2.Length];
            b1.CopyTo(result, 0);
            b2.CopyTo(result, b1.Length);

            return result;
        }

        public static byte[] Serialize(this byte[] b1, byte[] b2, byte[] b3)
        {
            byte[] result = new byte[b1.Length + b2.Length + b3.Length];
            b1.CopyTo(result, 0);
            b2.CopyTo(result, b1.Length);
            b3.CopyTo(result, b1.Length + b2.Length);

            return result;
        }

        public static byte[] Serialize(this byte[] b1, byte[] b2, byte[] b3, byte[] b4)
        {
            byte[] result = new byte[b1.Length + b2.Length + b3.Length + b4.Length];
            b1.CopyTo(result, 0);
            b2.CopyTo(result, b1.Length);
            b3.CopyTo(result, b1.Length + b2.Length);
            b4.CopyTo(result, b1.Length + b2.Length + b3.Length);

            return result;
        }

        public static byte[] Serialize(this byte[] b1, byte[] b2, byte[] b3, byte[] b4, byte[] b5)
        {
            byte[] result = new byte[b1.Length + b2.Length + b3.Length + b4.Length + b5.Length];
            b1.CopyTo(result, 0);
            b2.CopyTo(result, b1.Length);
            b3.CopyTo(result, b1.Length + b2.Length);
            b4.CopyTo(result, b1.Length + b2.Length + b3.Length);
            b5.CopyTo(result, b1.Length + b2.Length + b3.Length + b4.Length);

            return result;
        }

        public static byte[] Serialize(this byte[] b1, byte[] b2, byte[] b3, byte[] b4, byte[] b5, byte[] b6)
        {
            byte[] result = new byte[b1.Length + b2.Length + b3.Length + b4.Length + b5.Length + b6.Length];
            b1.CopyTo(result, 0);
            b2.CopyTo(result, b1.Length);
            b3.CopyTo(result, b1.Length + b2.Length);
            b4.CopyTo(result, b1.Length + b2.Length + b3.Length);
            b5.CopyTo(result, b1.Length + b2.Length + b3.Length + b4.Length);
            b6.CopyTo(result, b1.Length + b2.Length + b3.Length + b4.Length + b5.Length);

            return result;
        }

        public static byte[] Serialize(this byte[] b1, byte[] b2, byte[] b3, byte[] b4, byte[] b5, byte[] b6, byte[] b7)
        {
            byte[] result = new byte[b1.Length + b2.Length + b3.Length + b4.Length + b5.Length + b6.Length + b7.Length];
            b1.CopyTo(result, 0);
            b2.CopyTo(result, b1.Length);
            b3.CopyTo(result, b1.Length + b2.Length);
            b4.CopyTo(result, b1.Length + b2.Length + b3.Length);
            b5.CopyTo(result, b1.Length + b2.Length + b3.Length + b4.Length);
            b6.CopyTo(result, b1.Length + b2.Length + b3.Length + b4.Length + b5.Length);
            b7.CopyTo(result, b1.Length + b2.Length + b3.Length + b4.Length + b5.Length + b6.Length);

            return result;
        }

        public static byte[] Serialize(this byte[] b1, byte[] b2, byte[] b3, byte[] b4, byte[] b5, byte[] b6, byte[] b7, byte[] b8)
        {
            byte[] result = new byte[b1.Length + b2.Length + b3.Length + b4.Length + b5.Length + b6.Length + b7.Length + b8.Length];
            b1.CopyTo(result, 0);
            b2.CopyTo(result, b1.Length);
            b3.CopyTo(result, b1.Length + b2.Length);
            b4.CopyTo(result, b1.Length + b2.Length + b3.Length);
            b5.CopyTo(result, b1.Length + b2.Length + b3.Length + b4.Length);
            b6.CopyTo(result, b1.Length + b2.Length + b3.Length + b4.Length + b5.Length);
            b7.CopyTo(result, b1.Length + b2.Length + b3.Length + b4.Length + b5.Length + b6.Length);
            b8.CopyTo(result, b1.Length + b2.Length + b3.Length + b4.Length + b5.Length + b6.Length + b7.Length);

            return result;
        }

        /// <summary>
        /// 숫자가 범위안에 포함되는지 확인
        /// </summary>
        /// <param name="x">대상</param>
        /// <param name="min">최소값</param>
        /// <param name="max">최대값</param>
        /// <returns></returns>
        public static bool IsRange(this byte x, byte min, byte max)
        {
            return x >= min && x <= max;
        }

        /// <summary>
        /// RGB의 평균
        /// </summary>
        /// <param name="value">RGB 값</param>
        /// <returns>RGB의 평균값</returns>
        public static int RGBAverage(this byte[] value)
        {
            int sum = 0;
            for (int i = 0; i < value.Length; i += 4)
            {
                sum += value[i];
                sum += value[i + 1];
                sum += value[i + 2];
            }
            return (int)(sum / value.Length * 1.33);
        }

        /// <summary>
        /// 두 비트맵의 일치도
        /// </summary>
        /// <param name="capture">비트맵 1</param>
        /// <param name="target">비트맵 2</param>
        /// <returns>일치도</returns>
        public static double SameDegree(this byte[] capture, byte[] target)
        {
            int diffSum = 0;
            for (int i = 0; i < target.Length; i++)
            {
                diffSum += Math.Abs(capture[i] - target[i]);
            }
            return 100.0 - (100.0 * diffSum / (256.0 * target.Length));
        }
    }
}
