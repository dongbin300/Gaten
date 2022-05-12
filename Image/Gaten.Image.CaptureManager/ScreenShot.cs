using Gaten.Net.Windows;

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Gaten.Image.CaptureManager
{
    public sealed class ScreenShot
    {
        public static void SaveToClipboard(int left, int top, int width, int height)
        {
            var bitmap = Take(left, top, width, height);

            Clipboard.SetImage(bitmap.GetHbitmap(), Process.GetCurrentProcess().MainWindowHandle);

            bitmap.Dispose();
        }

        public static void SaveAsFile(int left, int top, int width, int height, string dirPath, string fileName, ImageFormat format)
        {
            var bitmap = Take(left, top, width, height);

            Directory.CreateDirectory(dirPath);
            bitmap.Save($"{dirPath}{(dirPath.LastIndexOf("\\") < dirPath.Length - 1 ? "\\" : "")}{fileName}", format);

            bitmap.Dispose();
        }

        private static Bitmap Take(int left, int top, int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            using (var destGrp = Graphics.FromImage(bitmap))
            {
                using (var sourceGrp = Graphics.FromHwnd(IntPtr.Zero))
                {
                    WinAPI.BitBlt(destGrp.GetHdc(), 0, 0, bitmap.Width, bitmap.Height, sourceGrp.GetHdc(), left, top, WinAPI.SRCCOPY);
                }
            }

            return bitmap;
        }
    }
}
