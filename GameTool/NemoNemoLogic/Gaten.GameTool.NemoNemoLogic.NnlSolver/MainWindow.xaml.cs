using Gaten.Net.Network;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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

        private void SolveTestButton_Click(object sender, RoutedEventArgs e)
        {
            var completionText =
                "0000011" +
                "1100010" +
                "0101010" +
                "0111101" +
                "0000010" +
                "1101010" +
                "0001111";

            var problem = NnlProblemMaker.Make(completionText, 7, 7);
            var tealProblem = problem.ToTealNnlProblem();

            //var result = problem.Solve();

            //if (result == null || result.Answer.Count == 0)
            //{
            //    MessageBox.Show("정답을 찾지 못했습니다.");
            //    return;
            //}

            //BoardControl.Boards = result.Answer;
            //currentIndex = 0;
            //maxIndex = result.Answer.Count - 1;
            //PageText.Text = (currentIndex + 1) + " / " + (maxIndex + 1);
            //BoardControl.Refresh(currentIndex);
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
            var problem = GetProblemFromWebSite();
            if(problem == null)
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
            PageText.Text = (currentIndex + 1) + " / " + (maxIndex + 1);
            BoardControl.Refresh(currentIndex);
        }

        private NnlProblem? GetProblemFromWebSite()
        {
            if (QuidTextBox.Text.Length < 1)
            {
                if(HtmlTextBox.Text.Length < 1)
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
            SeleniumWebCrawler.CreateNoWindow = true;
            SeleniumWebCrawler.Open(url);
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
    }
}
