using Gaten.Net.GameRule.RubiksCube.v2;

namespace Gaten.GameTool.RubiksCube.AlgorithmCreatorConsole
{
    internal class Program
    {
        static RubiksCube333 beforeCube = new();
        static RubiksCube333 afterCube = new();
        static int current = 0; // 0 - Before, 1 - After

        static void Main(string[] args)
        {
            Load();
            Refresh();
            Loop();
        }

        static void Refresh()
        {
            Console.Clear();
            Console.SetCursorPosition(3, 1);
            if (current == 0)
            {
                Console.Write("*");
            }
            Console.Write("BEFORE");
            Console.SetCursorPosition(3, 12);
            if (current == 1)
            {
                Console.Write("*");
            }
            Console.Write("AFTER");
            beforeCube.Draw();
            afterCube.Draw(0, 11);
        }

        static void Loop()
        {
            while (true)
            {
                Save();
                Console.SetCursorPosition(0, 22);
                Console.Write("                             ");
                Console.SetCursorPosition(0, 22);
                Console.Write("> ");
                var command = Console.ReadLine() ?? "";

                for (int i = 23; i <= 30; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("                             ");
                }
                Console.SetCursorPosition(0, 23);

                if (command.ToLower() == "exit")
                {
                    break;
                }

                if (command.StartsWith("gen") || command.StartsWith("vgen"))
                {
                    var commands= command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var intensity = commands[0] == "gen" ? GeneratingIntensity.All : GeneratingIntensity.Valid;
                    var maxLength = commands.Length == 1 ? 8 : int.Parse(commands[1]);
                    var algorithms = AlgorithmGenerator.Generate(beforeCube, afterCube, intensity, maxLength);

                    if (algorithms == null || algorithms.Count == 0)
                    {
                        Console.WriteLine("알고리즘이 존재하지 않습니다.");
                        continue;
                    }

                    Console.WriteLine(string.Join(Environment.NewLine, algorithms));
                    continue;
                }

                if (command.StartsWith("sgen"))
                {
                    var commands= command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var algorithms = AlgorithmGenerator.Generate(beforeCube, afterCube, GeneratingIntensity.Special, int.Parse(commands[1]));

                    if (algorithms == null || algorithms.Count == 0)
                    {
                        Console.WriteLine("알고리즘이 존재하지 않습니다.");
                        continue;
                    }

                    Console.WriteLine(string.Join(Environment.NewLine, algorithms));
                    continue;
                }

                switch (command.ToLower())
                {
                    case "sw":
                        current = 1 - current;
                        Refresh();
                        break;

                    default:
                        var currentCube = current == 0 ? beforeCube : afterCube;
                        if (!currentCube.Run(command))
                        {
                            Console.WriteLine("명령어 오류");
                            break;
                        }
                        Refresh();
                        break;
                }
            }
        }

        static void Save()
        {
            File.WriteAllText("data.txt",
                string.Join("", beforeCube.Stickers.Select(x => x.GetStickerOneCode())) + Environment.NewLine +
                string.Join("", afterCube.Stickers.Select(x => x.GetStickerOneCode()))
                );
        }

        static void Load()
        {
            var data = File.ReadAllLines("data.txt");

            for (int i = 0; i < beforeCube.Stickers.Count; i++)
            {
                beforeCube.Stickers[i].SetStickerOneCode(data[0][i].ToString());
                afterCube.Stickers[i].SetStickerOneCode(data[1][i].ToString());
            }
        }
    }
}