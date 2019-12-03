using System;
using System.Runtime.Serialization;

namespace DesignPatterns.Infrastructure
{
    [Serializable]
    internal class HandlerAlreadyUsedException : Exception
    {
        public HandlerAlreadyUsedException()
        {
        }

        public HandlerAlreadyUsedException(string message) : base(message)
        {
        }

        public HandlerAlreadyUsedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HandlerAlreadyUsedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}