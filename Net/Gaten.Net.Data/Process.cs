using System.Diagnostics;

namespace Gaten.Net.Data
{
    public class Process
    {
        public static System.Diagnostics.Process? Start(string path)
        {
            ProcessStartInfo info = new()
            {
                FileName = path,
                UseShellExecute = true
            };

            return System.Diagnostics.Process.Start(info);
        }

        public static System.Diagnostics.Process? Start(string path, ProcessStartInfo info)
        {
            info.FileName = path;
            info.UseShellExecute = true;
            return System.Diagnostics.Process.Start(info);
        }
    }
}
