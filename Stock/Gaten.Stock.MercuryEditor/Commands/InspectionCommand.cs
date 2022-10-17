using Gaten.Stock.MercuryEditor.Inspection;
using Gaten.Stock.MercuryEditor.IO;

using ICSharpCode.AvalonEdit;

using System;
using System.Windows.Input;

namespace Gaten.Stock.MercuryEditor.Commands
{
    public class InspectionCommand : ICommand
    {
        private readonly TextEditor editor;
        public event EventHandler? CanExecuteChanged
        {
            add { }
            remove { }
        }

        public InspectionCommand(TextEditor editor)
        {
            this.editor = editor;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            new SaveCommand(editor).Execute(parameter);

            var inspector = new MercuryInspector();
            var result = inspector.Run(editor.Text);

            if (!result.IsOk)
            {
                Delegater.SetEditorStatusText(result.ErrorMessage);
                return;
            }

            Delegater.SetEditorStatusText(Delegater.CurrentLanguageDictionary["InspectionComplete"].ToString());

            if (!Delegater.CheckSave())
            {
                return;
            }
            editor.Clear();
            TmFile.CurrentFilePath = string.Empty;
            TmFile.IsSaved = true;
            Delegater.RefreshFileName();
        }
    }
}
