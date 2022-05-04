using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gaten.Net.Extension;
using Gaten.Net.Image;

namespace Gaten.Image.PlutoEditor.Panel
{
    /// <summary>
    /// Pluto Panel
    /// </summary>
    public class PPanel : System.Windows.Forms.Panel
    {
        // 비트맵
        public Bitmap bitmap;

        // 좌표 RGB 테이블
        public Color[] CoordinateColors;

        // 좌표 변수
        public int CX;
        public int CY;
        public int CW;
        public int CH;

        // Z-Index
        public int Z;

        public PPanel() { }

        public PPanel(string name, int x, int y, int w, int h, int z)
        {
            Name = name;
            CX = x;
            CY = y;
            CW = w;
            CH = h;
            Z = z;
            Location = new Point(U.P(x), U.P(y));
            Size = new Size(U.P(w), U.P(h));

            CoordinateColors = new Color[w * h];
            for (int i = 0; i < CoordinateColors.Length; i++)
            {
                CoordinateColors[i] = Color.Black;
            }

            RePaint();
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void SetScenePanel()
        {
            BackgroundImageLayout = ImageLayout.None;
        }

        /// <summary>
        /// 픽셀값 재계산
        /// </summary>
        public void ReCalculate()
        {
            Location = new Point(U.P(CX), U.P(CY));
            Size = new Size(U.P(CW), U.P(CH));
        }

        /// <summary>
        /// 좌표 1개의 색상 설정
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetCoordinate(int x, int y, Color color)
        {
            // 패널 바깥쪽 = 에러
            if (!x.IsRange(0, CW - 1)) return;
            if (!y.IsRange(0, CH - 1)) return;

            // RGB 테이블 갱신
            CoordinateColors[x * CW + y] = color;

            // LockBitmap으로 비트맵 갱신
            LockBitmap lockBitmap = new LockBitmap(bitmap);

            lockBitmap.LockBits();
            lockBitmap.FillRectangle(new Rectangle(U.P(x), U.P(y), U.P(1), U.P(1)), color);
            lockBitmap.UnlockBits();

            this.UpdateImage(lockBitmap.source);

            lockBitmap.Dispose();
        }

        /// <summary>
        /// 비트맵으로 다시 그리기
        /// </summary>
        public void RePaint(bool grid = false, bool marker = false)
        {
            bitmap = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i < CoordinateColors.Length; i++)
                    g.FillRectangle(new SolidBrush(CoordinateColors[i]), new Rectangle(U.P(i / CH), U.P(i % CH), U.P(1), U.P(1)));

                // 격자 그리기
                if (grid)
                {
                    const int gridColor = 45;
                    Pen gridPen = new Pen(Color.FromArgb(gridColor, gridColor, gridColor));
                    for (int i = 0; i < Width; i += U.P(1))
                        g.DrawLine(gridPen, new Point(i, 0), new Point(i, Height));

                    for (int i = 0; i < Height; i += U.P(1))
                        g.DrawLine(gridPen, new Point(0, i), new Point(Width, i));
                }

                // 마커 그리기
                if (marker)
                {
                    Pen markerPen = new Pen(new SolidBrush(Color.AntiqueWhite), 1);
                    for (int i = 0; i < Width; i += 6)
                    {
                        g.DrawLine(markerPen, i, 0, i + 3, 0);
                        g.DrawLine(markerPen, i, Height - 1, i + 3, Height - 1);
                    }

                    for (int i = 0; i < Height; i += 6)
                    {
                        g.DrawLine(markerPen, 0, i, 0, i + 3);
                        g.DrawLine(markerPen, Width - 1, i, Width - 1, i + 3);
                    }
                }
            }

            this.UpdateImage(bitmap);
        }

        public new void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: CY--; break;
                case Direction.Down: CY++; break;
                case Direction.Left: CX--; break;
                case Direction.Right: CX++; break;
            }

            Location = new Point(U.P(CX), U.P(CY));
        }
    }
}
