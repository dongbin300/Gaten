namespace Gaten.Stock.MercuryEditor.Inspection.SystemCode
{
    internal class MercurySystemCodeParseResult : MercuryBaseResult
    {
        public MercurySystemCodeFormat? SystemCode { get; set; } = null;

        public MercurySystemCodeParseResult() : base()
        {

        }

        public MercurySystemCodeParseResult(string errorMessage) : base(errorMessage)
        {

        }
    }
}
