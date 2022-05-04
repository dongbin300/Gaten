
using Gaten.Net.Data.Math;

namespace Gaten.Game.RuleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Stage();
                }
            }
            catch
            {

            }

        }

        static void Stage()
        {
            SmartRandom r = new SmartRandom();

            int ruleNumber = r.Next(3);

            int n1 = r.Next(2, 50);
            int n2 = r.Next(2, 50);
            int answer = Rule(n1, n2, ruleNumber);

            Console.WriteLine($"{n1} ★ {n2}");

            while (true)
            {
                Console.Write("정수 2개를 제시해 주세요.(정답을 입력하려면 숫자 앞에 !를 붙혀주세요) ");
                string[] inputs = Console.ReadLine().Split(' ');

                if (inputs.Length == 0)
                {
                    Console.WriteLine("제대로 입력하세요.");
                }
                else if (inputs.Length == 1)
                {
                    if (inputs[0].StartsWith("!"))
                    {
                        if (answer == int.Parse(inputs[0].Replace("!", "")))
                        {
                            Console.WriteLine("정답입니다.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("틀렸습니다. 다시 풀어보세요.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("제대로 입력하세요.");
                    }
                }
                else if (inputs.Length == 2)
                {
                    int i1 = int.Parse(inputs[0]);
                    int i2 = int.Parse(inputs[1]);

                    if (i1 == n1 || i1 == n2 || i2 == n1 || i2 == n2)
                    {
                        Console.WriteLine("문제와 중복되지 않는 정수를 제시해 주세요.");
                        continue;
                    }

                    Console.WriteLine(Rule(i1, i2, ruleNumber));
                }
                else
                {
                    Console.WriteLine("제대로 입력하세요.");
                }
            }
        }

        static int Rule(int n1, int n2, int ruleNumber)
        {
            switch (ruleNumber)
            {
                case 0:
                    return n1 * n1 + n2;
                case 1:
                    return n1 * 5 + n2;
                case 2:
                    return n1 * n2 + 3;
                default:
                    return 0;
            }
        }
    }
}
