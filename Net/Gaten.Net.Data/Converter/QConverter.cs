namespace Gaten.Net.Data.Converter
{
    /// <summary>
    /// 테스트가 안 끝난 임시 다중 컨버터
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QConverter<T>
    {
        public static bool ToBool(T x) { return Convert.ToBoolean(x); }
        public static bool[] ToBoolArray(T[] x) { return x.Select(t => Convert.ToBoolean(t)).ToArray(); }
        public static List<bool> ToBoolList(List<T> x) { return x.Select(t => Convert.ToBoolean(t)).ToList(); }
        public static byte ToByte(T x) { return Convert.ToByte(x); }
        public static byte[] ToByteArray(T[] x) { return x.Select(t => Convert.ToByte(t)).ToArray(); }
        public static List<byte> ToByteList(List<T> x) { return x.Select(t => Convert.ToByte(t)).ToList(); }
        public static sbyte ToSByte(T x) { return Convert.ToSByte(x); }
        public static sbyte[] ToSByteArray(T[] x) { return x.Select(t => Convert.ToSByte(t)).ToArray(); }
        public static List<sbyte> ToSByteList(List<T> x) { return x.Select(t => Convert.ToSByte(t)).ToList(); }
        public static char ToChar(T x) { return Convert.ToChar(x); }
        public static char[] ToCharArray(T[] x) { return x.Select(t => Convert.ToChar(t)).ToArray(); }
        public static List<char> ToCharList(List<T> x) { return x.Select(t => Convert.ToChar(t)).ToList(); }
        public static decimal ToDecimal(T x) { return Convert.ToDecimal(x); }
        public static decimal[] ToDecimalArray(T[] x) { return x.Select(t => Convert.ToDecimal(t)).ToArray(); }
        public static List<decimal> ToDecimalList(List<T> x) { return x.Select(t => Convert.ToDecimal(t)).ToList(); }
        public static float ToFloat(T x) { return Convert.ToSingle(x); }
        public static float[] ToFloatArray(T[] x) { return x.Select(t => Convert.ToSingle(t)).ToArray(); }
        public static List<float> ToFloatList(List<T> x) { return x.Select(t => Convert.ToSingle(t)).ToList(); }
        public static double ToDouble(T x) { return Convert.ToDouble(x); }
        public static double[] ToDoubleArray(T[] x) { return x.Select(t => Convert.ToDouble(t)).ToArray(); }
        public static List<double> ToDoubleList(List<T> x) { return x.Select(t => Convert.ToDouble(t)).ToList(); }
        public static short ToShort(T x) { return Convert.ToInt16(x); }
        public static short[] ToShortArray(T[] x) { return x.Select(t => Convert.ToInt16(t)).ToArray(); }
        public static List<short> ToShortList(List<T> x) { return x.Select(t => Convert.ToInt16(t)).ToList(); }
        public static int ToInt(T x) { return Convert.ToInt32(x); }
        public static int[] ToIntArray(T[] x) { return x.Select(t => Convert.ToInt32(t)).ToArray(); }
        public static List<int> ToIntList(List<T> x) { return x.Select(t => Convert.ToInt32(t)).ToList(); }
        public static long ToLong(T x) { return Convert.ToInt64(x); }
        public static long[] ToLongArray(T[] x) { return x.Select(t => Convert.ToInt64(t)).ToArray(); }
        public static List<long> ToLongList(List<T> x) { return x.Select(t => Convert.ToInt64(t)).ToList(); }
        public static ushort ToUShort(T x) { return Convert.ToUInt16(x); }
        public static ushort[] ToUShortArray(T[] x) { return x.Select(t => Convert.ToUInt16(t)).ToArray(); }
        public static List<ushort> ToUShortList(List<T> x) { return x.Select(t => Convert.ToUInt16(t)).ToList(); }
        public static uint ToUInt(T x) { return Convert.ToUInt32(x); }
        public static uint[] ToUIntArray(T[] x) { return x.Select(t => Convert.ToUInt32(t)).ToArray(); }
        public static List<uint> ToUIntList(List<T> x) { return x.Select(t => Convert.ToUInt32(t)).ToList(); }
        public static ulong ToULong(T x) { return Convert.ToUInt64(x); }
        public static ulong[] ToULongArray(T[] x) { return x.Select(t => Convert.ToUInt64(t)).ToArray(); }
        public static List<ulong> ToULongList(List<T> x) { return x.Select(t => Convert.ToUInt64(t)).ToList(); }
        public static string ToString(T x) { return x.ToString(); }
        public static string[] ToStringArray(T[] x) { return x.Select(t => t.ToString()).ToArray(); }
        public static List<string> ToStringList(List<T> x) { return x.Select(t => t.ToString()).ToList(); }
        public static object ToObject(object x) { return x; }
        public static object[] ToObject(object[] x) { return x; }
        public static List<object> ToObject(List<object> x) { return x; }
    }
}
