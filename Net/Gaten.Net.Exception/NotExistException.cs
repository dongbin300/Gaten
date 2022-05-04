namespace Gaten.Net.Exception
{
    public class NotExistException : System.Exception
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