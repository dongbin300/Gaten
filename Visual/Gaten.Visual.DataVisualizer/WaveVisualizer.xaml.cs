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
        public int ViewCountMin => 10;
        public int ViewCountMax { get; set; }
        public int TotalCount { get; set; } = 0;
        public int Start { get; set; } = 0;
        public int End { get; set; } = 0;
        public int ViewCount => End - Start + 1;
        public int ZoomInterval => TotalCount / 25;
        public int MoveInterval => ViewCount / 100;
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
            ViewCountMax = TotalCount = End = values.Count;
            InvalidateVisual();
        }

        public void Init(List<double> values)
        {
            this.values = values;
            ViewCountMax = TotalCount = End = values.Count;
            InvalidateVisual();
        }

        public void Init(int min, int max, int count)
        {
            var r = new SmartRandom();
            for (int i = 0; i < count; i++)
            {
                values.Add(r.Next(min, max));
            }
            ViewCountMax = TotalCount = End = values.Count;
            InvalidateVisual();
        }

        private void UserControl_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0) // Zoom-in
            {
                if (ViewCount <= ViewCountMin)
                {
                    return;
                }

                Start = System.Math.Min(TotalCount - ViewCountMin, Start + ZoomInterval);
                End = System.Math.Max(ViewCountMin, End - ZoomInterval);
            }
            else // Zoom-out
            {
                if (ViewCount >= ViewCountMax)
                {
                    return;
                }

                Start = System.Math.Max(0, Start - ZoomInterval);
                End = System.Math.Min(TotalCount, End + ZoomInterval);
            }

            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (TotalCount == 0)
            {
                return;
            }

            var itemWidth = ActualWidth / ViewCount;
            double max = values.Substring(Start, ViewCount).Max();
            double min = values.Substring(Start, ViewCount).Min();

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
                    if (Start > MoveInterval)
                    {
                        Start -= MoveInterval;
                        End -= MoveInterval;
                        InvalidateVisual();
                    }
                }
                else if (diff.X < 0)
                {
                    if (End < TotalCount - MoveInterval)
                    {
                        Start += MoveInterval;
                        End += MoveInterval;
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
