using System;

namespace Exceptions
{
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException(string message, object serviceParamters, string serviceURL = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
