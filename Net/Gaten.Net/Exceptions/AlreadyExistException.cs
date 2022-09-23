namespace Gaten.Net.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException()
        {
        }

        public AlreadyExistException(string name)
            : base("Already Exist : " + name)
        {

        }
    }
}