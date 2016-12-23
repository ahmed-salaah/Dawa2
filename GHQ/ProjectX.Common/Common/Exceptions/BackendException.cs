using Newtonsoft.Json;
using System;

namespace Exceptions
{
    public class BackendException : Exception
    {
        public BackendException(string message, object serviceParamters, string serviceURL = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
