using CryptoExchange.Net.CommonObjects;

using Gaten.Stock.MarinerX.Bots;

using Skender.Stock.Indicators;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gaten.Stock.MarinerX.Views.Controls
{
    /// <summary>
    /// BackTestChartControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BackTestChartControl : UserControl
    {
        private double scale = 0.2;
        public List<Quote> Quotes = new();
        public List<BackTestTrade> Trades = new();

        private Pen yangPen = new(new SolidColorBrush(Color.FromRgb(59, 207, 134)), 1.0);
        private Pen yinPen = new(new SolidColorBrush(Color.FromRgb(237, 49, 97)), 1.0);
        private Brush yangBrush = new SolidColorBrush(Color.FromRgb(59, 207, 134));
        private Brush yinBrush = new SolidColorBrush(Color.FromRgb(237, 49, 97));
        private int candleMargin = 1;

        public BackTestChartControl()
        {
            InitializeComponent();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            int xNum = Quotes.Count;
            int scaledXNum = (int)(xNum * scale);

            double x = ActualWidth / scaledXNum;
            var max = Quotes.Take(scaledXNum).Max(x => x.High);
            var min = Quotes.Take(scaledXNum).Min(x => x.Low);

            for (int i = 0; i < scaledXNum; i++)
            {
                var quote = Quotes[i];

                // Draw Candle
                drawingContext.DrawLine(
                    quote.Open < quote.Close ? yangPen : yinPen,
                    new Point(x * (i + 0.5), ActualHeight * (double)(1.0m - (quote.High - min) / (max - min))),
                    new Point(x * (i + 0.5), ActualHeight * (double)(1.0m - (quote.Low - min) / (max - min))));
                drawingContext.DrawRectangle(
                    quote.Open < quote.Close ? yangBrush : yinBrush,
                    quote.Open < quote.Close ? yangPen : yinPen,
                    new Rect(
                    new Point(x * i + candleMargin, ActualHeight * (double)(1.0m - (quote.Open - min) / (max - min))),
                    new Point(x * (i + 1) - candleMargin, ActualHeight * (double)(1.0m - (quote.Close - min) / (max - min)))
                    ));

                // Draw Buy/Sell History Arrow
                var trade = Trades.Find(x => x.time.Equals(quote.Date));
                if (trade != null)
                {
                    if (trade.side == Binance.Net.Enums.PositionSide.Long)
                    {
                        drawingContext.DrawLine(yangPen,
                    new Point(x * (i + 0.5), ActualHeight * (double)(1.0m - (quote.Low - min) / (max - min)) + 24),
                    new Point(x * (i + 0.5), ActualHeight * (double)(1.0m - (quote.Low - min) / (max - min)) + 10));
                        drawingContext.DrawLine(yangPen,
                    new Point(x * (i + 0.25), ActualHeight * (double)(1.0m - (quote.Low - min) / (max - min)) + 15),
                    new Point(x * (i + 0.5), ActualHeight * (double)(1.0m - (quote.Low - min) / (max - min)) + 10));
                        drawingContext.DrawLine(yangPen,
                    new Point(x * (i + 0.75), ActualHeight * (double)(1.0m - (quote.Low - min) / (max - min)) + 15),
                    new Point(x * (i + 0.5), ActualHeight * (double)(1.0m - (quote.Low - min) / (max - min)) + 10));
                    }
                    else
                    {
                        drawingContext.DrawLine(yinPen,
                    new Point(x * (i + 0.5), ActualHeight * (double)(1.0m - (quote.High - min) / (max - min)) - 24),
                    new Point(x * (i + 0.5), ActualHeight * (double)(1.0m - (quote.High - min) / (max - min)) - 10));
                        drawingContext.DrawLine(yinPen,
                    new Point(x * (i + 0.25), ActualHeight * (double)(1.0m - (quote.High - min) / (max - min)) - 15),
                    new Point(x * (i + 0.5), ActualHeight * (double)(1.0m - (quote.High - min) / (max - min)) - 10));
                        drawingContext.DrawLine(yinPen,
                    new Point(x * (i + 0.75), ActualHeight * (double)(1.0m - (quote.High - min) / (max - min)) - 15),
                    new Point(x * (i + 0.5), ActualHeight * (double)(1.0m - (quote.High - min) / (max - min)) - 10));
                    }
                }
            }
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
    }
}
