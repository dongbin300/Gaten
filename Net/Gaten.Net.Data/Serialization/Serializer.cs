using Gaten.Net.Extension;

namespace Gaten.Net.Data.Serialization
{
    public class Serializer
    {
        private byte[] bytes;
        private int index;

        public Serializer()
        {
            bytes = Array.Empty<byte>();
            index = 0;
        }

        public void Add(object target, bool isLittleEndian = false)
        {
            int targetSize = target.GetSize();

            // bytes -> newBytes
            byte[] newBytes = new byte[bytes.Length + targetSize];
            bytes.CopyTo(newBytes, 0);

            newBytes.CopyBytes(index, target, isLittleEndian);

            // newBytes -> bytes
            bytes = new byte[newBytes.Length];
            newBytes.CopyTo(bytes, 0);

            index += targetSize;
        }

        public byte[] ToBytes() => bytes;

        public override string ToString() => bytes.ToHexString();

        #region Serialize
        public static byte[] Serialize(object o1, object o2)
        {
            byte[] b1 = o1.ToBytes();
            byte[] b2 = o2.ToBytes();

            return b1.Serialize(b2);
        }

        public static byte[] Serialize(object o1, object o2, object o3)
        {
            byte[] b1 = o1.ToBytes();
            byte[] b2 = o2.ToBytes();
            byte[] b3 = o3.ToBytes();

            return b1.Serialize(b2, b3);
        }

        public static byte[] Serialize(object o1, object o2, object o3, object o4)
        {
            byte[] b1 = o1.ToBytes();
            byte[] b2 = o2.ToBytes();
            byte[] b3 = o3.ToBytes();
            byte[] b4 = o4.ToBytes();

            return b1.Serialize(b2, b3, b4);
        }


        public static byte[] Serialize(object o1, object o2, object o3, object o4, object o5)
        {
            byte[] b1 = o1.ToBytes();
            byte[] b2 = o2.ToBytes();
            byte[] b3 = o3.ToBytes();
            byte[] b4 = o4.ToBytes();
            byte[] b5 = o5.ToBytes();

            return b1.Serialize(b2, b3, b4, b5);
        }

        public static byte[] Serialize(object o1, object o2, object o3, object o4, object o5, object o6)
        {
            byte[] b1 = o1.ToBytes();
            byte[] b2 = o2.ToBytes();
            byte[] b3 = o3.ToBytes();
            byte[] b4 = o4.ToBytes();
            byte[] b5 = o5.ToBytes();
            byte[] b6 = o6.ToBytes();

            return b1.Serialize(b2, b3, b4, b5, b6);
        }

        public static byte[] Serialize(object o1, object o2, object o3, object o4, object o5, object o6, object o7)
        {
            byte[] b1 = o1.ToBytes();
            byte[] b2 = o2.ToBytes();
            byte[] b3 = o3.ToBytes();
            byte[] b4 = o4.ToBytes();
            byte[] b5 = o5.ToBytes();
            byte[] b6 = o6.ToBytes();
            byte[] b7 = o7.ToBytes();

            return b1.Serialize(b2, b3, b4, b5, b6, b7);
        }

        public static byte[] Serialize(object o1, object o2, object o3, object o4, object o5, object o6, object o7, object o8)
        {
            byte[] b1 = o1.ToBytes();
            byte[] b2 = o2.ToBytes();
            byte[] b3 = o3.ToBytes();
            byte[] b4 = o4.ToBytes();
            byte[] b5 = o5.ToBytes();
            byte[] b6 = o6.ToBytes();
            byte[] b7 = o7.ToBytes();
            byte[] b8 = o8.ToBytes();

            return b1.Serialize(b2, b3, b4, b5, b6, b7, b8);
        }
        #endregion

    }
}