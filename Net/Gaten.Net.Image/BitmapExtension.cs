using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Image
{
    public static class BitmapExtension
    {
        /// <summary>
        /// 비트맵의 RGB값 얻기
        /// </summary>
        /// <param name="b">비트맵</param>
        /// <returns>RGB 값</returns>
        public static byte[] GetPixelData(this Bitmap b)
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

        public static List<Color> GetPixelColor(this Bitmap b)
        {
            List<Color> results = new List<Color>();
            var data = GetPixelData(b);

            for(int i = 0; i < data.Length; i += 4)
            {
                results.Add(Color.FromArgb(data[i + 3], data[i + 2], data[i + 1], data[i]));
            }

            return results;
        }
    }
}
