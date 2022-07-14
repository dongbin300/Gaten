using Gaten.Net.Network;

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// Translation.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Translation : Window
    {
        public Translation()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        public static string Get(Language language, string input)
        {
            string languageQuery = language switch
            {
                Contents.Language.Korean => "&tl=ko",
                Contents.Language.English => "&tl=en",
                Contents.Language.Japanese => "&tl=ja",
                Contents.Language.Chinese => "&tl=zh-CN",
                _ => ""
            };

            string url = "https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto" + languageQuery + "&dt=t&dj=1&q=" + input;
            WebCrawler.SetUrl(url);
            var result = JsonSerializer.Deserialize<Translation_JsonObject>(WebCrawler.Source);
            var translatedText = string.Join(" ", result.sentences.Select(s => s.trans));

            return translatedText;
        }

        private void TranslationButton_Click(object sender, RoutedEventArgs e)
        {
            if (TranslationText1.Text.Length < 1)
            {
                return;
            }

            string text = Get((Language)TranslationComboBox.SelectedIndex, TranslationText1.Text);

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            TranslationText2.Text = text;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            TranslationText1.Text = "";
            TranslationText2.Text = "";
            TranslationText1.Focus();
        }
    }

    public enum Language
    {
        Korean,
        English,
        Japanese,
        Chinese
    }

    public record ModelSpecification();

    public record ModelTracking(string checkpoint_md5, string launch_doc);

    public record TranslationEngineDebugInfo(ModelTracking model_tracking);

    public record Sentence
        (string trans, string orig, int backend, IList<ModelSpecification> model_specification, IList<TranslationEngineDebugInfo> translation_engine_debug_info);

    public record Spell();

    public record Translation_JsonObject(IList<Sentence> sentences, string src, Spell spell);
}
