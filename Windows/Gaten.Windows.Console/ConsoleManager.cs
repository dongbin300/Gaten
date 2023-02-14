using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Windows.Console
{
    public class ConsoleManager
    {
        private StackPanel mainPanel;
        private bool isBlock;
        private TextBlock blocks = default!;
        private List<string> inputLogs = new();
        private int inputPointer;
        public string BaseCamp = "Main";

        public ConsoleManager(StackPanel mainPanel)
        {
            this.mainPanel = mainPanel;
        }

        public void AddInputLog(string input)
        {
            inputLogs.Add(input);
            inputPointer = inputLogs.Count;
        }

        public string GetInputUp()
        {
            if (inputLogs.Count == 0)
            {
                return "";
            }

            inputPointer = Math.Max(0, inputPointer - 1);
            return inputLogs[inputPointer];
        }

        public string GetInputDown()
        {
            if (inputLogs.Count == 0)
            {
                return "";
            }

            inputPointer = Math.Min(inputLogs.Count - 1, inputPointer + 1);
            return inputLogs[inputPointer];
        }

        public void PrintBlock(string text)
        {
            if (!isBlock)
            {
                isBlock = true;
                blocks = new TextBlock()
                {
                    TextWrapping = TextWrapping.Wrap
                };
            }

            var run = new Run()
            {
                Text = text
            };
            blocks.Inlines.Add(run);
        }

        public void PrintBlock(string text, Brush foreground)
        {
            if (!isBlock)
            {
                isBlock = true;
                blocks = new TextBlock()
                {
                    TextWrapping = TextWrapping.Wrap
                };
            }

            var run = new Run()
            {
                Text = text,
                Foreground = foreground
            };
            blocks.Inlines.Add(run);
        }

        public void PrintBlock(string text, Brush foreground, Brush background)
        {
            if (!isBlock)
            {
                isBlock = true;
                blocks = new TextBlock()
                {
                    TextWrapping = TextWrapping.Wrap
                };
            }

            var run = new Run()
            {
                Text = text,
                Foreground = foreground,
                Background = background
            };
            blocks.Inlines.Add(run);
        }

        public void EndBlock()
        {
            mainPanel.Children.Add(blocks);
            isBlock = false;
        }

        public void Print(string text)
        {
            var textBlock = new TextBlock()
            {
                Text = text,
                TextWrapping = TextWrapping.Wrap
            };
            mainPanel.Children.Add(textBlock);
        }

        public void Print(string text, Brush foreground)
        {
            var textBlock = new TextBlock()
            {
                Text = text,
                TextWrapping = TextWrapping.Wrap,
                Foreground = foreground
            };
            mainPanel.Children.Add(textBlock);
        }

        public void Print(string text, Brush foreground, Brush background)
        {
            var textBlock = new TextBlock()
            {
                Text = text,
                TextWrapping = TextWrapping.Wrap,
                Foreground = foreground,
                Background = background
            };
            mainPanel.Children.Add(textBlock);
        }

        public void Input(string text, KeyEventHandler handler)
        {
            var panel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            var textBlock = new TextBlock()
            {
                Text = text + ">",
                TextWrapping = TextWrapping.Wrap
            };
            panel.Children.Add(textBlock);
            var textBox = new ConsoleCaretTextBox()
            {
                Height = 20
            };
            textBox.PreviewKeyDown += handler;
            panel.Children.Add(textBox);
            mainPanel.Children.Add(panel);
        }
    }
}
