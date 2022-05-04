namespace Gaten.Net.Exception
{
    public class NotParsedException : System.Exception
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
