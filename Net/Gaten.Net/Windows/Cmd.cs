using System.Diagnostics;

namespace Gaten.Net.Windows
{
    public class Cmd
    {
        /// <summary>
        /// Cmd 명령어를 실행한다.<br/>
        /// 관리자 권한이 필요한 명령은 프로젝트/app.manifest에서 관리자 권한을 설정해준다.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string Run(string command)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {command}",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                },
                EnableRaisingEvents = false
            };
            process.Start();
            var result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return result;
        }
    }
}
