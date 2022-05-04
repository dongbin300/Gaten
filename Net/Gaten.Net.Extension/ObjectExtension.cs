using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Extension
{
    public enum ExtensionTypeCode
    {
        Empty,
        Object,
        Byte,
        ByteArray,
        Int16,
        Int32,
        Int64,
        UInt16,
        UInt32,
        UInt64,
    }

    public static class ObjectExtension
    {
        /// <summary>
        /// Get TypeCode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ExtensionTypeCode GetTypeCode(this object input)
        {
            if(input == null)
            {
                return ExtensionTypeCode.Empty;
            }

            return input.GetType().Name switch
            {
                "byte" or "Byte" => ExtensionTypeCode.Byte,
                "byte[]" or "Byte[]" => ExtensionTypeCode.ByteArray,
                "short" or "Int16" => ExtensionTypeCode.Int16,
                "ushort" or "UInt16" => ExtensionTypeCode.UInt16,
                "int" or "Int32" => ExtensionTypeCode.Int32,
                "uint" or "UInt32" => ExtensionTypeCode.UInt32,
                "long" or "Int64" => ExtensionTypeCode.Int64,
                "ulong" or "UInt64" => ExtensionTypeCode.UInt64,
                _ => ExtensionTypeCode.Object
            };
        }

        /// <summary>
        /// Get Size
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetSize(this object input)
        {
            if (input == null)
            {
                return 0;
            }

            return input.GetTypeCode() switch
            {
                ExtensionTypeCode.Byte => 1,
                ExtensionTypeCode.ByteArray => ((byte[])input).Length,
                ExtensionTypeCode.Int16 => 2,
                ExtensionTypeCode.UInt16 => 2,
                ExtensionTypeCode.Int32 => 4,
                ExtensionTypeCode.UInt32 => 4,
                ExtensionTypeCode.Int64 => 8,
                ExtensionTypeCode.UInt64 => 8,
                _ => 0
            };
        }

        public static byte[] ToBytes(this object input, bool reverse = false)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var result = input.GetTypeCode() switch
            {
                ExtensionTypeCode.Byte => new byte[] { (byte)input },
                ExtensionTypeCode.ByteArray => (byte[])input,
                ExtensionTypeCode.Int16 => BitConverter.GetBytes((short)input),
                ExtensionTypeCode.UInt16 => BitConverter.GetBytes((ushort)input),
                ExtensionTypeCode.Int32 => BitConverter.GetBytes((int)input),
                ExtensionTypeCode.UInt32 => BitConverter.GetBytes((uint)input),
                ExtensionTypeCode.Int64 => BitConverter.GetBytes((long)input),
                ExtensionTypeCode.UInt64 => BitConverter.GetBytes((ulong)input),
                _ => throw new NotSupportedException("Unsupported data type(" + input.GetType().Name + ")"),
            };

            return reverse ? result.ReverseBytes() : result;
        }

        /// <summary>
        /// Big Endian / Little Endian<br/>
        /// (byte)15 -> "0F" / "0F"<br/>
        /// (int)15 -> "0000000F" / "0F000000"<br/>
        /// </summary>
        /// <param name="input">input type: byte, byte[], short, ushort, int, uint, long, ulong</param>
        /// <param name="autoSize"></param>
        /// <returns></returns>
        public static string ToHexString(this object input, bool reverse = false)
        { 
            return BitConverter.ToString(input.ToBytes(reverse)).Replace("-", "");
        }
    }
}
