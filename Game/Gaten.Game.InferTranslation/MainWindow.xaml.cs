using Gaten.Net.Network;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace Gaten.Game.InferTranslation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentAnswer = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            GenerateProblem();
        }

        private void GenerateProblem()
        {
            try
            {
                WebCrawler.Open("https://randomword.com/sentence");
                var node = WebCrawler.SelectNode("div", "id", "random_word");
                currentAnswer = node.InnerText.Trim();
                string url = "https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto" + "&tl=ko&dt=t&dj=1&q=" + currentAnswer;
                WebCrawler.SetUrl(url);
                var result = JsonSerializer.Deserialize<Translation_JsonObject>(WebCrawler.Source) ?? default!;
                var translatedText = string.Join(" ", result.sentences.Select(s => s.trans));

                TextListBox.Items.Add(translatedText);
                TextListBox.SelectedIndex = TextListBox.Items.Count - 1;
                TextListBox.ScrollIntoView(TextListBox.Items.Count - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (InputTextBox.Text.Length < 1)
                {
                    MessageBox.Show("입력해 주세요");
                    return;
                }

                Submit();
                GenerateProblem();
            }
        }

        private void Submit()
        {
            try
            {
                string input = InputTextBox.Text;
                TextListBox.Items.Add("입력: " + input);
                InputTextBox.Clear();

                var result = Check(input, currentAnswer);
                var score = result.Item1 - result.Item3;
                string resultString = $"{(int)((double)100 * score / result.Item2)}점 ({score} / {result.Item2})";
                TextListBox.Items.Add("정답: " + currentAnswer);
                TextListBox.Items.Add("결과: " + resultString);
                TextListBox.SelectedIndex = TextListBox.Items.Count - 1;
                TextListBox.ScrollIntoView(TextListBox.Items.Count - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private (int, int, int) Check(string input, string answer)
        {
            try
            {
                var answerSegments = answer.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var inputSegments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var wordCount = answerSegments.Length;
                int score = 0;
                int deduction = Math.Abs(answerSegments.Length - inputSegments.Length) / 3;
                foreach(var segment in answerSegments)
                {
                    if (inputSegments.Contains(segment))
                    {
                        score++;
                    }
                }

                return (score, wordCount, deduction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return (0, 0, 0);
        }

        public record ModelSpecification();

        public record ModelTracking(string checkpoint_md5, string launch_doc);

        public record TranslationEngineDebugInfo(ModelTracking model_tracking);

        public record Sentence
            (string trans, string orig, int backend, IList<ModelSpecification> model_specification, IList<TranslationEngineDebugInfo> translation_engine_debug_info);

        public record Spell();

        public record Translation_JsonObject(IList<Sentence> sentences, string src, Spell spell);
    }
}
