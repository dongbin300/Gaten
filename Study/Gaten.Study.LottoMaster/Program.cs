using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LottoMaster
{
    class Program
    {
        const int currentLottoStage = 866;

        static void Main(string[] args)
        {
            // 번호 리스트 생성하고 경우의수 구하기
            NumberList list = new NumberList();
            list.SetList();
            //Pattern allPattern = Analyze(list.numbers);

            // 현재까지의 당첨번호 불러와서 분석
            //List<LottoNumber> lottoHitNumbers = GetLottoNumber();
            //Pattern hitPattern = Analyze(lottoHitNumbers);

            // 분석 결과 출력
            /*Console.WriteLine($"6개 연속: {hitPattern.Seq6} / {allPattern.Seq6} ({(double)hitPattern.Seq6 / allPattern.Seq6 * 100}%)");
            Console.WriteLine($"5개 연속: {hitPattern.Seq5} / {allPattern.Seq5} ({(double)hitPattern.Seq5 / allPattern.Seq5 * 100}%)");
            Console.WriteLine($"4개 연속: {hitPattern.Seq4} / {allPattern.Seq4} ({(double)hitPattern.Seq4 / allPattern.Seq4 * 100}%)");
            Console.WriteLine($"3개 연속(2쌍): {hitPattern.Seq3_2} / {allPattern.Seq3_2} ({(double)hitPattern.Seq3_2 / allPattern.Seq3_2 * 100}%)");
            Console.WriteLine($"3개 연속(1쌍): {hitPattern.Seq3_1} / {allPattern.Seq3_1} ({(double)hitPattern.Seq3_1 / allPattern.Seq3_1 * 100}%)");
            Console.WriteLine($"2개 연속(3쌍): {hitPattern.Seq2_3} / {allPattern.Seq2_3} ({(double)hitPattern.Seq2_3 / allPattern.Seq2_3 * 100}%)");
            Console.WriteLine($"2개 연속(2쌍): {hitPattern.Seq2_2} / {allPattern.Seq2_2} ({(double)hitPattern.Seq2_2 / allPattern.Seq2_2 * 100}%)");
            Console.WriteLine($"2개 연속(1쌍): {hitPattern.Seq2_1} / {allPattern.Seq2_1} ({(double)hitPattern.Seq2_1 / allPattern.Seq2_1 * 100}%)");
            Console.WriteLine();
            Console.WriteLine($"같은 색깔 6개: {hitPattern.Color6} / {allPattern.Color6} ({(double)hitPattern.Color6 / allPattern.Color6 * 100}%)");
            Console.WriteLine($"같은 색깔 5개: {hitPattern.Color5} / {allPattern.Color5} ({(double)hitPattern.Color5 / allPattern.Color5 * 100}%)");
            Console.WriteLine($"같은 색깔 4개, 2개: {hitPattern.Color4_2} / {allPattern.Color4_2} ({(double)hitPattern.Color4_2 / allPattern.Color4_2 * 100}%)");
            Console.WriteLine($"같은 색깔 4개, 1개, 1개: {hitPattern.Color4_1_1} / {allPattern.Color4_1_1} ({(double)hitPattern.Color4_1_1 / allPattern.Color4_1_1 * 100}%)");
            Console.WriteLine($"같은 색깔 3개, 3개: {hitPattern.Color3_3} / {allPattern.Color3_3} ({(double)hitPattern.Color3_3 / allPattern.Color3_3 * 100}%)");
            Console.WriteLine($"같은 색깔 3개, 2개, 1개: {hitPattern.Color3_2_1} / {allPattern.Color3_2_1} ({(double)hitPattern.Color3_2_1 / allPattern.Color3_2_1 * 100}%)");
            Console.WriteLine($"같은 색깔 3개, 1개, 1개, 1개: {hitPattern.Color3_1_1_1} / {allPattern.Color3_1_1_1} ({(double)hitPattern.Color3_1_1_1 / allPattern.Color3_1_1_1 * 100}%)");
            Console.WriteLine();
            Console.WriteLine($"41~45 5개: {hitPattern.Color40_5} / {allPattern.Color40_5} ({(double)hitPattern.Color40_5 / allPattern.Color40_5 * 100}%)");
            Console.WriteLine($"41~45 4개: {hitPattern.Color40_4} / {allPattern.Color40_4} ({(double)hitPattern.Color40_4 / allPattern.Color40_4 * 100}%)");
            Console.WriteLine($"41~45 3개: {hitPattern.Color40_3} / {allPattern.Color40_3} ({(double)hitPattern.Color40_3 / allPattern.Color40_3 * 100}%)");
            Console.WriteLine($"41~45 2개: {hitPattern.Color40_2} / {allPattern.Color40_2} ({(double)hitPattern.Color40_2 / allPattern.Color40_2 * 100}%)");
            Console.WriteLine($"41~45 1개: {hitPattern.Color40_1} / {allPattern.Color40_1} ({(double)hitPattern.Color40_1 / allPattern.Color40_1 * 100}%)");
            Console.WriteLine($"41~45 0개: {hitPattern.Color40_0} / {allPattern.Color40_0} ({(double)hitPattern.Color40_0 / allPattern.Color40_0 * 100}%)");
            Console.WriteLine();
            Console.WriteLine($"홀수 0개: {hitPattern.Odd0} / {allPattern.Odd0} ({(double)hitPattern.Odd0 / allPattern.Odd0 * 100}%)");
            Console.WriteLine($"홀수 1개: {hitPattern.Odd1} / {allPattern.Odd1} ({(double)hitPattern.Odd1 / allPattern.Odd1 * 100}%)");
            Console.WriteLine($"홀수 2개: {hitPattern.Odd2} / {allPattern.Odd2} ({(double)hitPattern.Odd2 / allPattern.Odd2 * 100}%)");
            Console.WriteLine($"홀수 3개: {hitPattern.Odd3} / {allPattern.Odd3} ({(double)hitPattern.Odd3 / allPattern.Odd3 * 100}%)");
            Console.WriteLine($"홀수 4개: {hitPattern.Odd4} / {allPattern.Odd4} ({(double)hitPattern.Odd4 / allPattern.Odd4 * 100}%)");
            Console.WriteLine($"홀수 5개: {hitPattern.Odd5} / {allPattern.Odd5} ({(double)hitPattern.Odd5 / allPattern.Odd5 * 100}%)");
            Console.WriteLine($"홀수 6개: {hitPattern.Odd6} / {allPattern.Odd6} ({(double)hitPattern.Odd6 / allPattern.Odd6 * 100}%)");
            Console.WriteLine();*/

            // 필터링
            // 1. 당첨번호 지우기
            // 2. 연속된 숫자 지우기
            // 2-1. 연속4개,5개,6개 숫자 지우기
            // 2-2. 연속2개 3쌍, 3개 2쌍 숫자 지우기
            // 3. 구간별(1~10, 11~20, ...) 많은 숫자 지우기
            // 3-1. 1~10, 11~20, 21~30, 31~40 구간 4개이상 지우기
            // 3-2. 41~45 구간 3개이상 지우기
            list = Filter(list);

            // 유효 리스트 출력
            //list.Print();
        }

        static Pattern Analyze(List<LottoNumber> hitNumbers)
        {
            Pattern p = new Pattern();

            foreach (LottoNumber ln in hitNumbers)
            {
                #region 연속된 번호 분석
                if (IsSequence(ln.numbers[0], ln.numbers[1], ln.numbers[2], ln.numbers[3], ln.numbers[4], ln.numbers[5]))
                {
                    p.Seq6++;
                }
                else if (IsSequence(ln.numbers[0], ln.numbers[1], ln.numbers[2], ln.numbers[3], ln.numbers[4]) ||
                    IsSequence(ln.numbers[1], ln.numbers[2], ln.numbers[3], ln.numbers[4], ln.numbers[5]))
                {
                    p.Seq5++;
                }
                else if (IsSequence(ln.numbers[0], ln.numbers[1], ln.numbers[2], ln.numbers[3]) ||
                    IsSequence(ln.numbers[1], ln.numbers[2], ln.numbers[3], ln.numbers[4]) ||
                    IsSequence(ln.numbers[2], ln.numbers[3], ln.numbers[4], ln.numbers[5]))
                {
                    p.Seq4++;
                }
                else if (IsSequence(ln.numbers[0], ln.numbers[1], ln.numbers[2]) && IsSequence(ln.numbers[3], ln.numbers[4], ln.numbers[5]))
                {
                    p.Seq3_2++;
                }
                else if (IsSequence(ln.numbers[0], ln.numbers[1], ln.numbers[2]) ||
                    IsSequence(ln.numbers[1], ln.numbers[2], ln.numbers[3]) ||
                    IsSequence(ln.numbers[2], ln.numbers[3], ln.numbers[4]) ||
                    IsSequence(ln.numbers[3], ln.numbers[4], ln.numbers[5]))
                {
                    p.Seq3_1++;
                }
                else if (IsSequence(ln.numbers[0], ln.numbers[1]) && IsSequence(ln.numbers[2], ln.numbers[3]) && IsSequence(ln.numbers[4], ln.numbers[5]))
                {
                    p.Seq2_3++;
                }
                else if (IsSequence(ln.numbers[0], ln.numbers[1]) && IsSequence(ln.numbers[2], ln.numbers[3]) ||
                    IsSequence(ln.numbers[0], ln.numbers[1]) && IsSequence(ln.numbers[3], ln.numbers[4]) ||
                    IsSequence(ln.numbers[0], ln.numbers[1]) && IsSequence(ln.numbers[4], ln.numbers[5]) ||
                    IsSequence(ln.numbers[1], ln.numbers[2]) && IsSequence(ln.numbers[3], ln.numbers[4]) ||
                    IsSequence(ln.numbers[1], ln.numbers[2]) && IsSequence(ln.numbers[4], ln.numbers[5]) ||
                    IsSequence(ln.numbers[2], ln.numbers[3]) && IsSequence(ln.numbers[4], ln.numbers[5]))
                {
                    p.Seq2_2++;
                }
                else if (IsSequence(ln.numbers[0], ln.numbers[1]) ||
                    IsSequence(ln.numbers[1], ln.numbers[2]) ||
                    IsSequence(ln.numbers[2], ln.numbers[3]) ||
                    IsSequence(ln.numbers[3], ln.numbers[4]) ||
                    IsSequence(ln.numbers[4], ln.numbers[5]))
                {
                    p.Seq2_1++;
                }
                #endregion

                #region 구간별 번호 분석
                int[] count = new int[5];
                int oddCount = 0;
                foreach (int num in ln.numbers)
                {
                    count[(num - 1) / 10]++;
                    if (num % 2 == 1) oddCount++;
                }
                switch (count.Max())
                {
                    case 6:
                        p.Color6++;
                        break;
                    case 5:
                        p.Color5++;
                        break;
                    case 4:
                        if (count.Where(val => val != 4).Max() == 2)
                            p.Color4_2++;
                        else
                            p.Color4_1_1++;
                        break;
                    case 3:
                        if (count.Where(val => val == 3).Count() == 2)
                            p.Color3_3++;
                        else if (count.Where(val => val != 3).Max() == 2)
                            p.Color3_2_1++;
                        else
                            p.Color3_1_1_1++;
                        break;
                }
                #endregion

                #region 41~45 번호 분석
                switch (count[4])
                {
                    case 5: p.Color40_5++; break;
                    case 4: p.Color40_4++; break;
                    case 3: p.Color40_3++; break;
                    case 2: p.Color40_2++; break;
                    case 1: p.Color40_1++; break;
                    case 0: p.Color40_0++; break;
                }
                #endregion

                #region 홀수 번호 분석
                switch (oddCount)
                {
                    case 0: p.Odd0++; break;
                    case 1: p.Odd1++; break;
                    case 2: p.Odd2++; break;
                    case 3: p.Odd3++; break;
                    case 4: p.Odd4++; break;
                    case 5: p.Odd5++; break;
                    case 6: p.Odd6++; break;
                }
                #endregion
            }

            Console.WriteLine("분석 완료.");
            return p;
        }

        static bool IsSequence(int n1, int n2)
        {
            return Math.Abs(n1 - n2) == 1 ? true : false;
        }

        static bool IsSequence(int n1, int n2, int n3)
        {
            return IsSequence(n1, n2) && IsSequence(n2, n3) ? true : false;
        }

        static bool IsSequence(int n1, int n2, int n3, int n4)
        {
            return IsSequence(n1, n2, n3) && IsSequence(n3, n4) ? true : false;
        }

        static bool IsSequence(int n1, int n2, int n3, int n4, int n5)
        {
            return IsSequence(n1, n2, n3, n4) && IsSequence(n4, n5) ? true : false;
        }

        static bool IsSequence(int n1, int n2, int n3, int n4, int n5, int n6)
        {
            return IsSequence(n1, n2, n3, n4, n5) && IsSequence(n5, n6) ? true : false;
        }

        static List<LottoNumber> GetLottoNumber()
        {
            List<LottoNumber> lottoNumbers = new List<LottoNumber>();
            using (FileStream fs = new FileStream("로또번호.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    while (sr.Peek() >= 0)
                    {
                        string[] str = sr.ReadLine().Split(' ');
                        List<int> numbers = new List<int>();
                        for (int i = 1; i <= 6; i++)
                            numbers.Add(int.Parse(str[i]));
                        lottoNumbers.Add(new LottoNumber(numbers));
                    }
                }
            }
            return lottoNumbers;
        }

        static NumberList Filter(NumberList list)
        {
            NumberList resultList = new NumberList();
            foreach (LottoNumber ln in list.numbers)
            {
                // 연속 6, 5, 3_2 필터링
                if (IsSequence(ln.numbers[0], ln.numbers[1], ln.numbers[2], ln.numbers[3], ln.numbers[4], ln.numbers[5]))
                    continue;
                else if (IsSequence(ln.numbers[0], ln.numbers[1], ln.numbers[2], ln.numbers[3], ln.numbers[4]) ||
                IsSequence(ln.numbers[1], ln.numbers[2], ln.numbers[3], ln.numbers[4], ln.numbers[5]))
                    continue;
                else if (IsSequence(ln.numbers[0], ln.numbers[1], ln.numbers[2]) && IsSequence(ln.numbers[3], ln.numbers[4], ln.numbers[5]))
                    continue;

                // 같은색깔 6, 5, 4_1_1, 3,3 필터링
                bool _continue = false;
                int[] count = new int[5];
                int oddCount = 0;
                foreach (int num in ln.numbers)
                {
                    count[(num - 1) / 10]++;
                    if (num % 2 == 1) oddCount++;
                }
                switch (count.Max())
                {
                    case 6:
                        _continue = true;
                        break;
                    case 5:
                        _continue = true;
                        break;
                    case 4:
                        if (count.Where(val => val != 4).Max() == 2) // 4_2
                        { }
                        else // 4_1_1
                            _continue = true;
                        break;
                    case 3:
                        if (count.Where(val => val == 3).Count() == 2) // 3_3
                            _continue = true;
                        else if (count.Where(val => val != 3).Max() == 2) // 3_2_1
                        { }
                        else // 3_1_1_1
                        { }
                        break;
                }
                if (_continue)
                    continue;

                // 41~45 5, 4 필터링
                switch (count[4])
                {
                    case 5: _continue = true; break;
                    case 4: _continue = true; break;
                    case 3: break;
                    case 2: break;
                    case 1: break;
                    case 0: break;
                }
                if (_continue)
                    continue;

                // 홀수 1, 5 필터링
                switch (oddCount)
                {
                    case 0: break;
                    case 1: _continue = true; break;
                    case 2: break;
                    case 3: break;
                    case 4: break;
                    case 5: _continue = true; break;
                    case 6: break;
                }
                if (_continue)
                    continue;

                resultList.numbers.Add(ln);
            }
            Console.WriteLine($"필터링 완료. 8145060->{resultList.numbers.Count}");
            return resultList;
        }
    }

    class Pattern
    {
        public int Seq6 = 0;
        public int Seq5 = 0;
        public int Seq4 = 0;
        public int Seq3_1 = 0;
        public int Seq3_2 = 0;
        public int Seq2_1 = 0;
        public int Seq2_2 = 0;
        public int Seq2_3 = 0;
        public int Color6 = 0;
        public int Color5 = 0;
        public int Color4_2 = 0;
        public int Color4_1_1 = 0;
        public int Color3_3 = 0;
        public int Color3_2_1 = 0;
        public int Color3_1_1_1 = 0;
        public int Color40_5 = 0;
        public int Color40_4 = 0;
        public int Color40_3 = 0;
        public int Color40_2 = 0;
        public int Color40_1 = 0;
        public int Color40_0 = 0;
        public int Odd0 = 0;
        public int Odd1 = 0;
        public int Odd2 = 0;
        public int Odd3 = 0;
        public int Odd4 = 0;
        public int Odd5 = 0;
        public int Odd6 = 0;

        public Pattern() { }

        public void Print()
        {
            Console.WriteLine($"6개 연속: {Seq6}");
            Console.WriteLine($"5개 연속: {Seq5}");
            Console.WriteLine($"4개 연속: {Seq4}");
            Console.WriteLine($"3개 연속(2쌍): {Seq3_2}");
            Console.WriteLine($"3개 연속(1쌍): {Seq3_1}");
            Console.WriteLine($"2개 연속(3쌍): {Seq2_3}");
            Console.WriteLine($"2개 연속(2쌍): {Seq2_2}");
            Console.WriteLine($"2개 연속(1쌍): {Seq2_1}");
            Console.WriteLine();
            Console.WriteLine($"같은 색깔 6개: {Color6}");
            Console.WriteLine($"같은 색깔 5개: {Color5}");
            Console.WriteLine($"같은 색깔 4개, 2개: {Color4_2}");
            Console.WriteLine($"같은 색깔 4개, 1개, 1개: {Color4_1_1}");
            Console.WriteLine($"같은 색깔 3개, 3개: {Color3_3}");
            Console.WriteLine($"같은 색깔 3개, 2개, 1개: {Color3_2_1}");
            Console.WriteLine($"같은 색깔 3개, 1개, 1개, 1개: {Color3_1_1_1}");
            Console.WriteLine();
            Console.WriteLine($"41~45 5개: {Color40_5}");
            Console.WriteLine($"41~45 4개: {Color40_4}");
            Console.WriteLine($"41~45 3개: {Color40_3}");
            Console.WriteLine($"41~45 2개: {Color40_2}");
            Console.WriteLine($"41~45 1개: {Color40_1}");
            Console.WriteLine($"41~45 0개: {Color40_0}");
            Console.WriteLine();
            Console.WriteLine($"홀수 0개: {Odd0}");
            Console.WriteLine($"홀수 1개: {Odd1}");
            Console.WriteLine($"홀수 2개: {Odd2}");
            Console.WriteLine($"홀수 3개: {Odd3}");
            Console.WriteLine($"홀수 4개: {Odd4}");
            Console.WriteLine($"홀수 5개: {Odd5}");
            Console.WriteLine($"홀수 6개: {Odd6}");
        }
    }

    // 보너스 제외
    class LottoNumber
    {
        public List<int> numbers;

        public LottoNumber(List<int> numbers)
        {
            this.numbers = numbers;
        }
    }

    class NumberList
    {
        public List<LottoNumber> numbers = new List<LottoNumber>();

        public NumberList()
        {

        }

        public void SetList()
        {
            for (int i = 1; i <= 45 - 5; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{(int)((double)i / 40 * 100)}%");
                for (int j = i + 1; j <= 45 - 4; j++)
                {
                    for (int k = j + 1; k <= 45 - 3; k++)
                    {
                        for (int l = k + 1; l <= 45 - 2; l++)
                        {
                            for (int m = l + 1; m <= 45 - 1; m++)
                            {
                                for (int n = m + 1; n <= 45; n++)
                                {
                                    numbers.Add(new LottoNumber(new List<int>() { i, j, k, l, m, n }));
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("번호 리스트 생성 완료.");
        }

        public void Print()
        {
            foreach (LottoNumber number in numbers)
            {
                foreach (int num in number.numbers)
                    Console.Write(num + " ");
                Console.WriteLine();
            }
            Console.WriteLine($"===총 {numbers.Count}개의 번호 리스트 출력.");
        }
    }
}
