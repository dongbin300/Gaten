
using System.Diagnostics;

namespace Gaten.Net.Data.Diagnostics
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

        public static Process? Start(string path, ProcessStartInfo info)
        {
            info.FileName = path;
            info.UseShellExecute = true;
            return Process.Start(info);
        }

        public static Process? StartLocalExe(string keyword)
        {
            return Start(IO.GResource.SmartExePath(keyword));
        }
    }
}
