using Gaten.Net.Network;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Gaten.GameTool.NemoNemoLogic.NnlSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int currentIndex;
        int maxIndex;

        public MainWindow()
        {
            InitializeComponent();
        }

        private NnlBoard ToNnlBoard(PixelStateEnum[,] pixel)
        {
            var result = new NnlBoard(pixel.GetLength(0), pixel.GetLength(1));

            for (int i = 0; i < pixel.GetLength(0); i++)
            {
                for (int j = 0; j < pixel.GetLength(1); j++)
                {
                    result.Data[i, j] = pixel[i, j] switch
                    {
                        PixelStateEnum.ON => true,
                        _ => false,
                    };
                }
            }

            return result;
        }

        private void SolveTestButton_Click(object sender, RoutedEventArgs e)
        {
            var questionText =
                "1 1\n" +
                "1 1 1\n" +
                "1 1\n" +
                "1 1\n" +
                "1\n" +
                "\n" +
                "2\n" +
                "1 1\n" +
                "1 1\n" +
                "1 1\n" +
                "2\n";

            var question = new NnlQuestion(questionText);
            var solver = new NnlSolver();
            solver.Solve(question);

            var nnlBoard = ToNnlBoard(solver.pixelStates);
            var nnlBoards = new List<NnlBoard>() { nnlBoard };

            BoardControl.Boards = nnlBoards;
            currentIndex = 0;
            maxIndex = 0;
            PageText.Text = "1 / 1";
            BoardControl.Refresh(currentIndex);
        }

        private void SolveTealButton_Click(object sender, RoutedEventArgs e)
        {
            var problem = GetProblemFromWebSite();
            if (problem == null)
            {
                return;
            }
            var tealProblem = problem.ToTealNnlProblem();
            Clipboard.SetText(tealProblem.Json);
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            var solver = new NnlSolver();
            var question = GetQuestionFromWebSite();
            if (question == null)
            {
                return;
            }
            solver.Solve(question);
            var nnlBoards = new List<NnlBoard>() { ToNnlBoard(solver.pixelStates) };

            BoardControl.Boards = nnlBoards;
            currentIndex = 0;
            maxIndex = 0;
            PageText.Text = "1 / 1";
            BoardControl.Refresh(currentIndex);
        }

        private NnlProblem? GetProblemFromWebSite()
        {
            if (QuidTextBox.Text.Length < 1)
            {
                if (HtmlTextBox.Text.Length < 1)
                {
                    MessageBox.Show("Quid를 넣어 주세요.");
                    return null;
                }
                else
                {
                    WebCrawler.SetHtml(HtmlTextBox.Text);
                    var vnode2 = WebCrawler.SelectNode("tr", "class", "nemo-v-hint");
                    var hnodes2 = WebCrawler.SelectNodes("td", "class", "nemo-h-hint", true);

                    if (vnode2 == null)
                    {
                        MessageBox.Show("vnode null");
                        return null;
                    }

                    if (hnodes2 == null)
                    {
                        MessageBox.Show("hnodes null");
                        return null;
                    }

                    var vertical2 = new List<NnlLine>();
                    var horizontal2 = new List<NnlLine>();
                    var hints2 = vnode2.InnerText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    vertical2.AddRange(hints2.Select(hint => new NnlLine
                    {
                        Hint = hint.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()
                    }));
                    horizontal2.AddRange(hnodes2.Select(node => new NnlLine
                    {
                        Hint = node.InnerText.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()
                    }));

                    return new NnlProblem(vertical2.Count, horizontal2.Count, horizontal2, vertical2);
                }
            }

            string url = $"http://nemonemologic.com/play_logic.php?quid={QuidTextBox.Text}";
            SeleniumWebCrawler.Open(url, true);
            var vnode = SeleniumWebCrawler.SelectNode("tr", "class", "nemo-v-hint");
            var hnodes = SeleniumWebCrawler.SelectNodes("td", "class", "nemo-h-hint", true);

            if (vnode == null)
            {
                MessageBox.Show("vnode null");
                return null;
            }

            if (hnodes == null)
            {
                MessageBox.Show("hnodes null");
                return null;
            }

            var vertical = new List<NnlLine>();
            var horizontal = new List<NnlLine>();
            var hints = vnode.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            vertical.AddRange(hints.Select(hint => new NnlLine
            {
                Hint = hint.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()
            }));
            horizontal.AddRange(hnodes.Select(node => new NnlLine
            {
                Hint = node.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()
            }));

            return new NnlProblem(vertical.Count, horizontal.Count, horizontal, vertical);
        }

        private NnlQuestion? GetQuestionFromWebSite()
        {
            if (QuidTextBox.Text.Length < 1)
            {
                if (HtmlTextBox.Text.Length < 1)
                {
                    MessageBox.Show("Quid를 넣어 주세요.");
                    return null;
                }
                else
                {
                    WebCrawler.SetHtml(HtmlTextBox.Text);
                    var vnode2 = WebCrawler.SelectNode("tr", "class", "nemo-v-hint");
                    var hnodes2 = WebCrawler.SelectNodes("td", "class", "nemo-h-hint", true);

                    if (vnode2 == null)
                    {
                        MessageBox.Show("vnode null");
                        return null;
                    }

                    if (hnodes2 == null)
                    {
                        MessageBox.Show("hnodes null");
                        return null;
                    }

                    var vertical2 = new List<NnlLine>();
                    var horizontal2 = new List<NnlLine>();
                    var hints2 = vnode2.InnerText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    vertical2.AddRange(hints2.Select(hint => new NnlLine
                    {
                        Hint = hint.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()
                    }));
                    horizontal2.AddRange(hnodes2.Select(node => new NnlLine
                    {
                        Hint = node.InnerText.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()
                    }));

                    var builder2 = new StringBuilder();
                    builder2.AppendLine(string.Join(Environment.NewLine, horizontal2.Select(x => x.ToString())));
                    builder2.Append(string.Join(Environment.NewLine, vertical2.Select(x => x.ToString())));

                    return new NnlQuestion(builder2.ToString());
                }
            }

            string url = $"http://nemonemologic.com/play_logic.php?quid={QuidTextBox.Text}";
            SeleniumWebCrawler.Open(url, true);
            var vnode = SeleniumWebCrawler.SelectNode("tr", "class", "nemo-v-hint");
            var hnodes = SeleniumWebCrawler.SelectNodes("td", "class", "nemo-h-hint", true);

            if (vnode == null)
            {
                MessageBox.Show("vnode null");
                return null;
            }

            if (hnodes == null)
            {
                MessageBox.Show("hnodes null");
                return null;
            }

            var vertical = new List<NnlLine>();
            var horizontal = new List<NnlLine>();
            var hints = vnode.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            vertical.AddRange(hints.Select(hint => new NnlLine
            {
                Hint = hint.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()
            }));
            horizontal.AddRange(hnodes.Select(node => new NnlLine
            {
                Hint = node.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()
            }));

            var builder = new StringBuilder();
            builder.AppendLine(string.Join(Environment.NewLine, horizontal.Select(x => x.ToString())));
            builder.AppendLine();
            builder.AppendLine(string.Join(Environment.NewLine, vertical.Select(x => x.ToString())));

            return new NnlQuestion(builder.ToString());
        }

        private void PrevButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                PageText.Text = (currentIndex + 1) + " / " + (maxIndex + 1);
                BoardControl.Refresh(currentIndex);
            }
        }

        private void NextButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (currentIndex < maxIndex)
            {
                currentIndex++;
                PageText.Text = (currentIndex + 1) + " / " + (maxIndex + 1);
                BoardControl.Refresh(currentIndex);
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void SolveCaseButton_Click(object sender, RoutedEventArgs e)
        {
            var problem = GetProblemFromWebSite();
            if (problem == null)
            {
                return;
            }
            var result = problem.Solve();

            if (result == null || result.Answer.Count == 0)
            {
                MessageBox.Show("정답을 찾지 못했습니다.");
                return;
            }

            BoardControl.Boards = result.Answer;
            currentIndex = 0;
            maxIndex = result.Answer.Count - 1;
            PageText.Text = "1 / " + (maxIndex + 1);
            BoardControl.Refresh(0);
        }
    }
}
