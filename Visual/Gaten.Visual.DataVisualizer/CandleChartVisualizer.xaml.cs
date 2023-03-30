using Gaten.Net.Extensions;
using Gaten.Net.IO;
using Gaten.Net.Stock.Charts;
using Gaten.Visual.DataVisualizer.Interfaces;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Gaten.Visual.DataVisualizer
{
    /// <summary>
    /// CandleChartVisualizer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CandleChartVisualizer : UserControl, IWaveVisualizer
    {
        public int ViewCountMin { get; } = 10;
        public int ViewCountMax { get; } = 1000;
        public int TotalCount { get; set; } = 0;
        public int Start { get; set; } = 0;
        public int End { get; set; } = 0;
        public int ViewCount => End - Start;
        public Point CurrentMousePosition { get; set; }

        private List<Candle> candles = new();

        private Pen yangPen = new(new SolidColorBrush(Color.FromRgb(59, 207, 134)), 1.0);
        private Pen yinPen = new(new SolidColorBrush(Color.FromRgb(237, 49, 97)), 1.0);
        private Brush yangBrush = new SolidColorBrush(Color.FromRgb(59, 207, 134));
        private Brush yinBrush = new SolidColorBrush(Color.FromRgb(237, 49, 97));
        private int candleMargin = 1;

        public CandleChartVisualizer()
        {
            InitializeComponent();
        }

        public void Init(string path)
        {
            var data = GFile.ReadCsvWithNoHeader(path);
            foreach (DataRow row in data.Rows)
            {
                candles.Add(new Candle(
                    time: DateTime.Parse(row[0].ToString()),
                    open: double.Parse(row[1].ToString()),
                    high: double.Parse(row[2].ToString()),
                    low: double.Parse(row[3].ToString()),
                    close: double.Parse(row[4].ToString()),
                    volume: double.Parse(row[5].ToString())
                ));
            }
            TotalCount = End = candles.Count;
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

                Start = Math.Min(TotalCount - ViewCountMin, Start + 1);
                End = Math.Max(ViewCountMin, End - 1);
            }
            else // Zoom-out
            {
                if (ViewCount >= ViewCountMax)
                {
                    return;
                }

                Start = Math.Max(0, Start - 1);
                End = Math.Min(TotalCount, End + 1);
            }

            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var itemWidth = ActualWidth / (ViewCount - 1);
            double max = candles.Substring(Start, End - Start).Max(x => x.High);
            double min = candles.Substring(Start, End - Start).Min(x => x.Low);

            for (int i = Start; i < End - 1; i++)
            {
                var candle = candles[i];
                var viewIndex = i - Start;
                drawingContext.DrawLine(
                    candle.Open < candle.Close ? yangPen : yinPen,
                    new Point(itemWidth * (viewIndex + 0.5), ActualHeight * (1.0 - (candle.High - min) / (max - min))),
                    new Point(itemWidth * (viewIndex + 0.5), ActualHeight * (1.0 - (candle.Low - min) / (max - min))));
                drawingContext.DrawRectangle(
                    candle.Open < candle.Close ? yangBrush : yinBrush,
                    candle.Open < candle.Close ? yangPen : yinPen,
                    new Rect(
                    new Point(itemWidth * viewIndex + candleMargin, ActualHeight * (1.0 - (candle.Open - min) / (max - min))),
                    new Point(itemWidth * (viewIndex + 1) - candleMargin, ActualHeight * (1.0 - (candle.Close - min) / (max - min)))
                    ));
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
