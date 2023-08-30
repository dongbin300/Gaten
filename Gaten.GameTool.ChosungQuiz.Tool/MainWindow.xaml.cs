using Gaten.Net.Language.Korean;

using Microsoft.Win32;

using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Gaten.GameTool.ChosungQuiz.Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() ?? false)
            {
                var fileName = dialog.FileName;
                var fileDirectory = Path.GetDirectoryName(fileName);
                var answers = File.ReadAllLines(fileName);
                var questions = new List<string>();
                foreach (var answer in answers)
                {
                    var koreanSentence = new KoreanSentence(answer);
                    questions.Add(koreanSentence.ToChosung());
                }
                File.WriteAllLines(fileDirectory + "\\" + "question.txt", questions);
            }
        }
    }
}
