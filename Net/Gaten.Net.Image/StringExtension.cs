using System.Drawing;
using System.Drawing.Drawing2D;

namespace Gaten.Net.Image
{
    public static class StringExtension
    {
        /// <summary>
        /// File->ResizeImage (width)
        /// </summary>
        /// <param name="srcFileName"></param>
        /// <param name="imageWidth"></param>
        /// <returns></returns>
        public static Bitmap Resize(this string srcFileName, int imageWidth)
        {
            using (var bitmap = System.Drawing.Image.FromFile(srcFileName))
            {
                float scale = (float)imageWidth / bitmap.Width;
                return bitmap.ResizeBitmap(scale, InterpolationMode.HighQualityBicubic);
            }
        }
    }
}
