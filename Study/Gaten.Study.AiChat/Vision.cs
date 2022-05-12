namespace Gaten.Study.AiChat
{
    public class Vision
    {
        public static Color PenColor = Color.Black;
        public Vision() { }

        public static void DrawMessage(PaintEventArgs e, int x, int y, string s, bool reverse)
        {
            DrawBubble(e, x, y, 10 + GetPixelSize(s), 20, reverse);
            DrawText(e, x + 5, y + 5, s);
        }

        public static void DrawBubble(PaintEventArgs e, int x, int y, int width, int height, bool reverse)
        {
            const int KNOB_SIZE = 6;
            const int ARC_RADIUS = 10;
            Pen pen = new Pen(PenColor, 1);
            Brush brush = new SolidBrush(Color.FromArgb(255, 242, 188));

            if (reverse)
            {
                e.Graphics.DrawLine(pen, x + width + KNOB_SIZE, y - KNOB_SIZE / 3, x + width, y);
                e.Graphics.DrawLine(pen, x + ARC_RADIUS, y, x + width, y);
                e.Graphics.DrawArc(pen, new Rectangle(x, y, ARC_RADIUS * 2, ARC_RADIUS * 2), 180, 90);
                e.Graphics.DrawLine(pen, x + width, y + ARC_RADIUS, x + width, y + height - ARC_RADIUS);
                e.Graphics.DrawArc(pen, new Rectangle(x + width - ARC_RADIUS * 2, y + height - ARC_RADIUS * 2, ARC_RADIUS * 2, ARC_RADIUS * 2), 0, 90);
                e.Graphics.DrawLine(pen, x + width - ARC_RADIUS, y + height, x + ARC_RADIUS, y + height);
                e.Graphics.DrawArc(pen, new Rectangle(x, y + height - ARC_RADIUS * 2, ARC_RADIUS * 2, ARC_RADIUS * 2), 90, 90);
                e.Graphics.DrawLine(pen, x + width, y + height - ARC_RADIUS, x + width, y + KNOB_SIZE);
                e.Graphics.DrawLine(pen, x + width, y + KNOB_SIZE, x + width + KNOB_SIZE, y - KNOB_SIZE / 3);
            }
            else
            {
                e.Graphics.DrawLine(pen, x - KNOB_SIZE, y - KNOB_SIZE / 3, x, y);
                e.Graphics.DrawLine(pen, x, y, x + width - 10, y);
                e.Graphics.DrawArc(pen, new Rectangle(x + width - ARC_RADIUS * 2, y, ARC_RADIUS * 2, ARC_RADIUS * 2), 270, 90);
                e.Graphics.DrawLine(pen, x + width, y + ARC_RADIUS, x + width, y + height - ARC_RADIUS);
                e.Graphics.DrawArc(pen, new Rectangle(x + width - ARC_RADIUS * 2, y + height - ARC_RADIUS * 2, ARC_RADIUS * 2, ARC_RADIUS * 2), 0, 90);
                e.Graphics.DrawLine(pen, x + width - ARC_RADIUS, y + height, x + ARC_RADIUS, y + height);
                e.Graphics.DrawArc(pen, new Rectangle(x, y + height - ARC_RADIUS * 2, ARC_RADIUS * 2, ARC_RADIUS * 2), 90, 90);
                e.Graphics.DrawLine(pen, x, y + height - ARC_RADIUS, x, y + KNOB_SIZE);
                e.Graphics.DrawLine(pen, x, y + KNOB_SIZE, x - KNOB_SIZE, y - KNOB_SIZE / 3);
            }

            //e.Graphics.FillRectangle(brush, new Rectangle(x, y, width, height));
        }

        public static void DrawText(PaintEventArgs e, int x, int y, string s)
        {
            Font font = new Font(new FontFamily("굴림체"), 9);
            Brush brush = new SolidBrush(PenColor);
            e.Graphics.DrawString(s, font, brush, x, y);
        }

        public static int GetPixelSize(string s)
        {
            double pixelSize = 0;

            // 한글이면 1글자당 12.5픽셀, 이외는 1글자당 6.25픽셀
            foreach (char c in s)
                pixelSize = char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter ? pixelSize + 12.5 : pixelSize + 6.25;

            return (int)pixelSize;
        }
    }
}