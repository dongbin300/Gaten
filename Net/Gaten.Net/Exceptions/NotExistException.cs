namespace Gaten.Net.Exceptions
{
    public class NotExistException : Exception
    {
        public NotExistException()
        {
        }

        public NotExistException(string name)
            : base("Not Exist : " + name)
        {

        }
    }
}