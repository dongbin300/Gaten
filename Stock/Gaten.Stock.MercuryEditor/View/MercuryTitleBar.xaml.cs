using Gaten.Net.Wpf;

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
        Geometry NormalButtonGeometry;
        Geometry MaximizeButtonGeometry;
        public double prevLeft = 0;
        public double prevTop = 0;
        public double prevWidth = 0;
        public double prevHeight = 0;

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

            NormalButtonGeometry = Geometry.Parse("M1 5 H11 V15 H1 V4 M5 4 V1 H15 V11 H11");
            MaximizeButtonGeometry = Geometry.Parse("M3 3 H12 V12 H3 V2");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (parentWindow == null)
            {
                return;
            }

            switch (Delegater.CurrentTheme)
            {
                case Themes.Light:
                    SettingsThemeLightMenuItem.IsChecked = true;
                    break;

                case Themes.Dark:
                    SettingsThemeDarkMenuItem.IsChecked = true;
                    break;

                default:
                    break;
            }

            //TitleText.Text = parentWindow.Title ?? Title;
            IconImage.Source = parentWindow.Icon ?? Icon;
            HelpInfoImage.Source = parentWindow.Icon ?? Icon;
            MaximizePath.Data = MaximizeButtonGeometry;
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
            // Manual Maximizing
            prevLeft = parentWindow.Left;
            prevTop = parentWindow.Top;
            prevWidth = parentWindow.Width;
            prevHeight = parentWindow.Height;
            parentWindow.Left = 0;
            parentWindow.Top = 0;
            parentWindow.Width = WindowsSystem.ScreenWidth;
            parentWindow.Height = WindowsSystem.ScreenNoTaskBarHeight;
            MaximizePath.Data = NormalButtonGeometry;

            NormalSizeMenuItem.IsEnabled = true;
            MoveMenuItem.IsEnabled = false;
            MinimizeMenuItem.IsEnabled = true;
            MaximizeMenuItem.IsEnabled = false;
            EscapeMenuItem.IsEnabled = true;
        }

        void Normalize()
        {
            // Manual Normalizing
            parentWindow.Left = prevLeft;
            parentWindow.Top = prevTop;
            parentWindow.Width = prevWidth;
            parentWindow.Height = prevHeight;
            MaximizePath.Data = MaximizeButtonGeometry;

            NormalSizeMenuItem.IsEnabled = false;
            MoveMenuItem.IsEnabled = true;
            MinimizeMenuItem.IsEnabled = true;
            MaximizeMenuItem.IsEnabled = true;
            EscapeMenuItem.IsEnabled = true;
        }

        public void FullScreen()
        {
            prevLeft = parentWindow.Left;
            prevTop = parentWindow.Top;
            prevWidth = parentWindow.Width;
            prevHeight = parentWindow.Height;
            parentWindow.Left = 0;
            parentWindow.Top = 0;
            parentWindow.Width = WindowsSystem.ScreenWidth;
            parentWindow.Height = WindowsSystem.ScreenHeight;
            //MaximizePath.Data = NormalButtonGeometry;

            mainWindow.TitleBarRow.Height = new GridLength(0);
            NormalSizeMenuItem.IsEnabled = true;
            MoveMenuItem.IsEnabled = false;
            MinimizeMenuItem.IsEnabled = true;
            MaximizeMenuItem.IsEnabled = false;
            EscapeMenuItem.IsEnabled = true;
        }

        public void DefaultScreen()
        {
            parentWindow.Left = prevLeft;
            parentWindow.Top = prevTop;
            parentWindow.Width = prevWidth;
            parentWindow.Height = prevHeight;
            //MaximizePath.Data = MaximizeButtonGeometry;

            mainWindow.TitleBarRow.Height = new GridLength(30);
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
            if(MaximizePath.Data == NormalButtonGeometry)
            {
                Normalize();
            }
            else
            {
                Maximize();
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
            Cursor = Cursors.Arrow;
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IconImageContextMenu.IsSubmenuOpen = false;
            if (MaximizePath.Data == NormalButtonGeometry)
            {
                Normalize();
            }
            else
            {
                Maximize();
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

        #region Edit
        private void EditFindReplaceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenFindReplace();
        }

        private void EditUndoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Undo();
        }

        private void EditRedoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Redo();
        }

        private void EditCutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Cut();
        }

        private void EditCopyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Copy();
        }

        private void EditPasteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Paste();
        }

        private void EditDuplicateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Duplicate();
        }

        private void EditDeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Delete();
        }

        private void EditAllSelectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.AllSelect();
        }

        private void EditCommentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Comment();
        }

        private void EditDecommentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Decomment();
        }
        #endregion  

        #region View
        private void ViewFullScreenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.SetFullScreen();
        }
        #endregion

        #region Model
        private void ModelInspectionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Inspection();
        }

        private void ModelAddScenarioMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ModelAddStrategyMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Settings
        private void SettingsWrapMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.SetWrap(SettingsWrapMenuItem.IsChecked);
        }

        private void SettingsNumberMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.SetEnableLineNumber(SettingsNumberMenuItem.IsChecked);
        }

        private void SettingsThemeLightMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SettingsThemeDarkMenuItem.IsChecked = false;
            if (Delegater.CurrentTheme != Themes.Light)
            {
                Delegater.ChangeTheme();
            }
        }

        private void SettingsThemeDarkMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SettingsThemeLightMenuItem.IsChecked = false;
            if (Delegater.CurrentTheme != Themes.Dark)
            {
                Delegater.ChangeTheme();
            }
        }

        #endregion

        #endregion

        

        
    }
}
