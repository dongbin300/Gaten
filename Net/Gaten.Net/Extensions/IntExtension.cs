using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Extensions
{
    public static class IntExtension
    {
        public static int ReverseBytes(this int value) => (value & 0x000000FF) << 24 | (value & 0x0000FF00) << 8 |
                    (value & 0x00FF0000) >> 8 | ((int)(value & 0xFF000000)) >> 24;

        public static uint ReverseBytes(this uint value) => (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;

        /// <summary>
        /// 숫자가 범위안에 포함되는지 확인
        /// </summary>
        /// <param name="x">대상</param>
        /// <param name="min">최소값</param>
        /// <param name="max">최대값</param>
        /// <returns></returns>
        public static bool IsRange(this int x, int min, int max)
        {
            return x >= min && x <= max;
        }

        /// <summary>
        /// 1100 => 1100 (digit: 1)
        /// 1100 => 1100 (digit: 2)
        /// 1100 => 10000 (digit: 3)
        /// 1100 => 10000 (digit: 4)
        /// 1100 => 100000 (digit: 5)
        /// 10011 => 100000 (digit: 4)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static uint PaddedValue(this uint value, int digit = 0) => value + ((uint)(1 << digit) - value & (uint)((1 << digit) - 1) & (uint)((1 << digit) - 1));

        /// <summary>
        /// 1100 => 1000 (digit: 3)
        /// 10011 => 1010 (digit: 1)
        /// 10011 => 1010 (digit: 2)
        /// 10011 => 1100 (digit: 3)
        /// 10011 => 10000 (digit: 4)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static uint UnpaddedValue(this uint value, int digit = 0) => PaddedValue(value, digit) >> 1;

        /// <summary>
        /// 소수 목록을 얻음
        /// ex) n=10 => 2, 3, 5, 7
        /// </summary>
        /// <param name="n">n까지의 소수</param>
        /// <returns>소수 목록</returns>
        public static List<int> GetPrimeNumbers(this int n)
        {
            List<int> result = new List<int>();
            bool[] arr = new bool[n + 1];

            for (int i = 2; i <= System.Math.Sqrt(n); i++)
            {
                if (arr[i])
                    continue;
                for (int j = i + i; j <= n; j += i)
                    arr[j] = true;
            }

            for (int i = 2; i <= n; i++)
                if (!arr[i])
                    result.Add(i);

            return result;
        }

        /// <summary>
        /// 순환 수 목록을 얻음
        /// ex) n=198 => 198, 981, 819
        /// </summary>
        /// <param name="n">대상 수</param>
        /// <returns>순환 수 목록</returns>
        public static List<int> GetCircularNumbers(this int n)
        {
            List<int> result = new List<int>();
            string nStr = n.ToString();

            result.Add(n);
            for (int i = 1; i < nStr.Length; i++)
            {
                int t = int.Parse(nStr.ShiftRight(i));
                if (!result.Contains(t))
                    result.Add(t);
            }

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
        public static bool IsPandigitalNumber(this int n, int from = 1, int to = 9)
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
        public static bool IsSquareNumber(this int n)
        {
            double sqrt = System.Math.Sqrt(n);

            return sqrt - (int)sqrt <= 0.0000000000001;
        }

        /// <summary>
        /// 중복되는 자리수가 있는 수인지 판별
        /// ex) 7381 => false, 9982 => true, 98234 => false
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsDuplicateNumber(this int n)
        {
            string s = n.ToString();
            return s.GroupBy(c => c)
                .Where(c => c.Count() > 1)
                .FirstOrDefault() != null;
        }

        /// <summary>
        /// 가지고 있는 숫자의 요소가 같은지 판별
        /// ex) 1234, 4213 => true, 1233, 3331 => false
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static bool IsSameHaveNumber(this int n1, int n2)
        {
            var a = n1.ToString().Select(c => c).Distinct().OrderBy(c => c);
            var b = n2.ToString().Select(c => c).Distinct().OrderBy(c => c);

            return a.SequenceEqual(b);
        }

        /// <summary>
        /// 가지고 있는 숫자의 요소와 개수가 모두 같은지 판별
        /// ex) 1234, 4213 => true, 1233, 3221 => false
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static bool IsExactHaveNumber(this int n1, int n2)
        {
            var a = n1.ToString().Select(c => c).OrderBy(c => c);
            var b = n2.ToString().Select(c => c).OrderBy(c => c);

            return a.SequenceEqual(b);
        }

        /// <summary>
        /// 가장 많이 존재하는 숫자를 반환
        /// ex) 71773241 => 7, 12345 => 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int MostNumber(this int n)
        {
            int[] chars = new int[10];
            string str = n.ToString();
            foreach (char c in str)
            {
                chars[c - '0']++;
            }

            return chars.ToList().IndexOf(chars.Max());
        }

        /// <summary>
        /// 숫자의 개수를 반환
        /// ex) 112348, 1 => 2, 92837444,4 => 3
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int CountNumber(this int n, int a)
        {
            return n.ToString().Select(c => c).Count(c => c.ToString().Equals(a.ToString()));
        }

        public static long Factorial(this int n)
        {
            long result = 1;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        /// <summary>
        /// 순열 nPr의 경우의 수
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static long Permutation(this int n, int k)
        {
            long result = 1;

            for (int i = 0; i < k; i++)
            {
                result *= n - i;
            }

            return result;
        }

        /// <summary>
        /// 조합 nCr의 경우의 수
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static long Combination(this int n, int r)
        {
            return Permutation(n, r) / Factorial(r);
        }

        public static bool IsPrime(this int number)
        {
            if (number <= 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;

            var boundary = (int)System.Math.Floor(System.Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// 최대 공약수
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int GetGCD(this int m, int n)
        {
            return n == 0 ? m : GetGCD(n, m % n);
        }

        public static bool IsPowerOf2(this int x)
        {
            if (x <= 0)
            {
                return false;
            }

            return (x & (x - 1)) == 0;
        }
    }
}
