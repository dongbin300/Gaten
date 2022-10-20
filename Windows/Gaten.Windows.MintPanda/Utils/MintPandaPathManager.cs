using Gaten.Net.Diagnostics;
using Gaten.Net.IO;
using Gaten.Net.Wpf.Controls;

using System;

using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace Gaten.Windows.MintPanda.Utils
{
    public class MintPandaPathManager
    {
        public readonly static string MainDrivePath = @"C:\";
        public readonly static string SubDrivePath = @"D:\";
        public static string ResourcePath => GResource.BaseFilePath;
        public static string SettingsPath => ResourcePath.Down("mp-set.ini");
        public static string ProjectPath { get; set; } = string.Empty;

        public static void Init()
        {
            try
            {
                GPath.TryCreateDirectory(ResourcePath);
                if (!File.Exists(SettingsPath))
                {
                    // Proceed settings manually
                    var message = new SimpleMessageBox("처음 오셨군요!\n간단한 설정만 진행합니다.");
                    message.ShowDialog();
                    var firstSettings = new FirstSettingsWindow();
                    firstSettings.ShowDialog();

                    // Write Settings
                    var settingsString = new List<string>
                    {
                        ProjectPath
                    };
                    GFile.WriteByArray(SettingsPath, settingsString);
                }

                // Read Settings
                var data = GFile.ReadToArray(SettingsPath);
                ProjectPath = data[0];
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MintPandaPathManager), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
