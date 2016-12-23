using System.Net.Http;

namespace Service.Network
{
    public class HttpResult<T>
    {
        public T Result { get; private set; }
        public HttpResponseMessage HttpResponseMessage { get; private set; }
        public ErrorResponse ErrorResponse { get; private set; }
        public HttpResult(T result,ErrorResponse errorResponse, HttpResponseMessage httpResponseMessage)
        {
            Result = result;
            HttpResponseMessage = httpResponseMessage;
            ErrorResponse = errorResponse;
        }
    }
}
