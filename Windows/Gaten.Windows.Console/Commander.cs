using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Documents;
using System.Windows.Media;

namespace Gaten.Windows.Console
{
    class Commander
    {
        public static void Execute(ConsoleManager m, string input)
        {
            try
            {
                if(input.Contains(' '))
                {
                    var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Execute2(m, data);
                }
                else
                {
                    switch (input)
                    {
                        case "start":
                            break;
                        case "exit":
                            Environment.Exit(0);
                            break;

                        case "ip":
                            var str = $"내부IP: {GetInternalIp()}\r\n외부IP: {GetExternalIp()}";
                            m.Print(str);
                            break;

                        case "gaten":
                            m.BaseCamp = "Gaten.Net";
                            break;

                        case "ll":
                        case "ls":
                            var str2 = 
                                string.Join(Environment.NewLine, 
                                GetTypesInNamespace(Assembly.GetExecutingAssembly(), "Gaten.Net").Select(x=>x.ToString())
                                    );
                            m.Print(str2);
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
                    case "cd":
                        if (data[1] == "gaten")
                        {
                            m.BaseCamp = "Gaten.Net";
                        }
                        else
                        {
                            if(GetTypesInNamespace(Assembly.GetExecutingAssembly(), m.BaseCamp).Where(x=>x.ToString().Equals(data[1])).Count() > 0)
                            {
                                m.BaseCamp += "." + data[1];
                            }
                        }
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

        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }

        static string GetInternalIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        static string GetExternalIp()
        {
            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip").Trim();

            if (string.IsNullOrWhiteSpace(externalip))
            {
                externalip = GetInternalIp();
            }

            return externalip;
        }
    }
}
