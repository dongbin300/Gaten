﻿using Gaten.Net.Network;

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

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuidTextBox.Text.Length < 1)
            {
                MessageBox.Show("Quid를 넣어 주세요.");
                return;
            }

            string url = $"http://nemonemologic.com/play_logic.php?quid={QuidTextBox.Text}";
            SeleniumWebCrawler.CreateNoWindow = true;
            SeleniumWebCrawler.Open(url);
            var vnode = SeleniumWebCrawler.SelectNode("tr", "class", "nemo-v-hint");
            var hnodes = SeleniumWebCrawler.SelectNodes("td", "class", "nemo-h-hint", true);

            if (vnode == null)
            {
                MessageBox.Show("vnode null");
                return;
            }

            if (hnodes == null)
            {
                MessageBox.Show("hnodes null");
                return;
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

            var problem = new NnlProblem(vertical.Count, horizontal.Count, horizontal, vertical);
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
