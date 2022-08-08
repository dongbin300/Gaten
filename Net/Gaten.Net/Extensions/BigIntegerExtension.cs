using System.Numerics;

namespace Gaten.Net.Extensions
{
    public static class BigIntegerExtension
    {
        public static BigInteger Sqrt(this BigInteger n)
        {
            if (n == 0)
                return 0;

            if (n > 0)
            {
                int bitLength = Convert.ToInt32(System.Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!IsSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException("NaN");
        }

        private static bool IsSqrt(this BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }

        /// <summary>
        /// 자리수의 합
        /// ex) 1235 => 11
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int SumOfDigit(this BigInteger n)
        {
            int sum = 0;
            foreach (char c in n.ToString())
            {
                sum += int.Parse(c.ToString());
            }

            return sum;
        }

        /// <summary>
        /// 자리수 반환
        /// ex) 12384 => 5, 277 => 3
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int GetDigit(this BigInteger n)
        {
            return n.ToString().Length;
        }

        public static BigInteger IntegerSquareRoot(this BigInteger value)
        {
            if (value > 0)
            {
                int bitLength = value.ToByteArray().Length * 8;
                BigInteger root = BigInteger.One << (bitLength / 2);
                while (!IsSquareRoot(value, root))
                {
                    root += value / root;
                    root /= 2;
                }
                return root;
            }
            else
                return 0;
        }

        public static bool IsSquareRoot(this BigInteger n, BigInteger root)
        {
            return n >= root * root && n < (root + 1) * (root + 1);
        }

        public static bool IsPrime(this BigInteger value)
        {
            if (value < 3)
            {
                if (value == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (value % 2 == 0)
                {
                    return false;
                }
                else if (value == 5)
                {
                    return true;
                }
                else if (value % 5 == 0)
                {
                    return false;
                }
                else
                {
                    // The only way this number is a prime number at this point is if it is divisible by numbers ending with 1, 3, 7, and 9.
                    AutoResetEvent success = new(false);
                    AutoResetEvent failure = new(false);
                    AutoResetEvent onesSucceeded = new(false);
                    AutoResetEvent threesSucceeded = new(false);
                    AutoResetEvent sevensSucceeded = new(false);
                    AutoResetEvent ninesSucceeded = new(false);
                    BigInteger squareRootedValue = IntegerSquareRoot(value);
                    Thread ones = new(() =>
                    {
                        for (BigInteger i = 11; i <= squareRootedValue; i += 10)
                        {
                            if (value % i == 0)
                            {
                                failure.Set();
                            }
                        }
                        onesSucceeded.Set();
                    });
                    ones.Start();
                    Thread threes = new(() =>
                    {
                        for (BigInteger i = 3; i <= squareRootedValue; i += 10)
                        {
                            if (value % i == 0)
                            {
                                failure.Set();
                            }
                        }
                        threesSucceeded.Set();
                    });
                    threes.Start();
                    Thread sevens = new(() =>
                    {
                        for (BigInteger i = 7; i <= squareRootedValue; i += 10)
                        {
                            if (value % i == 0)
                            {
                                failure.Set();
                            }
                        }
                        sevensSucceeded.Set();
                    });
                    sevens.Start();
                    Thread nines = new(() =>
                    {
                        for (BigInteger i = 9; i <= squareRootedValue; i += 10)
                        {
                            if (value % i == 0)
                            {
                                failure.Set();
                            }
                        }
                        ninesSucceeded.Set();
                    });
                    nines.Start();
                    Thread successWaiter = new(() =>
                    {
                        WaitHandle.WaitAll(new WaitHandle[] { onesSucceeded, threesSucceeded, sevensSucceeded, ninesSucceeded });
                        success.Set();
                    });
                    successWaiter.Start();
                    int result = WaitHandle.WaitAny(new WaitHandle[] { success, failure });
                    try
                    {
                        successWaiter.Join();
                    }
                    catch { }
                    try
                    {
                        ones.Join();
                    }
                    catch { }
                    try
                    {
                        threes.Join();
                    }
                    catch { }
                    try
                    {
                        sevens.Join();
                    }
                    catch { }
                    try
                    {
                        nines.Join();
                    }
                    catch { }
                    if (result == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
    }
}
