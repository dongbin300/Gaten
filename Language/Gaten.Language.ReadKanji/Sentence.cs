namespace Gaten.Language.ReadKanji
{
    public class Sentence
    {
        public string Korean { get; set; }
        public string Kanji { get; set; }
        public string Yomigana { get; set; }
        public string ReadKorean { get; set; }
        public string DisplayText => $"{Korean} : {Kanji}{Yomigana} {ReadKorean}";

        public Sentence(string korean, string kanji, string yomigana, string readKorean)
        {
            Korean = korean;
            Kanji = kanji;
            Yomigana = yomigana;
            ReadKorean = readKorean;
        }
    }
}
