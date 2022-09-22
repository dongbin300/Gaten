using Gaten.Net.IO;

namespace Gaten.Net.Diagnostics
{
    public class GLogger
    {
        private static string LogFolderPath => Environment.CurrentDirectory.Down("Logs");
        private static string LogFilePath => LogFolderPath.Down($"log_{DateTime.Now:yyyy-MM-dd}.txt");

        public static void Log(string? className, string? methodName, Exception e)
        {
            GPath.TryCreateDirectory(LogFolderPath);
            GFile.TryCreate(LogFilePath);
            GFile.AppendLine(LogFilePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{className}.{methodName}] {e}");
        }
    }
}
