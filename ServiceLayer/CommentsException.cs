using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ServiceLayer
{
    class CommentsException : Exception
    {
        public CommentsException()
        {
        }

        public CommentsException(string message) : base(message)
        {
        }

        public CommentsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommentsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
