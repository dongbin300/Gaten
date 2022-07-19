using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace Gaten.Net.Image
{
    public class LockBitmap : IDisposable
    {
        public Bitmap source = null;
        IntPtr Iptr = IntPtr.Zero;
        BitmapData bitmapData = null;

        public byte[] Pixels { get; set; }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int RowSize { get; private set; }

        public bool IsDisposed { get; private set; }

        public LockBitmap(Bitmap source)
        {
            this.source = source;
            IsDisposed = false;
        }

        /// <summary>
        /// Lock bitmap data
        /// </summary>
        public void LockBits()
        {
            try
            {
                if (IsDisposed)
                    throw new ObjectDisposedException(typeof(LockBitmap).Name);

                // Get width and height of bitmap
                Width = source.Width;
                Height = source.Height;

                // Create rectangle to lock
                Rectangle rect = new Rectangle(0, 0, Width, Height);

                // get source bitmap pixel format size
                Depth = System.Drawing.Image.GetPixelFormatSize(source.PixelFormat);

                // Check if bpp (Bits Per Pixel) is 8, 24, or 32
                if (Depth != 8 && Depth != 24 && Depth != 32)
                {
                    throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                }

                // Lock bitmap and return bitmap data
                bitmapData = source.LockBits(rect, ImageLockMode.ReadWrite, source.PixelFormat);

                // create byte array to copy pixel values
                RowSize = bitmapData.Stride < 0 ? -bitmapData.Stride : bitmapData.Stride;
                Pixels = new byte[Height * RowSize];
                Iptr = bitmapData.Scan0;

                // Copy data from pointer to array
                // Not working for negative Stride see. http://stackoverflow.com/a/10360753/1498252
                //Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
                // Solution for positive and negative Stride:
                for (int y = 0; y < Height; y++)
                {
                    Marshal.Copy(IntPtr.Add(Iptr, y * bitmapData.Stride),
                        Pixels, y * RowSize,
                        RowSize);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Unlock bitmap data
        /// </summary>
        public void UnlockBits()
        {
            try
            {
                if (IsDisposed)
                    throw new ObjectDisposedException(typeof(LockBitmap).Name);
                if (bitmapData == null)
                    throw new InvalidOperationException("Image is not locked.");

                // Copy data from byte array to pointer
                //Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);
                for (int y = 0; y < Height; y++)
                {
                    Marshal.Copy(Pixels, y * RowSize,
                        IntPtr.Add(Iptr, y * bitmapData.Stride),
                        RowSize);
                }

                // Unlock bitmap data
                source.UnlockBits(bitmapData);
                bitmapData = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Color GetPixel(int x, int y)
        {
            if (IsDisposed)
                throw new ObjectDisposedException(typeof(LockBitmap).Name);

            Color color = Color.Empty;

            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = (y * RowSize) + (x * cCount);

            if (i > Pixels.Length - cCount)
                throw new IndexOutOfRangeException();

            switch (Depth)
            {
                case 32: // For 32 bpp get Red, Green, Blue and Alpha
                    color = Color.FromArgb(Pixels[i + 3], Pixels[i + 2], Pixels[i + 1], Pixels[i]);
                    break;
                case 24: // For 24 bpp get Red, Green and Blue
                    color = Color.FromArgb(Pixels[i + 2], Pixels[i + 1], Pixels[i]);
                    break;
                case 8: // For 8 bpp get color value (Red, Green and Blue values are the same)
                    color = Color.FromArgb(Pixels[i], Pixels[i], Pixels[i]);
                    break;
            }
            return color;
        }

        /// <summary>
        /// Set the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, Color color)
        {
            if (IsDisposed)
                throw new ObjectDisposedException(typeof(LockBitmap).Name);

            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = (y * RowSize) + (x * cCount);
            if (i > Pixels.Length - cCount)
                throw new IndexOutOfRangeException();

            switch (Depth)
            {
                case 32: // For 32 bpp set Red, Green, Blue and Alpha
                    Pixels[i] = color.B;
                    Pixels[i + 1] = color.G;
                    Pixels[i + 2] = color.R;
                    Pixels[i + 3] = color.A;
                    break;
                case 24: // For 24 bpp set Red, Green and Blue
                    Pixels[i] = color.B;
                    Pixels[i + 1] = color.G;
                    Pixels[i + 2] = color.R;
                    break;
                case 8: // For 8 bpp set color value (Red, Green and Blue values are the same)
                    Pixels[i] = color.B;
                    break;
            }
        }

        public void FillRectangle(Rectangle rect, Color color)
        {
            for (int x = rect.X; x < rect.X + rect.Width; x++)
                for (int y = rect.Y; y < rect.Y + rect.Height; y++)
                    SetPixel(x, y, color);
        }

        #region IDisposable Members

        ~LockBitmap()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (bitmapData != null)
            {
                source.UnlockBits(bitmapData);
                bitmapData = null;
            }
            source = null;
            IsDisposed = true;
        }

        #endregion
    }
}