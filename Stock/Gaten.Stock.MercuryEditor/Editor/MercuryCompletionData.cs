using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;

using System;

namespace Gaten.Stock.MercuryEditor.Editor
{
    internal class MercuryCompletionData : ICompletionData
    {
        public System.Windows.Media.ImageSource? Image => null;
        public string Text { get; private set; }
        public object Content => Text;
        public object Description => "Description for " + Text;
        public double Priority => 0;

        public MercuryCompletionData(string text)
        {
            Text = text;
        }

        public void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
        {
            textArea.Document.Replace(completionSegment, Text);
        }
    }
}
