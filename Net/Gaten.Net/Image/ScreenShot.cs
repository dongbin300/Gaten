using Gaten.Net.Windows;

using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Gaten.Net.Image
{
    [SupportedOSPlatform("windows")]
    public class ScreenShot
    {
        public static void SaveToClipboard(int left, int top, int width, int height)
        {
            //var bitmap = Take(left, top, width, height);

            //Clipboard.SetImage(bitmap.GetHbitmap(), Process.GetCurrentProcess().MainWindowHandle);

            //bitmap.Dispose();
        }

        public static void SaveAsFile(int left, int top, int width, int height, string dirPath, string fileName, ImageFormat format)
        {
            var bitmap = Take(left, top, width, height);

            var dInfo = Directory.CreateDirectory(dirPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);

            bitmap.Save($"{dirPath}{(dirPath.LastIndexOf("\\") < dirPath.Length - 1 ? "\\" : "")}{fileName}", format);

            bitmap.Dispose();
        }

        public static Bitmap Take(int left, int top, int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            using (var destGrp = Graphics.FromImage(bitmap))
            {
                using (var sourceGrp = Graphics.FromHwnd(IntPtr.Zero))
                {
                    WinApi.BitBlt(destGrp.GetHdc(), 0, 0, bitmap.Width, bitmap.Height, sourceGrp.GetHdc(), left, top, WinApi.SRCCOPY);
                }
            }

            return bitmap;
        }
    }
}
