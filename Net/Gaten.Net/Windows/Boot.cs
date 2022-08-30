using Microsoft.Win32;

using System.Runtime.Versioning;

namespace Gaten.Net.Windows
{
    [SupportedOSPlatform("windows")]
    public class Boot
    {
        private static readonly string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// 시작 프로그램 등록
        /// </summary>
        /// <param name="programName">"Program Name"</param>
        /// <param name="exePath">Environment.ProcessPath</param>
        public static void RegisterStartProgram(string programName, string exePath)
        {
            try
            {
                var key = Registry.LocalMachine.OpenSubKey(RunKey);
                if (key == null)
                {
                    return;
                }
                if (key.GetValue(programName) != null)
                {
                    return;
                }

                key.Close();
                key = Registry.LocalMachine.OpenSubKey(RunKey, true);
                if (key == null)
                {
                    return;
                }

                key.SetValue(programName, exePath);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 시작 프로그램 등록취소
        /// </summary>
        /// <param name="programName">"Program Name"</param>
        public static void UnregisterStartProgram(string programName)
        {
            try
            {
                var key = Registry.LocalMachine.OpenSubKey(RunKey, true);
                if (key == null)
                {
                    return;
                }

                key.DeleteValue(programName);
            }
            catch
            {
                throw;
            }
        }
    }
}
