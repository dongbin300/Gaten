using Gaten.Stock.MercuryEditor.IO;

using ICSharpCode.AvalonEdit;

using System;
using System.Windows.Input;

namespace Gaten.Stock.MercuryEditor.Commands
{
    public class OpenCommand : ICommand
    {
        private readonly TextEditor editor;
        public event EventHandler? CanExecuteChanged
        {
            add { }
            remove { }
        }

        public OpenCommand(TextEditor editor)
        {
            this.editor = editor;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? param)
        {
            if (!Delegater.CheckSave())
            {
                return;
            }
            var data = TmFile.Open();
            if (data == string.Empty)
            {
                return;
            }
            Delegater.SetEditorText(data);
            TmFile.IsSaved = true;
            Delegater.RefreshFileName();
        }
    }
}
