using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Indentation;

using System.IO;
using System.Xml;

namespace Gaten.Stock.MercuryEditor.Editor
{
    public class MercuryEditorEntire
    {
        public static IHighlightingDefinition MercuryLightHighlighting;
        public static IHighlightingDefinition MercuryDarkHighlighting;
        public static FoldingManager FoldingManager;
        public static XmlFoldingStrategy FoldingStrategy;
        public static DefaultIndentationStrategy IndentationStrategy;
        private static char[] WordSeparator =
        {
            ' ', '=', ';', '/'
        };

        public static void Init()
        {
            using (Stream? s = typeof(MainWindow).Assembly.GetManifestResourceStream("Gaten.Stock.MercuryEditor.Editor.MercuryHighlighting-Light.xshd"))
            {
                using XmlReader reader = new XmlTextReader(s);
                MercuryLightHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(reader, HighlightingManager.Instance);
            }
            using (Stream? s = typeof(MainWindow).Assembly.GetManifestResourceStream("Gaten.Stock.MercuryEditor.Editor.MercuryHighlighting-Dark.xshd"))
            {
                using XmlReader reader = new XmlTextReader(s);
                MercuryDarkHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(reader, HighlightingManager.Instance);
            }
            HighlightingManager.Instance.RegisterHighlighting("Mercury_Light", new string[] { ".tm" }, MercuryLightHighlighting);
            HighlightingManager.Instance.RegisterHighlighting("Mercury_Dark", new string[] { ".tm" }, MercuryDarkHighlighting);
        }

        public static void InitStrategy(TextEditor textEditor)
        {
            FoldingManager = FoldingManager.Install(textEditor.TextArea);
            FoldingStrategy = new XmlFoldingStrategy();
            IndentationStrategy = new DefaultIndentationStrategy();
        }

        public static void UpdateFolding(TextEditor textEditor)
        {
            FoldingStrategy.UpdateFoldings(FoldingManager, textEditor.Document);
        }

        public static string GetCurrentWord(TextArea textArea)
        {
            int i;
            int j;
            var caretOffset = textArea.Caret.Offset;
            
            for (i = caretOffset - 1; i > 0; i--)
            {
                if (textArea.Document.Text[i] == ' ')
                {
                    i++;
                    break;
                }
            }

            for (j = caretOffset - 1; j < textArea.Document.Text.Length; j++)
            {
                if (textArea.Document.Text[j] == ' ')
                {
                    break;
                }
            }

            return i > j ? string.Empty : textArea.Document.Text[i..j];
        }
    }
}
