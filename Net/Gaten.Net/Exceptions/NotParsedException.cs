namespace Gaten.Net.Exceptions
{
    public class NotParsedException : Exception
    {
        public NotParsedException()
        {
        }

        public NotParsedException(string name)
            : base("Not Parsed : " + name)
        {

        }
    }
}
