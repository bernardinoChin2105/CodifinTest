using System;
using System.Runtime.Serialization;

namespace ServiceLayer
{
    class PostsException : Exception
    {
        public PostsException()
        {
        }

        public PostsException(string message) : base(message)
        {
        }

        public PostsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PostsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
