namespace Gaten.Language.Mercury.Inspection
{
    internal class MercuryBaseResult
    {
        public bool IsOk => string.IsNullOrEmpty(ErrorMessage);
        public string ErrorMessage { get; set; } = string.Empty;

        public MercuryBaseResult()
        {

        }

        public MercuryBaseResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
