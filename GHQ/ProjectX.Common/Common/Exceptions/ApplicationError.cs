using System;

namespace Exceptions
{
    public class ApplicationError : Exception
    {
        public ApplicationError(string message, object methodParamters, string functionName = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
