using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Gaten.Net.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for _ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker
    {
        #region Variables
        private static ValueBox _vbR;
        private static ValueBox _vbG;
        private static ValueBox _vbB;
        private static Point _mousePos;
        private static CopyBox _cbRGB;
        private static CopyBox _cbHEX;
        private static Border _currentColor;
        private static Border _lastColor;
        #endregion

        #region DependencyProperty declaration
        private static readonly DependencyProperty IsCurrentColorProperty = DependencyProperty.Register(
            "IsCurrentColor", typeof(Color), typeof(ColorPicker),
            new FrameworkPropertyMetadata(Color.FromRgb(255, 255, 255),
            new PropertyChangedCallback(OnIsCurrentColorChanged)));

        private static readonly RoutedEvent CurrentColorChangedEvent = EventManager.RegisterRoutedEvent(
            "CurrentColorChanged",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler), typeof(ColorPicker));

        private static readonly DependencyProperty IsLastColorProperty = DependencyProperty.Register(
            "IsLastColor", typeof(Color), typeof(ColorPicker),
            new FrameworkPropertyMetadata(Color.FromRgb(255, 255, 255),
            new PropertyChangedCallback(OnIsLastColorChanged)));

        private static readonly RoutedEvent LastColorChangedEvent = EventManager.RegisterRoutedEvent(
            "LastColorChanged",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler), typeof(ColorPicker));
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public ColorPicker()
        {
            this.InitializeComponent();
            AddValueBoxes();
            AddCopyBoxes();
            AddColorBar();
            AddColorSelectorGradient();
        }
        #endregion

        #region Event wrappers
        /// <summary>
        /// Occurs when the current color changed.
        /// </summary>
        public event RoutedEventHandler CurrentColorChanged
        {
            add { AddHandler(CurrentColorChangedEvent, value); }
            remove { RemoveHandler(CurrentColorChangedEvent, value); }
        }
        /// <summary>
        /// Occurs when the last color changed.
        /// </summary>
        public event RoutedEventHandler LastColorChanged
        {
            add { AddHandler(LastColorChangedEvent, value); }
            remove { RemoveHandler(LastColorChangedEvent, value); }
        }
        #endregion

        #region Properties
        ///<summary>
        ///Gets the current selected Color.
        /// </summary>
        public Color IsCurrentColor
        {
            get { return (Color)GetValue(IsCurrentColorProperty); }
        }
        /// <summary>
        /// Gets the last Selected Color.
        /// </summary>
        public Color IsLastColor
        {
            get { return (Color)GetValue(IsLastColorProperty); }
        }
        /// <summary>
        /// Gets the R value of the current color.
        /// </summary>
        public int R
        {
            get { return (int)((Color)GetValue(IsCurrentColorProperty)).R; }
        }
        /// <summary>
        /// Gets the G value of the current color.
        /// </summary>
        public int G
        {
            get { return (int)((Color)GetValue(IsCurrentColorProperty)).G; }
        }
        /// <summary>
        /// Gets the B value of the current color.
        /// </summary>
        public int B
        {
            get { return (int)((Color)GetValue(IsCurrentColorProperty)).B; }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Adds the three value boxes to show thr RGB values.
        /// </summary>
        private void AddValueBoxes()
        {
            _vbR = new()
            {
                Height = 22,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new(20, 3, 0, 0)
            };

            _vbG = new()
            {
                Height = 22,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new(20, 29, 0, 0)
            };

            _vbB = new()
            {
                Height = 22,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new(20, 55, 0, 0)
            };

            _ColorInfoUnit.Children.Add(_vbR);
            _ColorInfoUnit.Children.Add(_vbG);
            _ColorInfoUnit.Children.Add(_vbB);
        }

        /// <summary>
        /// Adds two CopyBoxes for RGB and HEX.
        /// </summary>
        private void AddCopyBoxes()
        {
            _cbRGB = new()
            {
                Height = 22,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new(5.5, 0, 0, 30),
                Text = "255,255,255"
            };

            _cbHEX = new()
            {
                Height = 22,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new(5.5, 0, 0, 0),
                Text = "#FFFFFF"
            };

            _ColorInfoUnit.Children.Add(_cbRGB);
            _ColorInfoUnit.Children.Add(_cbHEX);

        }

        /// <summary>
        /// Creates the Last and the Current color border.
        /// </summary>
        private void AddColorBar()
        {
            _currentColor = new Border
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 22, 0),
                BorderBrush = new SolidColorBrush(Color.FromRgb(51, 51, 51)),
                BorderThickness = new Thickness(1, 0, 0, 1),
                CornerRadius = new CornerRadius(3),
                Background = Brushes.White,
                Height = 24
            };

            _lastColor = new Border
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 0, 0),
                Width = 22,
                CornerRadius = new CornerRadius(3),
                BorderBrush = new SolidColorBrush(Color.FromRgb(51, 51, 51)),
                BorderThickness = new Thickness(1, 0, 1, 1),
                Background = Brushes.White,
                Height = 24
            };

            _ColorBarUnit.Children.Add(_currentColor);
            _ColorBarUnit.Children.Add(_lastColor);
        }

        /// <summary>
        /// Creates the gradient for the color selector.
        /// </summary>
        private void AddColorSelectorGradient()
        {
            LinearGradientBrush linearGradientBrush = new()
            {
                StartPoint = new Point(0.5, 0),
                EndPoint = new Point(0.5, 1)
            };
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 0), 0.020));
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 255, 0), 0.167));
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 255, 0), 0.334));
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 255, 255), 0.501));
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 0, 0, 255), 0.668));
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 255), 0.835));
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 0, 0), 0.975));
            _colorSelector.Background = linearGradientBrush;
        }
        /// <summary>
        /// Sets the value of the ValueBoxes.
        /// </summary>
        /// <param name="color"></param>
        private static void SetColorInfos(Color color)
        {
            _vbR.Value = color.R;
            _vbG.Value = color.G;
            _vbB.Value = color.B;
            _cbRGB.Text = color.R.ToString() + "," + color.G.ToString() + "," + color.B.ToString();
            string HexColor = string.Format("0x{0:X8}", color.ToString());
            _cbHEX.Text = "#" + HexColor.Remove(0, 5);
        }
        /// <summary>
        /// Release the mouse when cliped.
        /// </summary>
        public static void ReleaseMouse()
        {
            CLPcursor.Release();
        }
        #endregion

        #region Events

        #region ColorSelector
        private void ColorSelectorUnit_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //Sets the new position of the color selector stylus.
                _stylus.Margin = new Thickness(0, e.GetPosition(_ColorSelectorUnit).Y - 4, 0, 0);
                //Sets the background of the base color.
                _BaseColor.Background = new SolidColorBrush(MouseControling.PixelUnderMouse());
                //Gets the pixel color from the point mousePos.
                Color color = MouseControling.PixelColor(_mousePos);
                //Sets the current color property
                SetValue(IsCurrentColorProperty, color);
                //Sets the _currentColor.Background (_currentColor has been created of the methode AddColorBar ad is an border).
                _currentColor.Background = new SolidColorBrush(color);
            }
        }

        private void ColorSelectorUnit_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CLPcursor.OnUIElement(_colorSelectorCliping);
            _ColorSelectorUnit.Cursor = Cursors.None;
            //Gets a point which represents the center of the PickerStylus -> verry important because this is used on
            //ColorSelectorUnit_MouseMove to calculate the color.
            _mousePos = _PickerStylus.PointToScreen(new Point(7.5, 7.5));
            //Sets the mouse in the centere of stylus.
            MouseControling.SetOnUIElement(new Point(_stylus.Width / 2, (_stylus.Height / 2) - 1), _stylus);
        }

        private void ColorSelectorUnit_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Release the mouse cliping.
            CLPcursor.Release();
            //Sets the cursor to arrow.
            _ColorSelectorUnit.Cursor = Cursors.Arrow;
            //Sets the new position of the stylus.
            _stylus.Margin = new Thickness(0, e.GetPosition(_ColorSelectorUnit).Y - 4, 0, 0);
        }

        private void ColorSelectorUnit_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //the same as on _ColorSelectorUnit_PreviewMouseLeftButtonDown
                CLPcursor.OnUIElement(_colorSelectorCliping);
                _ColorSelectorUnit.Cursor = Cursors.None;
                _mousePos = _PickerStylus.PointToScreen(new Point(7.5, 7.5));
                MouseControling.SetOnUIElement(new Point(_stylus.Width / 2, (_stylus.Height / 2) - 1), _stylus);
            }
        }
        #endregion

        #region ColorPicker
        private void ColorPickerUnit_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //Sets the position of the PickerStylus.
                _PickerStylus.Margin = new Thickness(e.GetPosition(_colorPickerCliping).X - 7.5, e.GetPosition(_colorPickerCliping).Y - 7.5, 0, 0);
                //Sets the IsCurrentColorProperty to the color under the mouse.
                SetValue(IsCurrentColorProperty, MouseControling.PixelUnderMouse());
            }
        }

        private void ColorPickerUnit_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Clips the cursor to the _ColorPickerCliping which is an Canvas.
            CLPcursor.OnUIElement(_colorPickerCliping);
            //Sets the visibility of the _PickerStylus.
            _PickerStylus.Visibility = Visibility.Collapsed;
            //Sets the cursor of the _ColorPickerUnit to Pen.
            _ColorPickerUnit.Cursor = Cursors.Pen;
            //Sets the mouse position to the centere of the _PickerStylus.
            MouseControling.SetOnUIElement(new Point(_PickerStylus.Width / 2, (_PickerStylus.Height / 2) - 1), _PickerStylus);
            //Sets the IsLastColorProperty.
            SetValue(IsLastColorProperty, IsCurrentColor);
            //_lastColor.Background which is an border gets the _currentColorBackground
            _lastColor.Background = _currentColor.Background;
        }

        private void ColorPickerUnit_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Release the mouse cliping.
            CLPcursor.Release();
            //Sets the cursor to arrow
            _ColorPickerUnit.Cursor = Cursors.Arrow;
            //Sets the position of the _PickerStylus.
            _PickerStylus.Margin = new Thickness(e.GetPosition(_colorPickerCliping).X - 7.5, e.GetPosition(_colorPickerCliping).Y - 7.5, 0, 0);
            //Sets the visibility of the _PickerStylus
            _PickerStylus.Visibility = Visibility.Visible;
        }

        private void ColorPickerUnit_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //Clips the mouse to the _colorPicerCliping.
                CLPcursor.OnUIElement(_colorPickerCliping);
                //Visibility of _PickerStylus
                _PickerStylus.Visibility = Visibility.Collapsed;
                //Sets the cursor of _ColorPickerUnit.
                _ColorPickerUnit.Cursor = Cursors.Pen;
                //Sets the mouse position to the centere of _PickerStylus
                MouseControling.SetOnUIElement(new Point(_PickerStylus.Width / 2, (_PickerStylus.Height / 2) - 1), _PickerStylus);
            }
        }

        #endregion
        private static void OnIsCurrentColorChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            //Calls SetColorInfo which takes an color. 
            SetColorInfos((Color)e.NewValue);
            //Sets the _currentColor.Background.
            _currentColor.Background = new SolidColorBrush((Color)e.NewValue);
            //If you use this Control and add an Event to LastColorChanged it would be thrown from here.
            _vbB.RaiseEvent(new RoutedEventArgs(CurrentColorChangedEvent, (Color)e.NewValue));
        }
        private static void OnIsLastColorChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            //If you use this Control and add an Event to LastColorChanged it would be thrown from here.
            _vbB.RaiseEvent(new RoutedEventArgs(LastColorChangedEvent, (Color)e.NewValue));
        }
        #endregion       
    }

    internal class CopyBox : Border
    {
        #region Variables
        readonly TextBox txt_value;
        #endregion

        #region Constructor
        public CopyBox()
        {
            Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            CornerRadius = new CornerRadius(3);
            BorderBrush = Brushes.Black;
            BorderThickness = new Thickness(1);
            txt_value = new TextBox
            {
                Background = Brushes.Transparent,
                BorderBrush = Brushes.Transparent,
                Margin = new Thickness(3, 1, 3, 1),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.White,
                IsReadOnly = true
            };
            Child = txt_value;
        }
        #endregion

        #region Propertys
        /// <summary>
        /// Sets the Text of the CopyBox.
        /// </summary>        
        public string Text
        {
            set { txt_value.Text = value; }
        }
        #endregion
    }

    internal class ValueBox : Grid
    {
        #region Variables
        private int _value;
        private readonly int _maximum;
        private double _step;
        private double _width;
        private readonly Border border_background;
        private readonly Border border_value;
        private readonly TextBox txt_value;


        #endregion

        #region Constructor
        public ValueBox()
        {
            _value = 255;
            _maximum = 255;

            MouseLeftButtonDown += new MouseButtonEventHandler(ValueBox_MouseLeftButtonDown);
            SizeChanged += new SizeChangedEventHandler(ValueBox_SizeChanged);

            border_background = new()
            {
                Margin = new Thickness(0, 0, 0, 0),
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            LinearGradientBrush DarkGrayGradient = new()
            {
                StartPoint = new Point(0.5, 0),
                EndPoint = new Point(0.5, 1)
            };
            DarkGrayGradient.GradientStops.Add(new GradientStop(Color.FromArgb(255, 51, 51, 51), 0.32));
            DarkGrayGradient.GradientStops.Add(new GradientStop(Color.FromArgb(255, 85, 85, 85), 0.169));
            border_background.CornerRadius = new CornerRadius(3);
            border_background.Background = DarkGrayGradient;

            border_value = new Border
            {
                Margin = new Thickness(1, 1, 1, 1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            LinearGradientBrush LightGrayGradient = new()
            {
                StartPoint = new Point(0.5, 0),
                EndPoint = new Point(0.5, 1)
            };
            LightGrayGradient.GradientStops.Add(new GradientStop(Color.FromArgb(255, 102, 102, 102), 0.32));
            LightGrayGradient.GradientStops.Add(new GradientStop(Color.FromArgb(255, 131, 131, 131), 0.169));
            border_value.CornerRadius = new CornerRadius(3);
            border_value.Background = LightGrayGradient;

            txt_value = new TextBox
            {
                Margin = new Thickness(3, 1, 1, 3),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.Transparent,
                BorderBrush = Brushes.Transparent,
                Foreground = Brushes.White,
                Text = "255",
                IsReadOnly = true
            };
            txt_value.TextChanged += new TextChangedEventHandler(Txt_value_TextChanged);

            this.Children.Add(border_background);
            this.Children.Add(border_value);
            this.Children.Add(txt_value);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Sets or gets the value.
        /// </summary>
        public int Value
        {
            set
            {
                if (value > _maximum)
                {
                    _value = 255;
                    txt_value.Text = "255";
                }
                else
                {
                    _value = value;
                    txt_value.Text = value.ToString();
                }
            }
            get { return _value; }
        }

        #endregion

        #region Events
        private void Txt_value_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txt_value.Text) > _maximum)
                {
                    border_value.Width = _maximum;
                }
                else
                {
                    border_value.Width = (Convert.ToDouble(txt_value.Text)) * _step;
                }
            }
            catch
            {
            }
        }
        void ValueBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _width = e.NewSize.Width;
            _step = _width / _maximum;
        }
        void ValueBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txt_value.Focus();
            txt_value.SelectAll();
        }
        #endregion
    }

    /// <summary>
    ///  Provides methodes to clip the mouse. 
    /// </summary>    
    internal class CLPcursor
    {
        #region API - Methodes        
        [DllImport("user32.dll")]
        static extern bool ClipCursor(ref RECT lpRect);
        #endregion

        #region Variables
        private static RECT myrect = new RECT();
        private static UIElement uIEelement;

        #endregion

        #region Structs
        private struct RECT
        {
            #region Variables.
            /// <summary>
            /// Left position of the rectangle.
            /// </summary>
            public int Left;
            /// <summary>
            /// Top position of the rectangle.
            /// </summary>
            public int Top;
            /// <summary>
            /// Right position of the rectangle.
            /// </summary>
            public int Right;
            /// <summary>
            /// Bottom position of the rectangle.
            /// </summary>
            public int Bottom;
            #endregion

            #region Constructor.
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="left">Horizontal position.</param>
            /// <param name="top">Vertical position.</param>
            /// <param name="right">Right most side.</param>
            /// <param name="bottom">Bottom most side.</param>
            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
            #endregion

            #region Operators
            /// <summary>
            /// Operator to convert a RECT to Drawing.Rectangle.
            /// </summary>
            /// <param name="rect">Rectangle to convert.</param>
            /// <returns>A Drawing.Rectangle</returns>
            public static implicit operator System.Drawing.Rectangle(RECT rect)
            {
                return System.Drawing.Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
            }

            /// <summary>
            /// Operator to convert Drawing.Rectangle to a RECT.
            /// </summary>
            /// <param name="rect">Rectangle to convert.</param>
            /// <returns>RECT rectangle.</returns>
            public static implicit operator RECT(System.Drawing.Rectangle rect)
            {
                return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
            }
            #endregion
        }
        #endregion

        #region Propertys

        /// <summary>
        /// Gets the Position of the Cliping.
        /// </summary>
        public static Point Position
        {
            get { return new Point(myrect.Left, myrect.Top); }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Clips the cursor to an UIElement.
        /// </summary>
        /// <param name="element"></param>
        public static void OnUIElement(UIElement element)
        {
            uIEelement = element;
            myrect.Left = (int)(element.PointFromScreen(new Point(0, 0)).X * -1);
            myrect.Top = (int)(element.PointFromScreen(new Point(0, 0)).Y * -1);
            myrect.Right = (int)((element.PointFromScreen(new Point(0, 0)).X * -1) + element.RenderSize.Width);
            myrect.Bottom = (int)((element.PointFromScreen(new Point(0, 0)).Y * -1) + element.RenderSize.Height);
            ClipCursor(ref myrect);
        }

        /// <summary>
        /// Release the cliping of the cursor.
        /// </summary>
        public static void Release()
        {
            myrect.Left = 0;
            myrect.Top = 0;
            myrect.Right = (int)SystemParameters.PrimaryScreenWidth;
            myrect.Bottom = (int)SystemParameters.PrimaryScreenHeight;
            ClipCursor(ref myrect);
        }
        #endregion
    }

    /// <summary>
    /// Provides methodes for controling the mouse position by code. 
    /// </summary>
    internal class MouseControling
    {
        #region API - Methodes
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        private static extern int GetCursorPos(ref POINT lpPoint);
        [DllImport("gdi32.dll")]
        private static extern int GetPixel(int hdc, int nXPos, int nYPos);
        [DllImport("user32.dll")]
        private static extern int GetWindowDC(int hWnd);
        [DllImport("user32.dll")]
        private static extern int ReleaseDC(int hWnd, int hDC);
        #endregion

        #region Structs
        /// <summary>
        /// 
        /// </summary>
        private struct POINT
        {
            public uint x;
            public uint y;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the absolute mouse position.
        /// </summary>
        public static Point GetPosition
        {
            get
            {
                POINT point = new();
                GetCursorPos(ref point);
                Point pos = new()
                {
                    X = point.x,
                    Y = point.y
                };
                return pos;
            }
        }
        #endregion

        #region Methodes
        /// <summary>
        ///  Sets the Mouse position to an point on the assigned element.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="element"></param>
        public static void SetOnUIElement(Point point, UIElement element)
        {
            int x = (int)element.PointFromScreen(new Point(0, 0)).X * -1;
            int y = (int)element.PointFromScreen(new Point(0, 0)).Y * -1;
            SetCursorPos((int)(x + point.X), (int)(y + point.Y));
        }

        /// <summary>
        /// Returns the color of the pixel under the mouse.
        /// </summary>
        /// <returns></returns>
        public static Color PixelUnderMouse()
        {
            POINT point = new();
            GetCursorPos(ref point);
            Point pos = new()
            {
                X = point.x,
                Y = point.y
            };
            int lDC = GetWindowDC(0);
            int intColor = GetPixel(lDC, (int)pos.X, (int)pos.Y);
            ReleaseDC(0, lDC);
            byte[] argb = new byte[4];
            //A
            //argb[0] = (byte)((intColor >> 0x18) & 0xffL);
            //B
            argb[1] = (byte)(intColor & 0xffL);
            //G
            argb[2] = (byte)((intColor >> 8) & 0xffL);
            //B
            argb[3] = (byte)((intColor >> 0x10) & 0xffL);

            return Color.FromRgb(argb[1], argb[2], argb[3]);
        }
        /// <summary>
        /// Returns the color of the specified pixel on Window.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Color PixelColor(Point point)
        {
            int lDC = GetWindowDC(0);
            int intColor = GetPixel(lDC, (int)point.X, (int)point.Y);
            ReleaseDC(0, lDC);
            byte[] argb = new byte[4];
            //A
            //argb[0] = (byte)((intColor >> 0x18) & 0xffL);
            //B
            argb[1] = (byte)(intColor & 0xffL);
            //G
            argb[2] = (byte)((intColor >> 8) & 0xffL);
            //B
            argb[3] = (byte)((intColor >> 0x10) & 0xffL);

            return Color.FromRgb(argb[1], argb[2], argb[3]);
        }
        #endregion
    }
}