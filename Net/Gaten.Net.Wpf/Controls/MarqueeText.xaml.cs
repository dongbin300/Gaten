using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Gaten.Net.Wpf.Controls
{
    /// <summary>
    /// MarqueeText.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MarqueeText : UserControl
    {
        public MarqueeType MarqueeType { get; set; }
        public double MarqueeTimeInSeconds { get; set; }
        public string MarqueeContent
        {
            set => text.Text = value;
        }

        public MarqueeText()
        {
            InitializeComponent();
            mainCanvas.Height = Height;
            mainCanvas.Width = Width;
            this.Loaded += new RoutedEventHandler(MarqueeText_Loaded);
        }

        void MarqueeText_Loaded(object sender, RoutedEventArgs e)
        {
            StartMarqueeing(MarqueeType);
        }

        public void StartMarqueeing(MarqueeType marqueeType)
        {
            if (marqueeType == MarqueeType.LeftToRight)
            {
                LeftToRightMarquee();
            }
            else if (marqueeType == MarqueeType.RightToLeft)
            {
                RightToLeftMarquee();
            }
            else if (marqueeType == MarqueeType.TopToBottom)
            {
                TopToBottomMarquee();
            }
            else if (marqueeType == MarqueeType.BottomToTop)
            {
                BottomToTopMarquee();
            }
        }

        private void LeftToRightMarquee()
        {
            double height = mainCanvas.ActualHeight - text.ActualHeight;
            text.Margin = new Thickness(0, height / 2, 0, 0);
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = -text.ActualWidth;
            doubleAnimation.To = mainCanvas.ActualWidth;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(MarqueeTimeInSeconds));
            text.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
        }
        private void RightToLeftMarquee()
        {
            double height = mainCanvas.ActualHeight - text.ActualHeight;
            text.Margin = new Thickness(0, height / 2, 0, 0);
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = -mainCanvas.ActualWidth;
            doubleAnimation.To = mainCanvas.ActualWidth;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(MarqueeTimeInSeconds));
            text.BeginAnimation(Canvas.RightProperty, doubleAnimation);
        }
        private void TopToBottomMarquee()
        {
            double width = mainCanvas.ActualWidth - text.ActualWidth;
            text.Margin = new Thickness(width / 2, 0, 0, 0);
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = -text.ActualHeight;
            doubleAnimation.To = mainCanvas.ActualHeight;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(MarqueeTimeInSeconds));
            text.BeginAnimation(Canvas.TopProperty, doubleAnimation);
        }
        private void BottomToTopMarquee()
        {
            double width = mainCanvas.ActualWidth - text.ActualWidth;
            text.Margin = new Thickness(width / 2, 0, 0, 0);
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = -text.ActualHeight;
            doubleAnimation.To = mainCanvas.ActualHeight;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(MarqueeTimeInSeconds));
            text.BeginAnimation(Canvas.BottomProperty, doubleAnimation);
        }
    }
    public enum MarqueeType
    {
        LeftToRight,
        RightToLeft,
        TopToBottom,
        BottomToTop
    }
}