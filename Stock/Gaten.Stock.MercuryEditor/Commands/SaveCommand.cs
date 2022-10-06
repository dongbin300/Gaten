﻿using Gaten.Stock.MercuryEditor.IO;

using ICSharpCode.AvalonEdit;

using System;
using System.Windows.Input;

namespace Gaten.Stock.MercuryEditor.Commands
{
    public class SaveCommand : ICommand
    {
        private readonly TextEditor editor;
        public event EventHandler? CanExecuteChanged
        {
            add { }
            remove { }
        }

        public SaveCommand(TextEditor editor)
        {
            this.editor = editor;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? param)
        {
            TmFile.Save(editor.Text);
            Delegater.RefreshFileName();
        }
    }
}
