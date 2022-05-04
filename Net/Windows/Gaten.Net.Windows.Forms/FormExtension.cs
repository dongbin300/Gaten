using Gaten.Net.Extension;

namespace Gaten.Net.Windows.Forms
{
    public static class FormExtension
    {
        public const int WindowTop = 30;
        public const int WindowBottom = 8;
        public const int WindowLeft = 8;
        public const int WindowRight = 8;

        /// <summary>
        /// 폼 border를 제외한 실제 마우스 좌표값
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Point GetCurrentPositionOnForm(this Form form, Point position)
        {
            return new Point(position.X - form.Location.X - WindowLeft, position.Y - form.Location.Y - WindowTop);
        }

        public static List<Control> GetControlsFromCurrentPosition(this Form form, Point position)
        {
            List<Control> controls = new List<Control>();
            foreach (Control control in form.Controls)
            {
                if (position.IsRectangleRange(control.Top, control.Bottom, control.Left, control.Right))
                {
                    controls.Add(control);
                }
            }

            return controls;
        }

        public static int GetMenuHeight(this Form form)
        {
            return 27;
        }
    }
}
