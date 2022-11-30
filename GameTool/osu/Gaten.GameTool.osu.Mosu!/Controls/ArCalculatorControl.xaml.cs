using System;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.GameTool.osu.Mosu_.Controls
{
    /// <summary>
    /// ArCalculatorControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ArCalculatorControl : UserControl
    {
        public const double HEIGHT = 15.2; //본래 화면의 세로길이
        public const double CATCHER_HEIGHT = 2.2; //캐쳐의 키
        public const double AVAR_WIDTH = 5.05; //평균AR을 잴 가로길이

        public double ar, avAr; // AR
        public double ms, avMs; // 과일이 나타났을 때부터 사라지기까지의 시간(ms)
        public double fruitSize; //과일의 크기
        public double v, avV; //과일의 속력, 평균AR 과일의 속력

        public ArCalculatorControl()
        {
            InitializeComponent();

            ComboNumComboBox.Items.Add("0~99");
            ComboNumComboBox.Items.Add("100~199");
            ComboNumComboBox.Items.Add("200~");

            FruitSizeComboBox.Items.Add("2(큰거)");
            FruitSizeComboBox.Items.Add("3");
            FruitSizeComboBox.Items.Add("4");
            FruitSizeComboBox.Items.Add("5");
            FruitSizeComboBox.Items.Add("6");
            FruitSizeComboBox.Items.Add("7(작은거)");

            ComboNumComboBox.SelectedIndex = 0;
            FruitSizeComboBox.SelectedIndex = 0;
        }

        double ToAr(double ms) => 13 - ms / 150;

        double ToMs(double ar) => 1950 - ar * 150;

        private void FlashLightCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GammaCheckBox.IsEnabled = true;
            ComboNumComboBox.IsEnabled = true;
            FruitSizeComboBox.IsEnabled = true;
            ComboNumComboBox.SelectedIndex = 0;
            FruitSizeComboBox.SelectedIndex = 0;

            Recalculate(null, null);
        }

        private void FlashLightCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GammaCheckBox.IsEnabled = false;
            ComboNumComboBox.IsEnabled = false;
            FruitSizeComboBox.IsEnabled = false;

            Recalculate(null, null);
        }

        private void ArText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ArText.Text.Length > 0)
            {
                CalculateAR();
            }
            else
            {
                ResultText.Clear();
            }
        }

        void CalculateAR()
        {
            ar = double.Parse(ArText.Text);

            if (HardRockCheckBox.IsChecked.Value)
                ar = Math.Min(ar * 1.25, 10);
            if (DoubleTimeCheckBox.IsChecked.Value)
                ar = ToAr(ToMs(ar) * 0.666666);

            ms = ToMs(ar);

            if (FlashLightCheckBox.IsChecked.Value)
            {
                if (FruitSizeComboBox.SelectedIndex < 0 || ComboNumComboBox.SelectedIndex < 0) return;

                double[] fruitSizes = { 2.4, 2.2, 1.9, 1.7, 1.5, 1.2 };
                fruitSize = fruitSizes[FruitSizeComboBox.SelectedIndex] - (HardRockCheckBox.IsChecked.Value ? 0.5 : 0);

                v = (HEIGHT - CATCHER_HEIGHT - fruitSize) / ms;

                double[] visibleHeights = { 11.0, 10.0, 9.5 }; // 플라 걸었을 때 보이는 부분의 높이
                double[] visibleGammaHeights = { 12.3, 11.1, 10.0 }; // 플라 걸었을 때 보이는 부분의 높이(감마사용시)
                ms = ((GammaCheckBox.IsChecked.Value ? visibleGammaHeights[ComboNumComboBox.SelectedIndex] : visibleHeights[ComboNumComboBox.SelectedIndex]) - CATCHER_HEIGHT - fruitSize) / v;
                avMs = (Math.Sqrt(Math.Pow((GammaCheckBox.IsChecked.Value ? visibleGammaHeights[ComboNumComboBox.SelectedIndex] : visibleHeights[ComboNumComboBox.SelectedIndex]) - CATCHER_HEIGHT, 2) - Math.Pow(AVAR_WIDTH, 2)) - fruitSize) / v;
            }

            ar = ToAr(ms);
            avAr = ToAr(avMs);

            ResultText.Text = FlashLightCheckBox.IsChecked.Value ? $"최소AR: {string.Format("{0:0.0}", ar)}, 평균AR: {string.Format("{0:0.0}", avAr)}, 최소ms: {string.Format("{0:0}", ms)}, 평균ms: {string.Format("{0:0}", avMs)}" : $"AR: {string.Format("{0:0.0}", ar)}, ms: {string.Format("{0:0}", ms)}";
        }

        private void Recalculate(object sender, EventArgs e)
        {
            if (ArText.Text.Length > 0)
            {
                CalculateAR();
            }
        }
    }
}
