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

namespace Gaten.Windows.Console
{
    /// <summary>
    /// ConsoleCaretTextBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ConsoleCaretTextBox : UserControl
    {
        public ConsoleCaretTextBox()
        {
            InitializeComponent();

            Focusable = true;

            CustomTextBox.SelectionChanged += (sender, e) => MoveCustomCaret();
            CustomTextBox.GotFocus += (sender, e) => Caret.Visibility = Visibility.Visible;
            CustomTextBox.LostFocus += (sender, e) => Caret.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Moves the custom caret on the canvas.
        /// </summary>
        private void MoveCustomCaret()
        {
            var caretLocation = CustomTextBox.GetRectFromCharacterIndex(CustomTextBox.CaretIndex).Location;

            if (!double.IsInfinity(caretLocation.X))
            {
                Canvas.SetLeft(Caret, caretLocation.X);
            }

            if (!double.IsInfinity(caretLocation.Y))
            {
                Canvas.SetTop(Caret, caretLocation.Y);
            }
        }

        public string GetText()
        {
            return CustomTextBox.Text;
        }

        public void SetText(string text)
        {
            CustomTextBox.Text = text;
            CustomTextBox.CaretIndex = CustomTextBox.Text.Length;
            MoveCustomCaret();
        }
    }
}
