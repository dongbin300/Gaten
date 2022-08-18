using Gaten.Net.IO;
using Gaten.Net.Math;

using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gaten.Visual.DataVisualizer
{
    /// <summary>
    /// WaveVisualizer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WaveVisualizer : UserControl
    {
        private double scale = 1.0;
        private List<double> values = new();
        private Complex[] sources = new Complex[1024];
        //private List<int> freqValues = new();
        //private List<SineWave> waves = new();
        private CompositeWave compositeWave = new();

        private Pen yangPen = new(new SolidColorBrush(Color.FromRgb(59, 207, 134)), 1.0);
        private Pen wavePen = new(new SolidColorBrush(Color.FromRgb(200, 200, 200)), 1.0);
        private Pen yinPen = new(new SolidColorBrush(Color.FromRgb(237, 49, 97)), 1.0);
        private Brush yangBrush = new SolidColorBrush(Color.FromRgb(59, 207, 134));
        private Brush yinBrush = new SolidColorBrush(Color.FromRgb(237, 49, 97));
        private int candleMargin = 1;

        public WaveVisualizer()
        {
            InitializeComponent();
        }

        public void Init(string path)
        {
            var data = GFile.ReadToArray(path);
            foreach (var d in data)
            {
                values.Add(double.Parse(d));
            }

            for (int i = 0; i < data.Length; i++)
            {
                sources[i] = new Complex(values[i], 0);
            }

            compositeWave = FourierTransform.Recomposite(sources);

            InvalidateVisual();
        }

        private void UserControl_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (scale <= 0.02)
                {
                    return;
                }

                scale -= 0.02;
            }
            else
            {
                if (scale >= 1.0)
                {
                    return;
                }

                scale += 0.02;
            }

            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            // Value
            int xNum = values.Count;
            int scaledXNum = (int)(xNum * scale);

            double x = ActualWidth / scaledXNum;
            double max = values.Take(scaledXNum).Max();
            double min = values.Take(scaledXNum).Min();

            for (int i = 0; i < scaledXNum - 1; i++)
            {
                drawingContext.DrawLine(yangPen,
                    new Point(x * (i + 0.5), ActualHeight * (1.0 - (values[i] - min) / (max - min))),
                    new Point(x * (i + 1.5), ActualHeight * (1.0 - (values[i + 1] - min) / (max - min))));
            }

            // Wave
            //int waveStartY = 0;
            //foreach (var wave in waves)
            //{
            //    int waveXNum = wave.Magnitudes.Count;
            //    int scaledWaveXNum = (int)(waveXNum * scale);

            //    double waveX = ActualWidth / scaledWaveXNum;
            //    double waveMax = wave.Magnitudes.Take(scaledWaveXNum).Max();
            //    double waveMin = wave.Magnitudes.Take(scaledWaveXNum).Min();
            //    int waveHeight = (int)(ActualHeight / 20);
            //    waveStartY += waveHeight;

            //    for (int i = 0; i < wave.Magnitudes.Count - 1; i++)
            //    {
            //        drawingContext.DrawLine(wavePen,
            //            new Point(waveX * (i + 0.5), waveStartY + waveHeight * (1.0 - (wave.Magnitudes[i] - waveMin) / (waveMax - waveMin))),
            //            new Point(waveX * (i + 1.5), waveStartY + waveHeight * (1.0 - (wave.Magnitudes[i+1] - waveMin) / (waveMax - waveMin)))
            //            );
            //    }
            //}

            // Composite Wave
            {
                int compositeWaveXNum = compositeWave.Magnitudes.Count;
                int scaledCompositeWaveXNum = (int)(compositeWaveXNum * scale);

                double compositeWaveX = ActualWidth / scaledCompositeWaveXNum;
                double compositeWaveMax = compositeWave.Magnitudes.Take(scaledCompositeWaveXNum).Max();
                double compositeWaveMin = compositeWave.Magnitudes.Take(scaledCompositeWaveXNum).Min();

                for (int i = 0; i < compositeWave.Magnitudes.Count - 1; i++)
                {
                    drawingContext.DrawLine(wavePen,
                        new Point(compositeWaveX * (i + 0.5), ActualHeight * (1.0 - (compositeWave.Magnitudes[i] - compositeWaveMin) / (compositeWaveMax - compositeWaveMin))),
                        new Point(compositeWaveX * (i + 1.5), ActualHeight * (1.0 - (compositeWave.Magnitudes[i + 1] - compositeWaveMin) / (compositeWaveMax - compositeWaveMin)))
                        );
                }
            }
        }
    }
}
