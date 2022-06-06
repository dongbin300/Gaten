using System;
using System.Linq;
using System.Management;

namespace Gaten.Windows.WindowsManager
{
    internal class BaseInfo
    {
        public static bool Is64 => Environment.Is64BitOperatingSystem;
        public static string WindowsBit => Is64 ? "x64" : "x86";
        public static string ComputerName => Environment.MachineName;
        public static bool IsWindowsAuth => string.IsNullOrEmpty(SerialNumber);

        public static string ProductName;
        public static string ProductVersion;
        public static string SerialNumber;
        public static string CpuName;
        public static string CpuCore;
        public static string CpuThread;
        public static string CpuSpeed;
        public static string RamCapacity;
        public static string GpuName;
        public static string GpuRam;

        public static void GetInfo()
        {
            try
            {
                var windows = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().Cast<ManagementObject>().First();
                ProductName = (string)windows["Caption"];
                ProductVersion = (string)windows["Version"];
                SerialNumber = (string)windows["SerialNumber"];
                windows.Dispose();

                var cpu = new ManagementObjectSearcher("SELECT * FROM Win32_Processor").Get().Cast<ManagementObject>().First();
                CpuName = ((string)cpu["Name"]).Trim();
                CpuCore = string.Format("{0}Cores", cpu["NumberOfCores"]);
                CpuThread = string.Format("{0}Threads", cpu["NumberOfLogicalProcessors"]);
                CpuSpeed = string.Format("{0:0.00}GHz", (uint)cpu["MaxClockSpeed"] / (double)1000);
                cpu.Dispose();

                var ram = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().Cast<ManagementObject>().First();
                RamCapacity = string.Format("{0}GB", Math.Round((double)(long.Parse(ram["TotalVisibleMemorySize"].ToString()) / (double)1024 / 1024)));
                ram.Dispose();

                var gpu = new ManagementObjectSearcher("select * from Win32_VideoController").Get().Cast<ManagementObject>().First();
                GpuName = gpu["Name"].ToString();
                GpuRam = string.Format("{0}GB", Math.Round((double)(long.Parse(gpu["AdapterRAM"].ToString()) / (double)1024 / 1024 / 1024)));
                gpu.Dispose();
            }
            catch
            {

            }
        }
    }
}
