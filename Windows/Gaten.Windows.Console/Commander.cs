using Gaten.Net.Diagnostics;

using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Media;

namespace Gaten.Windows.Console
{
    class Commander
    {
        public static void Execute(ConsoleManager m, string input)
        {
            try
            {
                if(input.Contains(' ')) // parameterized command
                {
                    var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Execute2(m, data);
                }
                else
                {
                    switch (input)
                    {
                        case "exit":
                            Environment.Exit(0);
                            break;

                        case "ip":
                            m.Print($"내부IP: {ExternalTask.GetInternalIp()}\r\n외부IP: {ExternalTask.GetExternalIp()}");
                            break;

                        case "gaten":
                            m.BaseCamp = "Gaten.Net";
                            break;

                        case "ll":
                        case "ls":                                
                            m.Print(
                                string.Join(Environment.NewLine,
                                ExternalTask.GetTypesInNamespace(Assembly.GetExecutingAssembly(), "Gaten.Net").Select(x => x.ToString())
                                    ));
                            break;

                        case "time":
                            m.Print(DateTime.Now.ToString());
                            break;

                        case "now":
                            m.Print(DateTime.Now.ToShortTimeString());
                            break;

                        case "wth":
                            m.Print(ExternalTask.GetWeatherString());
                            break;

                        case "di":
                            m.Print(ExternalTask.GetDiskDriveString());
                            break;

                        case "stk":
                            m.Print(ExternalTask.GetStockPriceString());
                            break;

                        case "rh":
                            var rh = ExternalTask.GetRandomHanja();
                            m.Print(rh.Item1 + Environment.NewLine + rh.Item2);
                            break;

                        case "rw":
                            m.Print(ExternalTask.GetRandomWord());
                            break;


                        case "help":
                            m.Print(
                                "cd\r\n" +
                                "di\r\n" +
                                "dic\r\n" +
                                "exe\r\n" +
                                "exit\r\n" +
                                "gaten\r\n" +
                                "help\r\n" +
                                "ip\r\n" +
                                "ll\r\n" +
                                "ls\r\n" +
                                "now\r\n" +
                                "rh\r\n" +
                                "rn\r\n" +
                                "rw\r\n" +
                                "stk\r\n" +
                                "time\r\n" +
                                "wth\r\n"
                            );
                            break;

                        default:
                            m.Print("잘못된 명령입니다.", Brushes.Red);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                m.Print("오류: " + ex.Message, Brushes.Red);
            }
        }

        public static void Execute2(ConsoleManager m, string[] data)
        {
            try
            {
                switch (data[0])
                {
                    case "exe":
                        GProcess.StartExe(data[1]);
                        break;

                    case "cd":
                        if (data[1] == "gaten")
                        {
                            m.BaseCamp = "Gaten.Net";
                        }
                        else
                        {
                            if(ExternalTask.GetTypesInNamespace(Assembly.GetExecutingAssembly(), m.BaseCamp).Where(x => x.ToString().Equals(data[1])).Any())
                            {
                                m.BaseCamp += "." + data[1];
                            }
                        }
                        break;

                    case "dic":
                        m.Print(ExternalTask.GetDictionaryString(data[1]));
                        break;

                    case "rn":
                        var rn = ExternalTask.GetRandomNumber(int.Parse(data[1]), int.Parse(data[2]));
                        m.Print(rn);
                        break;

                    default:
                        m.Print("잘못된 명령입니다.", Brushes.Red);
                        break;
                }
            }
            catch (Exception ex)
            {
                m.Print("오류: " + ex.Message, Brushes.Red);
            }
        }
    }
}
