using System.Diagnostics;

namespace Gaten.Net.Data
{
    public class Process
    {
        public static System.Diagnostics.Process? Start(string path)
        {
            ProcessStartInfo psi = new()
            {
                FileName = path,
                UseShellExecute = true
            };

            return System.Diagnostics.Process.Start(psi);
        }
    }
}
