using System;

namespace Exceptions
{
    public class UnHandledException : Exception
    {
        public UnHandledException(string message, object serviceParamters, string serviceURL = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
