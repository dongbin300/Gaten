using System.Drawing;
using System.Drawing.Drawing2D;

namespace Gaten.Net.Image
{
    public static class ImageExtension
    {
        public static void Resize(this System.Drawing.Image source, string destFileName, float scale)
        {
            using (var resized = ResizeBitmap(source, scale, InterpolationMode.HighQualityBicubic))
            {
                resized.Save(destFileName);
            }
        }

        public static Bitmap ResizeBitmap(this System.Drawing.Image source, float scale, InterpolationMode quality)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            // Figure out the new size.
            var width = (int)(source.Width * scale);
            var height = (int)(source.Height * scale);

            // Create the new bitmap.
            // Note that Bitmap has a resize constructor, but you can't control the quality.
            var bmp = new Bitmap(width, height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = quality;
                g.DrawImage(source, new Rectangle(0, 0, width, height));
                g.Save();
            }

            return bmp;
        }

        public static Bitmap CropImage(this System.Drawing.Image source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics.FromImage(bmp).DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
            return bmp;
        }
    }
}
