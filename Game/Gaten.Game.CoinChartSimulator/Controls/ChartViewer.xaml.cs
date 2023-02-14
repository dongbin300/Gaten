using Gaten.Net.Extensions;
using Gaten.Net.Stock.Charts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Gaten.Game.CoinChartSimulator.Controls
{
    /// <summary>
    /// ChartViewer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChartViewer : UserControl
    {
        public int ViewCountMin { get; } = 1;
        public int ViewCountMax { get; } = 1000;
        public int TotalCount { get; set; } = 0;
        public int Start { get; set; } = 0;
        public int End { get; set; } = 0;
        public int ViewCount => End - Start + 1;

        private List<Candle> candles = new();

        private Pen yangPen = new(new SolidColorBrush(Color.FromRgb(59, 207, 134)), 1.0);
        private Pen yinPen = new(new SolidColorBrush(Color.FromRgb(237, 49, 97)), 1.0);
        private Pen yangDashPen = new(new SolidColorBrush(Color.FromRgb(59, 207, 134)), 1.0);
        private Pen yinDashPen = new(new SolidColorBrush(Color.FromRgb(237, 49, 97)), 1.0);
        private Brush yangBrush = new SolidColorBrush(Color.FromRgb(59, 207, 134));
        private Brush yinBrush = new SolidColorBrush(Color.FromRgb(237, 49, 97));
        private int candleMargin = 1;

        public bool IsYang { get; set; }
        public double EntryPrice { get; set; } = 0;

        public ChartViewer()
        {
            InitializeComponent();

            yangDashPen.DashStyle = DashStyles.Dash;
            yinDashPen.DashStyle = DashStyles.Dash;
        }

        public void Init()
        {
            candles.Clear();
        }

        public void AddCandle(Candle candle)
        {
            candles.Add(candle);
            TotalCount = candles.Count;
            End = candles.Count - 1;
            InvalidateVisual();
        }

        public void UpdateCandle(Candle candle)
        {
            if (candles.Count == 0)
            {
                AddCandle(candle);
                return;
            }

            candles[^1] = candle;
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

            if (candles.Count == 0)
            {
                return;
            }

            var itemWidth = ActualWidth / ViewCount;
            double max = candles.Substring(Start, ViewCount).Max(x => x.High);
            double min = candles.Substring(Start, ViewCount).Min(x => x.Low);

            for (int i = Start; i <= End; i++)
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

            // Draw displaying entry price with dashed pen
            if (EntryPrice > 0)
            {
                drawingContext.DrawLine(
                    IsYang ? yangDashPen : yinDashPen,
                    new Point(0, ActualHeight * (1.0 - (EntryPrice - min) / (max - min))),
                    new Point(ActualWidth, ActualHeight * (1.0 - (EntryPrice - min) / (max - min)))
                    );
            }
        }
    }
}
