using System;
using System.Numerics;

namespace Gaten.Study.TestConsole
{
    public class Program
    {
        public static void Main()
        {
            int[] n = { 12, 33, 1, 2, 44 };

            
            var a  = f(30);
        }

        static BigInteger f(BigInteger n) => n == 0 ? 1 : n * f(n - 1);
    }
}
