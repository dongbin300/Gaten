using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Gaten.Net.Wpf.Extensions
{
    public static class BitmapExtension
    {
        public static BitmapImage ToImageSource(this Bitmap bitmap)
        {
            using var memory = new MemoryStream();
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
            memory.Position = 0;
            var bitmapimage = new BitmapImage();
            bitmapimage.BeginInit();
            bitmapimage.StreamSource = memory;
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapimage.EndInit();

            return bitmapimage;
        }
    }
}
