using Gaten.Net.Image;

using System.Drawing.Imaging;

namespace Gaten.Image.PlutoEditor.Panel
{
    public static class PPanelExtension
    {
        public static Bitmap PanelToBitmap(this PPanel panel)
        {
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            return bitmap;
        }

        public static void CopyPanel(this PPanel panel, PPanel dest)
        {
            dest.BackgroundImage = panel.PanelToBitmap();
        }

        public static Color GetPixel(this PPanel panel, int x, int y)
        {
            return panel.PanelToBitmap().GetPixel(x, y);
        }

        public static void SetPixel(this PPanel panel, int x, int y, Color color)
        {
            Bitmap bitmap = panel.PanelToBitmap();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(new SolidBrush(color), new Rectangle(U.P(x), U.P(y), U.P(1), U.P(1)));
            }
            panel.BackgroundImage = bitmap;
        }

        public static void UpdateImage(this PPanel panel, System.Drawing.Image updateImage)
        {
            Rectangle rect = new Rectangle(0, 0, updateImage.Width, updateImage.Height);
            PixelFormat format = updateImage.PixelFormat;
            panel.BackgroundImage = new Bitmap(updateImage).Clone(rect, format);
        }

        public static System.Drawing.Image IntegrateImage(this PPanel mainPanel, List<PPanel> panels)
        {
            Dictionary<int, int> iDict = new Dictionary<int, int>();
            List<int> zIndexes = new List<int>();
            int i = 0;

            foreach (PPanel panel in panels)
            {
                // 리스트에 Z-index 추가
                iDict.Add(panel.Z, i++);
                zIndexes.Add(panel.Z);
            }

            // Z-index로 오름차순 정렬
            zIndexes.Sort();

            LockBitmap lockBitmap = new LockBitmap(new Bitmap(mainPanel.CW, mainPanel.CH));
            lockBitmap.LockBits();
            for (int j = 0; j < mainPanel.CoordinateColors.Length; j++)
            {
                lockBitmap.SetPixel(j / mainPanel.CH, j % mainPanel.CH, mainPanel.CoordinateColors[j]);
            }

            // 겹치는 패널 부분을 다시 그림
            // Z-index가 낮을수록 먼저 그려야 함
            foreach (int z in zIndexes)
            {
                PPanel panel = panels[iDict[z]];
                for (int j = 0; j < panel.CoordinateColors.Length; j++)
                {
                    lockBitmap.SetPixel(panel.CX + j / panel.CH, panel.CY + j % panel.CH, panel.CoordinateColors[j]);
                }
            }
            lockBitmap.UnlockBits();

            Bitmap IntegratedBitmap = lockBitmap.source;
            lockBitmap.Dispose();

            return IntegratedBitmap;
        }

        public static void SaveFile(this PPanel mainPanel, List<PPanel> panels, string fileName)
        {
            string[] data = fileName.Split('.');
            string extension = data[data.Length - 1];

            switch (extension.ToLower())
            {
                case "ps":
                    SavePsFile(mainPanel, panels, fileName);
                    break;
                case "bmp":
                    SaveBmpFile(mainPanel, panels, fileName);
                    break;
                case "png":
                    SavePngFile(mainPanel, panels, fileName);
                    break;
            }
        }

        public static void OpenFile(this PPanel panel, string fileName)
        {
            string[] data = fileName.Split('.');
            string extension = data[data.Length - 1];

            switch (extension.ToLower())
            {
                case "ps":
                    OpenPsFile(panel, fileName);
                    break;
                case "bmp":
                    OpenBmpFile(panel, fileName);
                    break;
                case "png":
                    OpenPngFile(panel, fileName);
                    break;
            }
        }

        public static void SavePsFile(PPanel mainPanel, List<PPanel> panels, string fileName)
        {
            // 각 패널의 컬러테이블
            // 스케일, 격자, 툴박스 설정(옵션)
        }

        public static void SaveBmpFile(PPanel mainPanel, List<PPanel> panels, string fileName)
        {
            Bitmap IntegratedBitmap = new Bitmap(mainPanel.IntegrateImage(panels));
            IntegratedBitmap.Save(fileName, ImageFormat.Bmp);
        }

        public static void SavePngFile(PPanel mainPanel, List<PPanel> panels, string fileName)
        {
            Bitmap IntegratedBitmap = new Bitmap(mainPanel.IntegrateImage( panels));
            IntegratedBitmap.Save(fileName, ImageFormat.Png);
        }

        public static void OpenPsFile(PPanel panel, string fileName)
        {

        }

        public static void OpenBmpFile(PPanel panel, string fileName)
        {
            Bitmap bitmap = new Bitmap(fileName);
            panel.CW = bitmap.Width;
            panel.CH = bitmap.Height;
            panel.ReCalculate();

            LockBitmap lockBitmap = new LockBitmap(bitmap);
            lockBitmap.LockBits();
            for (int i = 0; i < bitmap.Width * bitmap.Height; i++)
            {
                panel.CoordinateColors[i] = lockBitmap.GetPixel(i / panel.CH, i % panel.CH);
            }
            lockBitmap.UnlockBits();
            lockBitmap.Dispose();
        }

        public static void OpenPngFile(PPanel panel, string fileName)
        {
            Bitmap bitmap = new Bitmap(fileName);
            panel.CW = bitmap.Width;
            panel.CH = bitmap.Height;
            panel.ReCalculate();

            LockBitmap lockBitmap = new LockBitmap(bitmap);
            lockBitmap.LockBits();
            for (int i = 0; i < panel.CoordinateColors.Length; i++)
            {
                panel.CoordinateColors[i] = lockBitmap.GetPixel(i / panel.CH, i % panel.CH);
            }
            lockBitmap.UnlockBits();
            lockBitmap.Dispose();
        }
    }
}
