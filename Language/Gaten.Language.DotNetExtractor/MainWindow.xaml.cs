using Gaten.Net.Data.IO;
using Gaten.Net.Windows;

using InputSimulatorStandard.Native;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Gaten.Language.DotNetExtractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EasyExtractButton_Click(object sender, RoutedEventArgs e)
        {
            string dllName = dllNameTextBox.Text;

            InputSimulator.MouseClick(1800, 900);
            InputSimulator.Sleep(50);
            InputSimulator.KeyPress(Modifiers.Ctrl, VirtualKeyCode.VK_A);
            InputSimulator.Sleep(50);
            InputSimulator.KeyPress(Modifiers.Ctrl, VirtualKeyCode.VK_C);
            InputSimulator.Sleep(50);

            var code = Clipboard.GetText();
            var codeRaw = code.Split("\r\n").ToList();
            var codeNotEmpty = code.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var codeRaws = FilterCode(codeRaw);
            var codes = FilterCode(codeNotEmpty);

            if (TabIndentCheckBox.IsChecked ?? true)
            {
                codeRaws = SwitchToTab(codeRaws);
            }
            var result = string.Join("\r\n", codeRaws);

            var codeName = GetCodeName(codes);
            GResource.SetText(Path.Combine(GResource.DotNetDirectoryPath, dllName, codeName + ".txt"), result);
            StatusText.Text = codeName + " 저장 완료.";

        }

        private List<string> FilterCode(List<string> code)
        {
            // 주석 제거
            var data = code.Where(x => !x.StartsWith("//")).ToList();

            var data2 = new List<string>();
            foreach (var codeData in data)
            {
                // GUID 제거
                var codeData1 = Regex.Replace(codeData, @"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", "[[GUID]]");

                // __DynamicallyInvokable 제거
                string codeData2 = codeData1;
                if (codeData1.Contains("[__DynamicallyInvokable]"))
                {
                    codeData2 = codeData1.Replace("[__DynamicallyInvokable]", "");

                    if (codeData2.TakeWhile(char.IsWhiteSpace).Count() >= codeData2.Length)
                    {
                        continue;
                    }
                }
                var codeData3 = codeData2.Replace("__DynamicallyInvokable,", "").Replace(", __DynamicallyInvokable", "");
                data2.Add(codeData3);
            }

            return data2;
        }

        private List<string> SwitchToTab(List<string> codes)
        {
            List<string> result = new List<string>();

            foreach (var code in codes)
            {
                var whiteSpaceCount = code.TakeWhile(char.IsWhiteSpace).Count();
                var tabString = new string('	', whiteSpaceCount / 2);
                var code2 = tabString + code.Substring(whiteSpaceCount);

                result.Add(code2);
            }

            return result;
        }

        private string GetCodeName(List<string> codes)
        {
            string[] keywords = new string[]
               {
                "public", "private", "protected", "internal", "extern",
                "abstract", "virtual", "delegate", "sealed", "static",
                "class", "struct", "enum", "interface",
                "void", "TResult", "where"
               };

            bool blockStart = false;
            for (int i = 0; i < codes.Count; i++)
            {
                if (!blockStart && codes[i].StartsWith("{"))
                {
                    blockStart = true;
                }
                else if (blockStart && codes[i].Contains('['))
                {
                    continue;
                }
                else if (blockStart && !codes[i].Contains('['))
                {
                    var data = codes[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < data.Length; j++)
                    {
                        if (!keywords.Contains(data[j]))
                        {
                            return data[j].Replace('<', '(').Replace('>', ')');
                        }
                    }
                    break;
                }
            }

            return string.Empty;
        }
    }
}