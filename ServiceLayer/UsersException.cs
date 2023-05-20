using System;
using System.Runtime.Serialization;

namespace ServiceLayer
{
    class UsersException : Exception
    {
        public UsersException()
        {
        }

        public UsersException(string message) : base(message)
        {
        }

        public UsersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UsersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
