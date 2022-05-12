using System.Text;

namespace Gaten.Windows.MintMonitor
{
    internal class DiskDrive
    {
        public static string Get()
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                var driveInfo = DriveInfo.GetDrives();

                foreach (DriveInfo di in driveInfo)
                {
                    string label = di.Name == "C:\\" ? "로컬 디스크" : di.VolumeLabel;
                    string volume = di.Name.Replace(":\\", "");
                    //string ready = di.IsReady ? "ON" : "OFF";
                    string availableFreeSpace = di.AvailableFreeSpace / 1_000_000_000 + "GB";
                    string usingPercent = (int)(100 - (double)di.AvailableFreeSpace / di.TotalSize * 100) + "%";

                    builder.AppendLine($"{label}({volume}) {availableFreeSpace}({usingPercent})");
                }

                return builder.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
