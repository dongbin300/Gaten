namespace Gaten.Stock.MercuryEditor.Inspection.SystemCode
{
    internal class MercurySystemCode
    {
        public string Keyword { get; set; } = string.Empty;
        public int CodeType { get; set; }
        public int SupportedMinimumVersion { get; set; }

        public MercurySystemCode(string keyword, int codeType, int supportedMinimumVersion)
        {
            Keyword = keyword;
            CodeType = codeType;
            SupportedMinimumVersion = supportedMinimumVersion;
        }
    }
}
