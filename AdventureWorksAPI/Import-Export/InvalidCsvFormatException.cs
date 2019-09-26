using System;
using System.Runtime.Serialization;

namespace Import_Export
{
    [Serializable]
    internal class InvalidCsvFormatException : Exception
    {
        public InvalidCsvFormatException()
        {
        }

        public InvalidCsvFormatException(string message) : base(message)
        {
        }

        public InvalidCsvFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCsvFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}