namespace Gaten.Net.Exceptions
{
    public class SystemException : Exception
    {
        public SystemException()
        {
        }

        public SystemException(string message)
            : base(message)
        {

        }
    }
}