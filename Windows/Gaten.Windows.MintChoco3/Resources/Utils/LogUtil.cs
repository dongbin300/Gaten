using Gaten.Windows.MintChoco3.Resources.Texts;

using System;
using System.IO;

namespace Gaten.Windows.MintChoco3.Resources.Utils
{
    public class LogUtil
    {
        public static void Log(string message, string spot = "Unknown")
        {
            File.AppendAllText(
                PathCollection.MintChocoLogPath, 
                $"{DateTime.Now} [{spot}] {message}\r\n"
                );
        }
    }
}
