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

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double taskbarHeight = 30;

            Left = 0;
            Top = screenHeight - taskbarHeight - 30;
            Width = screenWidth;
            Height = 30;
        }

        public void SetMarqueeText(List<string> text)
        {
            marquee.MarqueeContent = string.Join("  ", text);
        }
    }
}
