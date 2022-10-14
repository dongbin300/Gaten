using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Controls;
using Gaten.Stock.MercuryEditor.Commands;
using Gaten.Stock.MercuryEditor.Editor;
using Gaten.Stock.MercuryEditor.Enums;
using Gaten.Stock.MercuryEditor.Inspection;
using Gaten.Stock.MercuryEditor.IO;

using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Editing;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Gaten.Stock.MercuryEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         * #v1
         * #binancefutures
         * #backtest [#mocktrade | #realtrade]
         * 
         * asset = 10000
         * period = 2022,7,17,0,0:0,0,7,0,0
         * interval = 5m
         * target = SOLUSDT
         * scenario1.strategy1.signal = rsi < 30
         * scenario1.strategy1.order = long,market,1.0
         * scenario1.strategy2.signal = rsi > 70
         * scenario1.strategy2.order = short,market,1.0
         * scenario1.strategy3.signal = SOLUSDT.poe < -20%
         * scenario1.strategy3.order = long,market,SOLUSDT.amount * 1
         */

        System.Timers.Timer settingTimer = new(5000);
        MercuryCompletionWindow? completionWindow;

        ICommand newCommand;
        ICommand openCommand;
        ICommand saveCommand;
        ICommand saveAsCommand;
        ICommand closeCommand;
        ICommand duplicateCommand;
        ICommand fullScreenCommand;

        #region Window
        public MainWindow()
        {
            InitializeComponent();
            MercuryEditorEntire.InitCommand(textEditor);
            MercuryEditorEntire.InitStrategy(textEditor);
            textEditor.TextArea.IndentationStrategy = MercuryEditorEntire.IndentationStrategy;
            textEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            textEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;

            settingTimer.Elapsed += SettingTimer_Elapsed;
            settingTimer.Start();

            Delegater.RefreshFileName = () => TitleBar.FileNameText.Text = TmFile.TmName;
            Delegater.CheckSave = CheckSave;
            Delegater.SetEditorText = (text) => textEditor.Text = text;
            Delegater.SetFullScreen = () =>
            {
                if (TitleBarRow.Height.Value > 0)
                {
                    TitleBar.FullScreen();
                }
                else
                {
                    TitleBar.DefaultScreen();
                }
            };
            newCommand = new NewCommand(textEditor);
            openCommand = new OpenCommand(textEditor);
            saveCommand = new SaveCommand(textEditor);
            saveAsCommand = new SaveAsCommand(textEditor);
            closeCommand = new CloseCommand(textEditor);
            duplicateCommand = new DuplicateCommand(textEditor);
            fullScreenCommand = new FullScreenCommand();
        }

        private void SettingTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Settings.Default.Theme = Delegater.CurrentTheme.ToString();
            Settings.Default.Language = Delegater.CurrentLanguage.ToString();
            Settings.Default.Save();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.Theme = Delegater.CurrentTheme.ToString();
            Settings.Default.Language = Delegater.CurrentLanguage.ToString();
            Settings.Default.Save();
        }
        #endregion

        #region File
        private bool CheckSave()
        {
            if (!TmFile.IsSaved)
            {
                var message = new SimpleMessageBox(Delegater.CurrentLanguageDictionary["TmFileCheckSave"].ToString(), this, SimpleMessageBoxType.YesNoCancel);
                switch (message.ShowDialog())
                {
                    case SimpleMessageBoxResult.Yes:
                        TmFile.Save(textEditor.Text);
                        return true;

                    case SimpleMessageBoxResult.No:
                        return true;

                    case SimpleMessageBoxResult.Cancel:
                        return false;
                }
            }

            return true;
        }

        public void New()
        {
            newCommand.Execute(null);
        }

        public void Open()
        {
            openCommand.Execute(null);
        }

        public void FileClose()
        {
            closeCommand.Execute(null);
        }

        public void Save()
        {
            saveCommand.Execute(null);
        }

        public void SaveAs()
        {
            saveAsCommand.Execute(null);
        }

        public void Escape()
        {
            if (!CheckSave())
            {
                return;
            }
            Application.Current.Shutdown();
        }
        #endregion

        #region Edit
        public void OpenFindReplace()
        {
            
        }

        public void CloseFindReplace()
        {

        }

        public void Undo()
        {
            textEditor.Undo();
        }

        public void Redo()
        {
            textEditor.Redo();
        }

        public void Cut()
        {
            textEditor.Cut();
        }

        public void Copy()
        {
            textEditor.Copy();
        }

        public void Paste()
        {
            textEditor.Paste();
        }

        public void Duplicate()
        {
            duplicateCommand.Execute(null);
        }

        public void Delete()
        {
            textEditor.Delete();
        }

        public void AllSelect()
        {
            textEditor.SelectAll();
        }

        public void Comment()
        {
            var selectionFirstLine = textEditor.Document.GetLineByOffset(textEditor.SelectionStart);
            var selectionLastLine = textEditor.Document.GetLineByOffset(textEditor.SelectionStart + textEditor.SelectionLength);
            for (int i = selectionFirstLine.LineNumber; i <= selectionLastLine.LineNumber; i++)
            {
                var offset = textEditor.Document.GetOffset(i, 0);
                textEditor.Document.Insert(offset, "//");
            }
        }

        public void Decomment()
        {
            var selectionFirstLine = textEditor.Document.GetLineByOffset(textEditor.SelectionStart);
            var selectionLastLine = textEditor.Document.GetLineByOffset(textEditor.SelectionStart + textEditor.SelectionLength);
            for (int i = selectionFirstLine.LineNumber; i <= selectionLastLine.LineNumber; i++)
            {
                var offset = textEditor.Document.GetOffset(i, 0);
                var line = textEditor.Document.GetLineByOffset(offset);
                var lineText = textEditor.Document.GetText(line.Offset, line.Length);
                var newLineText = lineText.Replace("//", "");
                textEditor.Document.Replace(new SelectionSegment(line.Offset, line.EndOffset), newLineText);
            }
        }
        #endregion

        #region View
        public void SetFullScreen()
        {
            fullScreenCommand.Execute(null);
        }
        #endregion

        #region Model
        public void Inspection()
        {
            Save();

            var inspector = new MercuryInspector();
            var result = inspector.Run(textEditor.Text);

            if (!result.IsOk)
            {
                EditorStatusText.Text = result.ErrorMessage;
                return;
            }

            EditorStatusText.Text = Delegater.CurrentLanguageDictionary["InspectionComplete"].ToString();
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void AddStrategy()
        {
            textEditor.Document.Insert(textEditor.CaretOffset, "scenario1.strategy1.signal = ");
        }
        #endregion

        #region Settings
        public void SetWrap(bool wrap)
        {
            textEditor.WordWrap = wrap;
            Settings.Default.TextWrap = wrap;
            Settings.Default.Save();
        }

        public void ChangeWrap()
        {
            textEditor.WordWrap = !textEditor.WordWrap;
            Settings.Default.TextWrap = textEditor.WordWrap;
            Settings.Default.Save();
        }

        public void SetEnableLineNumber(bool enable)
        {
            textEditor.ShowLineNumbers = enable;
            Settings.Default.LineNumber = enable;
            Settings.Default.Save();
        }

        public void ChangeEnableLineNumber()
        {
            textEditor.ShowLineNumbers = !textEditor.ShowLineNumbers;
            Settings.Default.LineNumber = textEditor.ShowLineNumbers;
            Settings.Default.Save();
        }
        #endregion

        #region Text Editor
        void textEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (sender is not TextArea textArea)
            {
                return;
            }

            if (e.Text.Length > 0)
            {
                var word = MercuryEditorEntire.GetCurrentWord(textArea);
                if (string.IsNullOrEmpty(word))
                {
                    if (completionWindow != null)
                    {
                        completionWindow.Close();
                    }
                    return;
                }
                var similarData = MercuryCompletionDictionary.GetSimilarData(word);
                if (similarData.Length == 0)
                {
                    if (completionWindow != null)
                    {
                        completionWindow.Close();
                    }
                    return;
                }

                completionWindow = new MercuryCompletionWindow(textEditor.TextArea);
                IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;

                foreach (var item in similarData)
                {
                    data.Add(new MercuryCompletionData(item));
                }
                completionWindow.Show();
                completionWindow.CompletionList.ListBox.SelectIndex(0);
                completionWindow.Closed += delegate
                {
                    completionWindow = null;
                };
            }
        }

        void textEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
        }

        private void textEditor_TextChanged(object sender, System.EventArgs e)
        {
            TmFile.IsSaved = false;
            Delegater.RefreshFileName();
            MercuryEditorEntire.UpdateFolding(textEditor);
            EditorStatusText.Text = "";
        }
        #endregion

        
    }
}
