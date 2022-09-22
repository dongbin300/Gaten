using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Gaten.Language.Mercury.Editor
{
    public class MercuryCompletionWindow : CompletionWindowBase
    {
        readonly CompletionList completionList = new ();
        ToolTip toolTip = new ();

        /// <summary>
        /// Gets the completion list used in this completion window.
        /// </summary>
        public CompletionList CompletionList => completionList;

        /// <summary>
        /// Creates a new code completion window.
        /// </summary>
        public MercuryCompletionWindow(TextArea textArea) : base(textArea)
        {
            CloseAutomatically = true;
            SizeToContent = SizeToContent.Height;
            MaxHeight = 300;
            Width = 175;
            Content = completionList;
            switch (Delegater.CurrentTheme)
            {
                case Themes.Light:
                    Foreground = System.Windows.Media.Brushes.Black;
                    Background = System.Windows.Media.Brushes.White;
                    break;

                case Themes.Dark:
                    Foreground = System.Windows.Media.Brushes.White;
                    Background = System.Windows.Media.Brushes.Black;
                    break;
            }
            
            ResizeMode = ResizeMode.NoResize;
            MinHeight = 15;
            MinWidth = 30;

            CompletionList.ListBox.FontSize = 11d;
            CompletionList.ListBox.ItemContainerStyle = new Style(typeof(ListBoxItem));
            CompletionList.ListBox.ItemContainerStyle.Setters.Add(new Setter(HeightProperty, 18d));
            CompletionList.ListBox.ItemContainerStyle.Setters.Add(new Setter(PaddingProperty, new Thickness(0)));
            CompletionList.ListBox.ItemContainerStyle.Setters.Add(new Setter(MarginProperty, new Thickness(0)));


            toolTip.PlacementTarget = this;
            toolTip.Placement = PlacementMode.Right;
            toolTip.Closed += ToolTip_Closed;

            AttachEvents();
        }

        #region ToolTip handling
        void ToolTip_Closed(object? sender, RoutedEventArgs e)
        {
            if (toolTip != null)
            {
                toolTip.Content = null;
            }
        }

        void CompletionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = completionList.SelectedItem;
            if (item == null)
            {
                return;
            }
            object description = item.Description;
            if (description != null)
            {
                string descriptionText = description as string ?? string.Empty;
                if (descriptionText != null)
                {
                    toolTip.Content = new TextBlock
                    {
                        Text = descriptionText,
                        TextWrapping = TextWrapping.Wrap
                    };
                }
                else
                {
                    toolTip.Content = description;
                }
                toolTip.IsOpen = true;
            }
            else
            {
                toolTip.IsOpen = false;
            }
        }
        #endregion

        void CompletionList_InsertionRequested(object? sender, EventArgs e)
        {
            Close();
            var item = completionList.SelectedItem;
            if (item != null)
            {
                var word = MercuryEditor.GetCurrentWord(TextArea);
                var startOffset = TextArea.Caret.Offset - word.Length;
                item.Complete(TextArea, new AnchorSegment(TextArea.Document, startOffset, word.Length), e);
            }
        }

        void AttachEvents()
        {
            completionList.InsertionRequested += CompletionList_InsertionRequested;
            completionList.SelectionChanged += CompletionList_SelectionChanged;
            TextArea.Caret.PositionChanged += CaretPositionChanged;
            TextArea.MouseWheel += TextArea_MouseWheel;
            TextArea.PreviewTextInput += TextArea_PreviewTextInput;
        }

        protected override void DetachEvents()
        {
            completionList.InsertionRequested -= CompletionList_InsertionRequested;
            completionList.SelectionChanged -= CompletionList_SelectionChanged;
            TextArea.Caret.PositionChanged -= CaretPositionChanged;
            TextArea.MouseWheel -= TextArea_MouseWheel;
            TextArea.PreviewTextInput -= TextArea_PreviewTextInput;
            base.DetachEvents();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (toolTip != null)
            {
                toolTip.IsOpen = false;
                toolTip = default!;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!e.Handled)
            {
                completionList.HandleKey(e);
            }
        }

        void TextArea_PreviewTextInput(object? sender, TextCompositionEventArgs e)
        {
            e.Handled = RaiseEventPair(this, PreviewTextInputEvent, TextInputEvent,
                                       new TextCompositionEventArgs(e.Device, e.TextComposition));
        }

        void TextArea_MouseWheel(object? sender, MouseWheelEventArgs e)
        {
            e.Handled = RaiseEventPair(GetScrollEventTarget(),
                                       PreviewMouseWheelEvent, MouseWheelEvent,
                                       new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta));
        }

        UIElement GetScrollEventTarget()
        {
            if (completionList == null)
            {
                return this;
            }
            return completionList.ScrollViewer ?? completionList.ListBox ?? (UIElement)completionList;
        }

        /// <summary>
        /// Gets/Sets whether the completion window should close automatically.
        /// The default value is true.
        /// </summary>
        public bool CloseAutomatically { get; set; }

        /// <inheritdoc/>
        protected override bool CloseOnFocusLost => CloseAutomatically;

        /// <summary>
        /// When this flag is set, code completion closes if the caret moves to the
        /// beginning of the allowed range. This is useful in Ctrl+Space and "complete when typing",
        /// but not in dot-completion.
        /// Has no effect if CloseAutomatically is false.
        /// </summary>
        public bool CloseWhenCaretAtBeginning { get; set; }

        void CaretPositionChanged(object? sender, EventArgs e)
        {
            int offset = TextArea.Caret.Offset;
            if (offset == StartOffset)
            {
                if (CloseAutomatically && CloseWhenCaretAtBeginning)
                {
                    Close();
                }
                else
                {
                    completionList.SelectItem(string.Empty);
                }
                return;
            }
            if (offset < StartOffset || offset > EndOffset)
            {
                if (CloseAutomatically)
                {
                    Close();
                }
            }
            else
            {
                TextDocument document = TextArea.Document;
                if (document != null)
                {
                    completionList.SelectItem(document.GetText(StartOffset, offset - StartOffset));
                }
            }
        }
    }
}