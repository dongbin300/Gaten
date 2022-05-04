namespace Gaten.Net.Windows.Forms
{
    public class Delegater
    {
        public delegate void _ProgressBarSetValue(ProgressBar pb, int val);
        public delegate void _ProgressBarSetMax(ProgressBar pb, int max);
        public delegate void _ListBoxSelect(ListBox lb, int index);
        public delegate void _TextSet(Control con, string text);
        public delegate void _EnableSet(Control con, bool enable);
        public delegate void _PanelRefresh(Panel panel);
        public delegate void _VisibleSet(Control c, bool visible);

        public static void ProgressBarSetValue(ProgressBar pb, int value)
        {
            if (pb.InvokeRequired)
            {
                var del = new _ProgressBarSetValue(ProgressBarSetValue);
                pb.Invoke(del, new object[] { pb, value });
            }
            else
            {
                pb.Value = value;
            }
        }

        public static void ProgressBarSetMax(ProgressBar pb, int max)
        {
            if (pb.InvokeRequired)
            {
                var del = new _ProgressBarSetMax(ProgressBarSetMax);
                pb.Invoke(del, new object[] { pb, max });
            }
            else
            {
                pb.Maximum = max;
            }
        }

        public static void ListBoxSelect(ListBox lb, int index)
        {
            if (lb.InvokeRequired)
            {
                var del = new _ListBoxSelect(ListBoxSelect);
                lb.Invoke(del, new object[] { lb, index });
            }
            else
            {
                lb.SelectedIndex = index;
            }
        }

        public static void TextSet(Control con, string text)
        {
            if (con.InvokeRequired)
            {
                var del = new _TextSet(TextSet);
                con.Invoke(del, new object[] { con, text });
            }
            else
            {
                con.Text = text;
            }
        }

        public static void EnableSet(Control con, bool enable)
        {
            if (con.InvokeRequired)
            {
                var del = new _EnableSet(EnableSet);
                con.Invoke(del, new object[] { con, enable });
            }
            else
            {
                con.Enabled = enable;
            }
        }

        public static void PanelRefresh(Panel panel)
        {
            if (panel.InvokeRequired)
            {
                var d = new _PanelRefresh(PanelRefresh);
                panel.Invoke(d, new object[] { panel });
            }
            else
            {
                panel.Refresh();
            }
        }

        public static void VisibleSet(Control c, bool visible)
        {
            if (c.InvokeRequired)
            {
                var d = new _VisibleSet(VisibleSet);
                c.Invoke(d, new object[] { c, visible });
            }
            else
            {
                c.Visible = visible;
            }
        }
    }
}