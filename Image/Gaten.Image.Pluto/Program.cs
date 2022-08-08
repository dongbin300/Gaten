using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Gaten.Image.Pluto
{
    [SupportedOSPlatform("windows")]
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {
            Console.Title = "Pluto";
            Console.CursorVisible = false;

            DrawScene(args[0]);

            Console.ReadLine();
        }

        static void DrawScene(string fileName)
        {
            var sceneBitmap = new Bitmap(fileName);
            using (Graphics g = Graphics.FromHwnd(GetConsoleWindow()))
            {
                g.DrawImage(sceneBitmap, new Point(0, 0));
            }
        }
    }
}

