using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Extension
{
    public static class LongExtension
    {
        public static long ReverseBytes(this long value) => (value & 0x00000000000000FFL) << 56 | (value & 0x000000000000FF00L) << 40 |
                   (value & 0x0000000000FF0000L) << 24 | (value & 0x00000000FF000000L) << 8 |
                   (value & 0x000000FF00000000L) >> 8 | (value & 0x0000FF0000000000L) >> 24 |
                   (value & 0x00FF000000000000L) >> 40 | ((long)((ulong)value & 0xFF00000000000000L)) >> 56;

        public static ulong ReverseBytes(this ulong value) => (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;

        /// <summary>
        /// 소수 목록을 얻음
        /// ex) n=10 => 2, 3, 5, 7
        /// </summary>
        /// <param name="n">n까지의 소수</param>
        /// <returns>소수 목록</returns>
        public static List<long> GetPrimeNumbers(this long n)
        {
            List<long> result = new List<long>();
            bool[] arr = new bool[n + 1];

            for (long i = 2; i <= Math.Sqrt(n); i++)
            {
                if (arr[i])
                    continue;
                for (long j = i + i; j <= n; j += i)
                    arr[j] = true;
            }
            for (long i = 2; i <= n; i++)
                if (!arr[i])
                    result.Add(i);
            return result;
        }

        /// <summary>
        /// from부터 to까지 모든 숫자를 포함하는지
        /// ex) n=1324, from=1, to=4 => true
        /// </summary>
        /// <param name="n">검사 대상 수</param>
        /// <param name="from">시작 수</param>
        /// <param name="to">끝 수</param>
        /// <returns>참/거짓</returns>
        public static bool IsPandigitalNumber(this long n, int from = 1, int to = 9)
        {
            string nStr = n.ToString();
            // 길이가 맞지 않으면
            if (nStr.Length != to - from + 1)
                return false;

            bool[] ch = new bool[10];
            foreach (char c in nStr)
                ch[int.Parse(c.ToString())] = true;

            return ch.Where(b => b == true).Count() == to - from + 1;
        }

        /// <summary>
        /// 제곱수인지 판별
        /// </summary>
        /// <param name="n">대상 수</param>
        /// <returns></returns>
        public static bool IsSquareNumber(this long n)
        {
            double sqrt = Math.Sqrt(n);

            return sqrt - (long)sqrt <= 0.0000000000001;
        }

        /// <summary>
        /// 소인수 분해해서 인수 얻기
        /// </summary>
        /// <param name="number">대상 수</param>
        /// <returns></returns>
        public static List<long> GetFactorizationList(this long number)
        {
            List<long> _primes = GetPrimeNumbers(number);
            List<long> primes = new List<long>();

            for (int n = 0; n < _primes.Count;)
            {
                long prime = _primes[n];
                if (prime * prime > number)
                    break;

                if (number % prime == 0)
                {
                    primes.Add(prime);
                    number /= prime;
                }
                else
                    n++;
            }

            if (primes.Count != 0)
                primes.Add(number);
            else
                _primes.Add(number);

            return primes;
        }

        /// <summary>
        /// 인수 병합
        /// ex) 2, 2, 3, 5, 7, 7 => 3, 4, 5, 49
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<long> MergeFactorization(this IList<long> list)
        {
            List<long> result = new List<long>();
            List<long> temp = new List<long>();

            foreach (long l in list)
            {
                if (!temp.Contains(l))
                {
                    result.Add((long)Math.Pow(l, list.Count(s => s == l)));
                    temp.Add(l);
                }
            }

            return result;
        }

        /// <summary>
        /// 가지고 있는 숫자의 개수를 반환
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<int> GetNumberCount(this long n)
        {
            List<int> counts = new List<int>();

            for (int i = 0; i <= 9; i++)
            {
                counts.Add(n.ToString().Select(c => c).Count(c => c.Equals(i.ToString()[0])));
            }

            return counts;
        }

        /// <summary>
        /// 대칭수인지 판별
        /// ex) 199272991 => true, 299912 => false
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPalindrome(this long n)
        {
            string str = n.ToString();

            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 숫자 뒤집기
        /// ex) 12893 => 39821
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Reverse(this long n)
        {
            return long.Parse(n.ToString().Reverse());
        }

        /// <summary>
        /// 자리수의 합
        /// ex) 1235 => 11
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int SumOfDigit(this long n)
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
        public static int GetDigit(this long n)
        {
            return n.ToString().Length;
        }

        public static bool IsPrime(this long number)
        {
            if (number <= 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;

            var boundary = (long)Math.Floor(Math.Sqrt(number));

            for (long i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
