using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gaten.Image.PlutoEditorWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool moveMode = false;
        BitmapImage NormalButtonImage;
        BitmapImage MaximizeButtonImage;

        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        #region This Method
        void Init()
        {
            NormalButtonImage = new BitmapImage(new Uri("pack://application:,,,/Gaten.Image.PlutoEditorWpf;component/Resources/normal-button.png"));
            MaximizeButtonImage = new BitmapImage(new Uri("pack://application:,,,/Gaten.Image.PlutoEditorWpf;component/Resources/maximize-button.png"));

            Normalize();
        }

        void Maximize()
        {
            WindowState = WindowState.Maximized;
            NormalButton.Source = NormalButtonImage;

            NormalSizeMenuItem.IsEnabled = true;
            MoveMenuItem.IsEnabled = false;
            //ChangeSizeMenuItem.IsEnabled = false;
            MinimizeMenuItem.IsEnabled = true;
            MaximizeMenuItem.IsEnabled = false;
            EscapeMenuItem.IsEnabled = true;
        }

        void Normalize()
        {
            WindowState = WindowState.Normal;
            NormalButton.Source = MaximizeButtonImage;

            NormalSizeMenuItem.IsEnabled = false;
            MoveMenuItem.IsEnabled = true;
            //ChangeSizeMenuItem.IsEnabled = true;
            MinimizeMenuItem.IsEnabled = true;
            MaximizeMenuItem.IsEnabled = true;
            EscapeMenuItem.IsEnabled = true;
        }

        void Minimize()
        {
            WindowState = WindowState.Minimized;
        }

        static void Escape()
        {
            Application.Current.MainWindow.Close();
        }

        void MaximizeOrNormalWindow()
        {
            if (WindowState == WindowState.Maximized)
            {
                Normalize();
            }
            else
            {
                Maximize();
            }
        }
        #endregion

        #region Window Event
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (moveMode && e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
            moveMode = false;
            Cursor = Cursors.Arrow;
        }
        #endregion

        #region TitleBar Event

        #region PlutoIcon Event
        private void PlutoIconImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlutoIconImageContextMenu.IsOpen = true;
        }

        private void NormalSizeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Normalize();
        }

        private void MoveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            moveMode = true;
            Cursor = Cursors.SizeAll;
        }

        private void ChangeSizeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void MinimizeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Minimize();
        }

        private void MaximizeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Maximize();
        }

        private void EscapeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Escape();
        }
        #endregion

        #region Menu-File Event
        private void FileNewAnimationMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileNewImageMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileOpenMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileSaveMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileEscapeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Escape();
        }
        #endregion

        #region Etc Event
        private void MenuBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                MaximizeOrNormalWindow();
            }

            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
                // TODO 메뉴바를 드래그해서 이전 크기로 가는 건 추후 개발
                //if(WindowState == WindowState.Maximized)
                //{
                //    Normalize();
                //    if(e.GetPosition(this).X + Width/2 > System.Windows.SystemParameters.PrimaryScreenWidth)
                //    {
                //        Left = System.Windows.SystemParameters.PrimaryScreenWidth - Width;
                //        Top = 0;
                //    }
                //    else
                //    {
                //        Left = e.GetPosition(this).X - Width / 2;
                //        Top = 0;
                //    }

                //    //Top = System.Windows.SystemParameters.PrimaryScreenHeight - Height;
                //}
            }
        }

        private void MinimizeButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Minimize();
        }

        private void NormalButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaximizeOrNormalWindow();
        }

        private void ExitButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Escape();
        }
        #endregion

        #endregion
    }
}
