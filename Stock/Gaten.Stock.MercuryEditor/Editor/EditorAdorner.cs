using ICSharpCode.AvalonEdit.Editing;

using System.Windows.Controls;
using System.Windows.Documents;

namespace Gaten.Stock.MercuryEditor.Editor
{
    public class EditorAdorner : Adorner
    {
        public EditorAdorner(TextArea textArea, UserControl control) : base(textArea)
        {
            AddVisualChild(control);
        }
    }
}
