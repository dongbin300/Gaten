using Gaten.Net.Extension;
using Gaten.Net.Data;
using Gaten.Net.Data.Math;
using Gaten.Net.Image;
using System.Drawing;



namespace Gaten.Study.TestConsole
{
    public class Program
    {
        public static void Main()
        {
            Bitmap bitmap = new Bitmap(Image.FromFile("C:\\AATEST\\aa.png"));

            var _a = bitmap.GetPixelData();

            var a = bitmap.GetPixelColor();
        }

        public static List<Color> GetPixel(Bitmap bitmap)
        {
            List<Color> colors = new List<Color>();
            LockBitmap lockBitmap = new LockBitmap(bitmap);
            lockBitmap.LockBits();

            for (int i = 0; i < lockBitmap.Height; i++)
            {
                for (int j = 0; j < lockBitmap.Width; j++)
                {
                    colors.Add(lockBitmap.GetPixel(j, i));
                }
            }

            lockBitmap.UnlockBits();
            lockBitmap.Dispose();


            return colors;
        }
    }
}
