
using System.Diagnostics;

namespace Gaten.Net.Diagnostics
{
    public class GProcess
    {
        public static Process? Start(string path)
        {
            ProcessStartInfo info = new()
            {
                FileName = path,
                UseShellExecute = true
            };

            return Process.Start(info);
        }

        public static Process? Start(string path, string argument)
        {
            ProcessStartInfo info = new()
            {
                FileName = path,
                UseShellExecute = true,
                Arguments = argument
            };

            return Process.Start(info);
        }

        public static Process? Start(string path, ProcessStartInfo info)
        {
            info.FileName = path;
            info.UseShellExecute = true;
            return Process.Start(info);
        }

        public static Process? StartExe(string keyword)
        {
            return Start(IO.GResource.SmartExePath(keyword));
        }

        public static Process? StartExe(string keyword, string mainPath)
        {
            return Start(IO.GResource.SmartExePath(keyword, mainPath));
        }

        public static Process? StartInstaller(string keyword, string mainPath)
        {
            return Start(IO.GResource.SmartInstallerPath(keyword, mainPath));
        }
    }
}
