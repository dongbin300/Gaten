using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Media;

namespace Gaten.Windows.Console
{
    class Commander
    {
        public static void Execute(ConsoleManager m, string input)
        {
            try
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
