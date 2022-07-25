using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gaten.Net.Wpf.Controls
{
    /// <summary>
    /// PathIconSubMenuItem.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PathIconSubMenuItem : UserControl
    {
        public static readonly DependencyProperty IconPathDataProperty =
           DependencyProperty.Register("IconPathData", typeof(string), typeof(PathIconSubMenuItem), new PropertyMetadata(""));
        public string IconPathData
        {
            get => (string)GetValue(IconPathDataProperty);
            set
            {
                SetValue(IconPathDataProperty, value);
            }
        }
        public static readonly DependencyProperty HeaderProperty =
           DependencyProperty.Register("Header", typeof(string), typeof(PathIconSubMenuItem), new PropertyMetadata(""));
        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set
            {
                SetValue(HeaderProperty, value);
            }
        }
        public static readonly DependencyProperty ThicknessProperty =
           DependencyProperty.Register("Thickness", typeof(double), typeof(PathIconSubMenuItem), new PropertyMetadata(1.0));
        public double Thickness
        {
            get => (double)GetValue(ThicknessProperty);
            set
            {
                SetValue(ThicknessProperty, value);
            }
        }
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PathIconSubMenuItem));
        public event RoutedEventHandler Click
        {
            add => AddHandler(MenuItem.ClickEvent, value);
            remove => RemoveHandler(MenuItem.ClickEvent, value);
        }

        public PathIconSubMenuItem()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            pen.Brush = Foreground;
            pen.Thickness = Thickness;
            menu.Header = Header;
            geometry.Geometry = Geometry.Parse(IconPathData);
        }
    }
}
