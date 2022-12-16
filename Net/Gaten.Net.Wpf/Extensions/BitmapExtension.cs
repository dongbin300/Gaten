using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Gaten.Net.Wpf.Extensions
{
    public static class BitmapExtension
    {
        public static BitmapImage ToImageSource(this Bitmap bitmap)
        {
            using var memory = new MemoryStream();
            bitmap.Save(memory, ImageFormat.Png);
            memory.Position = 0;
            var bitmapimage = new BitmapImage();
            bitmapimage.BeginInit();
            bitmapimage.StreamSource = memory;
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapimage.EndInit();

            return bitmapimage;
        }

        public static BitmapImage ToImageSource(this System.Drawing.Image img)
        {
            using var memory = new MemoryStream();
            img.Save(memory, ImageFormat.Png);
            memory.Position = 0;
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memory;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            return bitmapImage;
        }

        public static ImageSource ToImageSource(this Icon icon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
            //using var memory = new MemoryStream();
            //icon.Save(memory);
            //memory.Position = 0;
            //var bitmapImage = new BitmapImage();
            //bitmapImage.BeginInit();
            //bitmapImage.StreamSource = memory;
            //bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            //bitmapImage.EndInit();

            //return bitmapImage;
        }
    }
}
