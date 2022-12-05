using Gaten.Net.Extensions;
using Gaten.Net.IO;
using Gaten.Net.Math;
using Gaten.Visual.DataVisualizer.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Gaten.Visual.DataVisualizer
{
    /// <summary>
    /// WaveVisualizer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WaveVisualizer : UserControl, IWaveVisualizer
    {
        public int ViewCountMin { get; } = 10;
        public int ViewCountMax { get; } = 1000;
        public int TotalCount { get; set; } = 0;
        public int Start { get; set; } = 0;
        public int End { get; set; } = 0;
        public int ViewCount => End - Start;
        public Point CurrentMousePosition { get; set; }


        private List<double> values = new();

        private Pen yangPen = new(new SolidColorBrush(Color.FromRgb(59, 207, 134)), 1.0);
        private Pen wavePen = new(new SolidColorBrush(Color.FromRgb(200, 200, 200)), 1.0);
        private Pen yinPen = new(new SolidColorBrush(Color.FromRgb(237, 49, 97)), 1.0);
        private Brush yangBrush = new SolidColorBrush(Color.FromRgb(59, 207, 134));
        private Brush yinBrush = new SolidColorBrush(Color.FromRgb(237, 49, 97));


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
            TotalCount = End = values.Count;
            InvalidateVisual();
        }

        public void Init(int min, int max, int count)
        {
            var r = new SmartRandom();
            for(int i = 0; i < count; i++)
            {
                values.Add(r.Next(min, max));
            }
            TotalCount = End = values.Count;
            InvalidateVisual();
        }

        private void UserControl_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0) // Zoom-in
            {
                if (ViewCount <= ViewCountMin)
                {
                    return;
                }

                Start = System.Math.Min(TotalCount - ViewCountMin, Start + 1);
                End = System.Math.Max(ViewCountMin, End - 1);
            }
            else // Zoom-out
            {
                if (ViewCount >= ViewCountMax)
                {
                    return;
                }

                Start = System.Math.Max(0, Start - 1);
                End = System.Math.Min(TotalCount, End + 1);
            }

            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var itemWidth = ActualWidth / (ViewCount-1);
            double max = values.Substring(Start, End - Start).Max();
            double min = values.Substring(Start, End - Start).Min();

            for (int i = Start; i < End - 1; i++)
            {
                int viewIndex = i - Start;
                drawingContext.DrawLine(wavePen,
                    new Point(itemWidth * (viewIndex + 0.0), ActualHeight * (1.0 - (values[i] - min) / (max - min))),
                    new Point(itemWidth * (viewIndex + 1.0), ActualHeight * (1.0 - (values[i + 1] - min) / (max - min))));
            }
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            Vector diff = e.GetPosition(Parent as Window) - CurrentMousePosition;
            if (IsMouseCaptured)
            {
                if (diff.X > 0)
                {
                    if (Start > 0)
                    {
                        Start--;
                        End--;
                        InvalidateVisual();
                    }
                }
                else if (diff.X < 0)
                {
                    if (End < TotalCount - 1)
                    {
                        Start++;
                        End++;
                        InvalidateVisual();
                    }
                }
            }
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentMousePosition = e.GetPosition(Parent as Window);
            CaptureMouse();
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
                ReleaseMouseCapture();
            }
        }
    }
}
