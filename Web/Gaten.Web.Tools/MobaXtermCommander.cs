using System.Diagnostics;

namespace Gaten.Web.Tools
{
    public class MobaXtermCommander
    {
        public MobaXtermCommander()
        {
        }

        public static void Init()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "Resources/MobaXterm_Personal_22.3.exe",
                    Arguments = "-bookmark NAS",
                    //WindowStyle = ProcessWindowStyle.Hidden,
                    //CreateNoWindow = true,
                    //UseShellExecute = false,
                    //RedirectStandardInput = true,
                    //RedirectStandardOutput = true,
                    //RedirectStandardError = true
                },
                EnableRaisingEvents = false
            };
            process.Start();
            process.WaitForExit();
            var result = process.StandardOutput.ReadToEnd();


        }

        public static void Run(string command)
        {
            var result = Process.Start("Resources/MobaXterm_Personal_22.3.exe", $"-exec {command}");
        }
    }
}
