using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHKFormat
{
    public class Util
    {

        

        public static List<byte> IntToLittleEndian(int data)
        {
            List<byte> b = new List<byte>();

            b.Add((byte)data);
            b.Add((byte)(((uint)data >> 8) & 0xFF));
            b.Add((byte)(((uint)data >> 16) & 0xFF));
            b.Add((byte)(((uint)data >> 24) & 0xFF));

            return b;
        }

        public static byte[] GetBytes(object[] objs)
        {
            List<byte> b = new List<byte>();

            foreach (object obj in objs)
            {
                b.Add((byte)obj);
            }

            return b.ToArray();
        }
    }
}
