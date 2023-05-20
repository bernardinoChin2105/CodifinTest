using System;
using System.Runtime.Serialization;

namespace Integrations
{
    class PlaceHolderException : Exception
    {
        public PlaceHolderException()
        {
        }

        public PlaceHolderException(string message) : base(message)
        {
        }

        public PlaceHolderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlaceHolderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
