﻿namespace Gaten.Net.Exception
{
    public class AlreadyExistException : System.Exception
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