﻿using Gaten.Net.Wpf.Controls;
using Gaten.Stock.MercuryEditor.Editor;
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
        // Indentation
        // Folding
        // Keyword Description

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

        #region Window
        public MainWindow()
        {
            InitializeComponent();
            MercuryEditorEntire.InitStrategy(textEditor);
            textEditor.TextArea.IndentationStrategy = MercuryEditorEntire.IndentationStrategy;
            textEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            textEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;

            settingTimer.Elapsed += SettingTimer_Elapsed;
            settingTimer.Start();
        }

        private void SettingTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Settings.Default.Theme = Delegater.CurrentTheme.ToString();
            Settings.Default.Save();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.Theme = Delegater.CurrentTheme.ToString();
            Settings.Default.Save();
        }
        #endregion

        #region File
        private bool CheckSave()
        {
            if (!TmFile.IsSaved)
            {
                var message = new SimpleMessageBox("현재 파일을 저장하시겠습니까?", this, SimpleMessageBoxType.YesNoCancel);
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

        private void RefreshFileName()
        {
            TitleBar.FileNameText.Text = TmFile.TmName;
        }

        public void New()
        {
            if (!CheckSave())
            {
                return;
            }
            textEditor.Clear();
            TmFile.CurrentFilePath = string.Empty;
            TmFile.IsSaved = true;
            RefreshFileName();
        }

        public void Open()
        {
            if (!CheckSave())
            {
                return;
            }
            var data = TmFile.Open();
            if (data == string.Empty)
            {
                return;
            }
            textEditor.Text = data;
            TmFile.IsSaved = true;
            RefreshFileName();
        }

        public void FileClose()
        {
            if (!CheckSave())
            {
                return;
            }
            textEditor.Clear();
            TmFile.CurrentFilePath = string.Empty;
            TmFile.IsSaved = true;
            RefreshFileName();
        }

        public void Save()
        {
            TmFile.Save(textEditor.Text);
            RefreshFileName();
        }

        public void SaveAs()
        {
            TmFile.SaveAs(textEditor.Text);
            RefreshFileName();
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

        #region Model
        public void Inspection()
        {
            var inspector = new MercuryInspector();
            var result = inspector.Run(textEditor.Text);

            if (!result.IsOk)
            {
                EditorStatusText.Text = result.ErrorMessage;
                return;
            }

            EditorStatusText.Text = "검사 완료.";
        }

        public void InspectionRun()
        {
            var inspector = new MercuryInspector();
            var result = inspector.Run(textEditor.Text);

            if (!result.IsOk)
            {
                EditorStatusText.Text = result.ErrorMessage;
                return;
            }

            EditorStatusText.Text = "검사 완료. 실행합니다.";

            //BackTest
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
            RefreshFileName();
            MercuryEditorEntire.UpdateFolding(textEditor);
            EditorStatusText.Text = "";
        }
        #endregion
    }
}