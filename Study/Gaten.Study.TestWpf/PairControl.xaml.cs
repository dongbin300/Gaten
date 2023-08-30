using System.Windows;
using System.Windows.Controls;

namespace Gaten.Study.TestWpf
{
    /// <summary>
    /// PairControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PairControl : UserControl
    {
        public static readonly DependencyProperty PairProperty = DependencyProperty.Register(
        "Pair", typeof(Pair), typeof(PairControl), new PropertyMetadata(null));

        public Pair Pair
        {
            get { return (Pair)GetValue(PairProperty); }
            set { SetValue(PairProperty, value); }
        }

        public PairControl()
        {
            InitializeComponent();
        }

        public void Init(string symbol, string price)
        {
            Pair = new Pair(symbol, price);
        }
    }
}
