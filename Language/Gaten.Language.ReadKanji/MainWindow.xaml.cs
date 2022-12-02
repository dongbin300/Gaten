using Gaten.Net.Extensions;
using Gaten.Net.IO;
using Gaten.Net.Language.Japanese;
using Gaten.Net.Network;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Gaten.Language.ReadKanji
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sentencePath = GResource.BaseFilePath.Down("ReadKanji-Sentences.csv");
        List<Sentence> sentences = new();

        public MainWindow()
        {
            InitializeComponent();

            Load();
            Refresh();
        }

        private void Save()
        {
            sentences.SaveCsvFile(sentencePath);
        }

        private void Load()
        {
            if (!File.Exists(sentencePath))
            {
                return;
            }
            sentences = GFile.ReadCsv<Sentence>(sentencePath).ToList();
        }

        private void Refresh()
        {
            SentenceListBox.ItemsSource = null;
            SentenceListBox.ItemsSource = sentences;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var str = RegisterTextBox.Text;
                SeleniumWebCrawler.CreateNoWindow = true;
                SeleniumWebCrawler.Open($"https://ja.dict.naver.com/#/search?range=word&query={str}");
                var nodes = SeleniumWebCrawler.SelectNodes("ul", "class", "mean_list");

                foreach (var node in nodes)
                {
                    var text = node.Text;

                    if (MessageBox.Show(text, "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var segments = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                        sentences.Add(new Sentence(str, segments[0], segments[1], new JapaneseSentence(segments[1]).ToKorean()));
                        break;
                    }
                }

                Refresh();
                Save();

                RegisterTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RegisterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterButton_Click(sender, new RoutedEventArgs());
            }
        }
    }
}
