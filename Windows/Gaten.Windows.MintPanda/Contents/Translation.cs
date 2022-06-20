using Gaten.Net.Network;

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Gaten.Windows.MintPanda.Contents
{
    public enum Language
    {
        Korean,
        English,
        Japanese,
        Chinese
    }

    internal class Translation
    {
        public static string Get(Language language, string input)
        {
            string languageQuery = language switch
            {
                Language.Korean => "&tl=ko",
                Language.English => "&tl=en",
                Language.Japanese => "&tl=ja",
                Language.Chinese => "&tl=zh-CN",
                _ => ""
            };

            string url = "https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto" + languageQuery + "&dt=t&dj=1&q=" + input;
            WebCrawler.SetUrl(url);
            var result = JsonSerializer.Deserialize<Translation_JsonObject>(WebCrawler.Source);
            var translatedText = string.Join(" ", result.sentences.Select(s=>s.trans));

            return translatedText;
        }
    }

    public record ModelSpecification();

    public record ModelTracking(string checkpoint_md5, string launch_doc);

    public record TranslationEngineDebugInfo(ModelTracking model_tracking);

    public record Sentence
        (string trans, string orig, int backend, IList<ModelSpecification> model_specification, IList<TranslationEngineDebugInfo> translation_engine_debug_info);

    public record Spell();

    public record Translation_JsonObject(IList<Sentence> sentences, string src, Spell spell);
}
