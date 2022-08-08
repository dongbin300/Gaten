using Gaten.Net.Collections;
using Gaten.Net.Network;

using System;
using System.Collections.Generic;
using System.Windows;

namespace Gaten.GameTool.osu.osuRankingManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<PlayerInfo> players = new List<PlayerInfo>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 3; i++)
            {
                WebCrawler.Open($"https://osu.ppy.sh/rankings/fruits/score?page={i}#scores");
                var nodes = WebCrawler.SelectNodes("tr", "class", "ranking-page-table__row", true);

                foreach (var node in nodes)
                {
                    string[] contents = node.InnerText.Replace(" ", "").Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    players.Add(new PlayerInfo()
                    {
                        Rank = contents[0],
                        Nickname = contents[1],
                        PlayCount = contents[3],
                        RankScore = contents[5],
                        SS = contents[6],
                        S = contents[7],
                        A = contents[8]
                    });
                }
            }


            DataSource source = new DataSource("Rank", "Nickname", "PlayCount", "RankScore", "SS", "S", "A");
            for (int i = -3; i <= 3; i++)
            {
                PlayerInfo pi = players[int.Parse(players.Find(p => p.Nickname.Equals("gaten")).Rank.Substring(1)) - 1 + i];
                source.AddRow(pi.Rank, pi.Nickname, pi.PlayCount, pi.RankScore, pi.SS, pi.S, pi.A);
            }

            RankingDataGrid.ItemsSource = null;
            RankingDataGrid.ItemsSource = source.Data;
        }
    }
}
