using System;
using System.Diagnostics;
using System.IO;

namespace Gaten.NetFramework.Init
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseInfo.GetInfo();
            Console.WriteLine("CPU: " + BaseInfo.CpuName);
            Console.WriteLine("GPU: " + BaseInfo.GpuName);
            Console.WriteLine("메모리: " + BaseInfo.RamCapacity);
            Console.WriteLine("컴퓨터 이름: " + BaseInfo.ComputerName);
            Console.WriteLine("사용자 이름: " + BaseInfo.UserName);
            Console.WriteLine("OS 이름: " + BaseInfo.ProductName);
            Console.WriteLine("OS 버전: " + BaseInfo.ProductVersion);
            Console.WriteLine(".NET 7을 설치합니다... [Enter]");
            Console.ReadLine();
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "net-temp"));
            var netPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "net-temp", "net.exe");
            var batPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "net-temp", "w10pro.bat");
            File.WriteAllBytes(netPath, Properties.Resources.windowsdesktop_runtime_7_0_0_win_x64);
            File.WriteAllText(batPath, Properties.Resources.w10pro);
            Process.Start(netPath)?.WaitForExit();
            //Console.WriteLine("Windows 10 정품 인증을 진행합니다... [Enter]");
            //Console.ReadLine();
            //ProcessStartInfo psi = new ProcessStartInfo()
            //{
            //    FileName = batPath,
            //    Verb = "runas",
            //    WindowStyle = ProcessWindowStyle.Hidden,
            //    CreateNoWindow = true
            //};
            //Process.Start(psi)?.WaitForExit();

            Console.WriteLine("프로그램을 종료하려면 아무 키나 누르세요...");
            Console.ReadLine();
        }
    }
}
