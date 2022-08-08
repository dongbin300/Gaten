using Gaten.Net.IO;
using Gaten.Net.Stock;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gaten.Visual.DataVisualizer
{
    /// <summary>
    /// CandleChartVisualizer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CandleChartVisualizer : UserControl
    {
        private double scale = 1.0;
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
            var data = GFile.ReadCsv(path);
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

            InvalidateVisual();
        }

        private void UserControl_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                if(scale <= 0.2)
                {
                    return;
                }

                scale -= 0.1;
            }
            else
            {
                if(scale >= 1.0)
                {
                    return;
                }

                scale += 0.1;
            }

            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            int xNum = candles.Count;
            int scaledXNum = (int)(xNum * scale);

            double x = ActualWidth / scaledXNum;
            double max = candles.Take(scaledXNum).Max(x => x.High);
            double min = candles.Take(scaledXNum).Min(x => x.Low);

            for (int i = 0; i < scaledXNum; i++)
            {
                var candle = candles[i];
                drawingContext.DrawLine(
                    candle.Open < candle.Close ? yangPen : yinPen,
                    new Point(x * (i + 0.5), ActualHeight * (1.0 - (candle.High - min) / (max - min))),
                    new Point(x * (i + 0.5), ActualHeight * (1.0 - (candle.Low - min) / (max - min))));
                drawingContext.DrawRectangle(
                    candle.Open < candle.Close ? yangBrush : yinBrush,
                    candle.Open < candle.Close ? yangPen : yinPen,
                    new Rect(
                    new Point(x * i + candleMargin, ActualHeight * (1.0 - (candle.Open - min) / (max - min))),
                    new Point(x * (i + 1) - candleMargin, ActualHeight * (1.0 - (candle.Close - min) / (max - min)))
                    ));
            }
        }


    }
}
