using System;

namespace Exceptions
{
    public class ParsingException : Exception
    {
        public ParsingException(string message, object content, string serviceURL = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
