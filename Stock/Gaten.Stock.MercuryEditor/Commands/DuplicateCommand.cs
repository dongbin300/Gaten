using ICSharpCode.AvalonEdit;

using System;
using System.Windows.Input;

namespace Gaten.Stock.MercuryEditor.Commands
{
    public class DuplicateCommand : ICommand
    {
        private readonly TextEditor editor;
        public event EventHandler? CanExecuteChanged
        {
            add { }
            remove { }
        }

        public DuplicateCommand(TextEditor editor)
        {
            this.editor = editor;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? param)
        {
            int offset = editor.CaretOffset;
            var line = editor.Document.GetLineByOffset(offset);
            var location = editor.Document.GetLocation(offset);
            var lineText = editor.Document.GetText(line.Offset, line.Length);
            
            editor.Document.Insert(line.EndOffset, Environment.NewLine + lineText);
            editor.CaretOffset = line.NextLine.Offset + location.Column - 1;
        }
    }
}
