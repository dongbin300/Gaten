using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gaten.Stock.MercuryEditor.View
{
    /// <summary>
    /// MercuryTaskBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MercuryTaskBar : UserControl
    {
        #region Variable
        Window parentWindow => GetParentWindow() ?? Application.Current.MainWindow;
        MainWindow mainWindow => (MainWindow)parentWindow;

        #endregion

        #region Constructor
        public MercuryTaskBar()
        {
            InitializeComponent();
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
        #endregion

        #region Event
        private void NewButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.New();
        }

        private void OpenButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Open();
        }

        private void SaveButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Save();
        }

        private void CutButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Cut();
        }

        private void CopyButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Copy();
        }

        private void PasteButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Paste();
        }

        private void UndoButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Undo();
        }

        private void RedoButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Redo();
        }

        private void WrapButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.ChangeWrap();
        }

        private void NumberButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.ChangeEnableLineNumber();
        }

        private void InspectionButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Inspection();
        }

        private void InspectionRunButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void FindReplaceButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void CommentButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Comment();
        }

        private void DecommentButton_Click(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Decomment();
        }

        private void ThemeButton_Click(object sender, MouseButtonEventArgs e)
        {
            Delegater.ChangeTheme();
        }
        #endregion
    }
}
