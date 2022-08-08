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

namespace Gaten.Language.Mercury.View
{
    /// <summary>
    /// MercuryTaskBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MercuryTaskBar : UserControl
    {
        #region Variable
        Window parentWindow => GetParentWindow() ?? Application.Current.MainWindow;

        #endregion

        #region Constructor
        public MercuryTaskBar()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

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
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                parentWindow.DragMove();
            }
        }
        #endregion

        private void NewButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void OpenButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void CutButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void CopyButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void PasteButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void UndoButton_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
