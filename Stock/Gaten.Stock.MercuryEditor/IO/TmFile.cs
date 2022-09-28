using Gaten.Net.Extensions;
using Gaten.Net.IO;

using Microsoft.Win32;

namespace Gaten.Stock.MercuryEditor.IO
{
    /// <summary>
    /// Trading Model File
    /// </summary>
    internal class TmFile
    {
        public static string CurrentFilePath = string.Empty;
        public static string TmName => (CurrentFilePath == string.Empty ? string.Empty : CurrentFilePath.GetOnlyFileName()) + (IsSaved ? "" : "*");
        public static bool IsSaved = true;

        public static void Save(string codeText)
        {
            if (CurrentFilePath == string.Empty)
            {
                SaveFileDialog dialog = new()
                {
                    Title = "트레이딩 모델 파일 저장",
                    Filter = "trading model files (*.tm)|*.tm"
                };

                if (dialog.ShowDialog() ?? true)
                {
                    IsSaved = true;
                    CurrentFilePath = dialog.FileName;
                    GFile.Write(dialog.FileName, codeText);
                }
            }
            else
            {
                IsSaved = true;
                GFile.Write(CurrentFilePath, codeText);
            }
        }

        public static void SaveAs(string codeText)
        {
            SaveFileDialog dialog = new()
            {
                Title = "트레이딩 모델 파일 저장",
                Filter = "trading model files (*.tm)|*.tm"
            };

            if (dialog.ShowDialog() ?? true)
            {
                IsSaved = true;
                CurrentFilePath = dialog.FileName;
                GFile.Write(dialog.FileName, codeText);
            }
        }

        public static string Open()
        {
            OpenFileDialog dialog = new()
            {
                Title = "트레이딩 모델 파일 불러오기",
                Filter = "trading model files (*.tm)|*.tm"
            };

            if (dialog.ShowDialog() ?? true)
            {
                IsSaved = true;
                CurrentFilePath = dialog.FileName;
                return GFile.Read(dialog.FileName);
            }

            return string.Empty;
        }
    }
}
