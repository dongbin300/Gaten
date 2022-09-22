using Gaten.Net.Diagnostics;

using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Gaten.Windows.MintPanda.Contents
{
    internal class DiskDrive
    {
        public static string Get()
        {
            try
            {
                StringBuilder builder = new();
                var driveInfo = DriveInfo.GetDrives();

                foreach (DriveInfo di in driveInfo)
                {
                    string label = di.Name == "C:\\" ? "로컬 디스크" : di.VolumeLabel;
                    string volume = di.Name.Replace(":\\", "");
                    string availableFreeSpace = di.AvailableFreeSpace / 1_000_000_000 + "GB";
                    string usingPercent = (int)(100 - (double)di.AvailableFreeSpace / di.TotalSize * 100) + "%";

                    builder.AppendLine($"{label}({volume}) {availableFreeSpace}({usingPercent}) ");
                }

                return builder.ToString();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(DiskDrive), MethodBase.GetCurrentMethod()?.Name, ex);
                return string.Empty;
            }
        }
    }
}
