namespace Gaten.Language.Mercury.Editor
{
    public class TextLine
    {
        public int LineNumber { get; set; }
        public string Text { get; set; }

        public TextLine(int lineNumber, string text)
        {
            LineNumber = lineNumber;
            Text = text;
        }

        public override string ToString()
        {
            return $"[{LineNumber}] {Text}";
        }
    }
}
