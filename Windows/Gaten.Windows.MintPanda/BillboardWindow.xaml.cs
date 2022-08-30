using Gaten.Windows.MintPanda.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// BillboardWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BillboardWindow : Window
    {
        public BillboardWindow()
        {
            InitializeComponent();

            Left = 0;
            Top = ScreenUtil.ScreenHeight - ScreenUtil.TaskbarHeight - 30;
            Width = ScreenUtil.ScreenWidth;
            Height = 30;
        }

        public void SetMarqueeText(string text)
        {
            Visibility = string.IsNullOrWhiteSpace(text) ? Visibility.Collapsed : Visibility.Visible;
            marquee.MarqueeContent = text;
        }

        public void SetMarqueeText(List<string> text)
        {
            Visibility = text.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            marquee.MarqueeContent = string.Join("  ", text);
        }
    }
}
