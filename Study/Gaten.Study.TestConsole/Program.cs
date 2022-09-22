using DecimalMath;

using Gaten.Net.Diagnostics;
using Gaten.Net.Extensions;

using System.Numerics;

using SMath = System.Math;

namespace Gaten.Study.TestConsole
{
    public class Program
    {
        public static void Main()
        {
            GLogger.Log("Program", "Main", new Exception("test"));
        }

        public static BigInteger Sqrt(BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(SMath.Ceiling(BigInteger.Log(n, 5)));
                BigInteger root = BigInteger.One << (bitLength / 5);

                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 5;
                }

                return root;
            }

            throw new ArithmeticException("NaN");
        }

        private static bool isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root * root * root * root;
            BigInteger upperBound = (root + 1) * (root + 1) * (root + 1) * (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }
    }
}
