using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Gaten.Stock.MercuryEditor.View
{
    /// <summary>
    /// MercuryTitleBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MercuryTitleBar : UserControl
    {
        #region Variable
        Window parentWindow => GetParentWindow() ?? Application.Current.MainWindow;
        MainWindow mainWindow => (MainWindow)parentWindow;
        bool moveMode = false;
        Geometry NormalButtonGeometry;
        Geometry MaximizeButtonGeometry;

        private static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MercuryTitleBar), new PropertyMetadata(""));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        private static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(MercuryTitleBar), new PropertyMetadata(new BitmapImage()));
        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set
            {
                SetValue(IconProperty, value);
            }
        }
        #endregion

        #region Constructor
        public MercuryTitleBar()
        {
            InitializeComponent();

            NormalButtonGeometry = Geometry.Parse("M10 16 L24 16 L24 30 L10 30 L10 15 M12 16 L12 12 L28 12 L28 28 L24 28");
            MaximizeButtonGeometry = Geometry.Parse("M13 13 L27 13 L27 27 L13 27 L13 12");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (parentWindow == null)
            {
                return;
            }

            //TitleText.Text = parentWindow.Title ?? Title;
            IconImage.Source = parentWindow.Icon ?? Icon;
            MaximizePath.Data = parentWindow.WindowState == WindowState.Maximized ? NormalButtonGeometry : MaximizeButtonGeometry;
        }
        #endregion

        #region Method
        private Window? GetParentWindow()
        {
            var parentWindow = Window.GetWindow(this);
            if (parentWindow == null)
            {
                return null;
            }

            return parentWindow;
        }

        void Maximize()
        {
            parentWindow.WindowState = WindowState.Maximized;
            MaximizePath.Data = NormalButtonGeometry;

            NormalSizeMenuItem.IsEnabled = true;
            MoveMenuItem.IsEnabled = false;
            MinimizeMenuItem.IsEnabled = true;
            MaximizeMenuItem.IsEnabled = false;
            EscapeMenuItem.IsEnabled = true;
        }

        void Normalize()
        {
            parentWindow.WindowState = WindowState.Normal;
            MaximizePath.Data = MaximizeButtonGeometry;

            NormalSizeMenuItem.IsEnabled = false;
            MoveMenuItem.IsEnabled = true;
            MinimizeMenuItem.IsEnabled = true;
            MaximizeMenuItem.IsEnabled = true;
            EscapeMenuItem.IsEnabled = true;
        }

        void Minimize()
        {
            parentWindow.WindowState = WindowState.Minimized;
        }
        #endregion

        #region Event
        private void CloseButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Escape();
        }

        private void MaximizeButton_Click(object sender, MouseButtonEventArgs e)
        {
            switch (parentWindow.WindowState)
            {
                case WindowState.Maximized:
                    Normalize();
                    break;
                default:
                    Maximize();
                    break;
            }
        }

        private void MinimizeButton_Click(object sender, MouseButtonEventArgs e)
        {
            Minimize();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                try
                {
                    parentWindow.DragMove();
                }
                catch (InvalidOperationException)
                {
                }
            }
            moveMode = false;
            Cursor = Cursors.Arrow;
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IconImageContextMenu.IsSubmenuOpen = false;
            switch (parentWindow.WindowState)
            {
                case WindowState.Maximized:
                    Normalize();
                    break;
                default:
                    Maximize();
                    break;
            }
        }

        private void NormalSizeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            IconImageContextMenu.IsSubmenuOpen = false;
            Normalize();
        }

        private void MoveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            IconImageContextMenu.IsSubmenuOpen = false;
            moveMode = true;
            Cursor = Cursors.SizeAll;
        }

        private void ChangeSizeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            IconImageContextMenu.IsSubmenuOpen = false;
        }

        private void MinimizeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            IconImageContextMenu.IsSubmenuOpen = false;
            Minimize();
        }

        private void MaximizeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            IconImageContextMenu.IsSubmenuOpen = false;
            Maximize();
        }

        private void EscapeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            IconImageContextMenu.IsSubmenuOpen = false;
            mainWindow.Escape();
        }

        private void IconImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IconImageContextMenu.IsSubmenuOpen = !IconImageContextMenu.IsSubmenuOpen;
        }
        #endregion

        #region MenuItem

        #region File
        private void FileNewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.New();
        }

        private void FileOpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Open();
        }

        private void FileCloseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.FileClose();
        }

        private void FileSaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Save();
        }

        private void FileSaveAsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.SaveAs();
        }

        private void FileEscapeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Escape();
        }
        #endregion

        #region Model
        private void ModelInspectionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Inspection();
        }
        #endregion

        #endregion


    }
}
