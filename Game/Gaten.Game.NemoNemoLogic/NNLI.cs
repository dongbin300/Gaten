using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Gaten.Game.NemoNemoLogic
{
    /// <summary>
    /// 네모네모로직 이미지
    /// </summary>
    public class NNLI
    {
        public Bitmap bitmap, binaryBitmap, resizeBitmap;

        public NNLI() { }

        public NNLI LoadImage(string fileName)
        {
            bitmap = (Bitmap)Image.FromFile(fileName);
            return this;
        }

        public NNLI ToBinary()
        {
            byte[] pixel = GetPixelData(bitmap);
            binaryBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            int p = 0;
            for (int y = 0; y < bitmap.Height; y++)
                for (int x = 0; x < bitmap.Width; x++)
                    binaryBitmap.SetPixel(x, y, pixel[p++] + pixel[p++] + pixel[p++] > 382 ? Color.White : Color.Black);

            return this;
        }

        public NNLI ResizeImage(int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            resizeBitmap = new Bitmap(width, height);

            resizeBitmap.SetResolution(binaryBitmap.HorizontalResolution, binaryBitmap.VerticalResolution);

            using (var graphics = Graphics.FromImage(resizeBitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(binaryBitmap, destRect, 0, 0, binaryBitmap.Width, binaryBitmap.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return this;
        }

        public NNLI SaveImage(string fileName)
        {
            resizeBitmap.Save(fileName, ImageFormat.Png);
            return this;
        }

        public static byte[] GetPixelData(Bitmap b)
        {
            Rectangle rt = new Rectangle(0, 0, b.Width, b.Height);
            BitmapData bd = b.LockBits(rt, ImageLockMode.ReadWrite, b.PixelFormat);
            IntPtr ptr = bd.Scan0;
            int bytes = Math.Abs(bd.Stride) * b.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);
            b.UnlockBits(bd);

            return rgbValues;
        }
    }
}
