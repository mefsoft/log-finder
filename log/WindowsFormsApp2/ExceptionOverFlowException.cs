using System;
using System.Runtime.Serialization;

namespace WindowsFormsApp2
{
    [Serializable]
    internal class ExceptionOverFlowException : Exception
    {
        public ExceptionOverFlowException()
        {
        }

        public ExceptionOverFlowException(string message) : base(message)
        {
        }

        public ExceptionOverFlowException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExceptionOverFlowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}