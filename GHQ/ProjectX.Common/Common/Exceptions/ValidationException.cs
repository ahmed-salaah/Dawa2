using System;

namespace Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message, object serviceParamters, string serviceURL = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
