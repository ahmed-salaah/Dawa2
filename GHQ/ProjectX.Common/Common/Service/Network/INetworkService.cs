using System.Collections.Generic;
using System.Threading.Tasks;
namespace Service.Network
{
    public interface INetworkService
    {
        string AccessToken { get; set; }
        Task<HttpResult<T>> HttpGetAsync<T>(string url,Dictionary<string,string> headers = null) where T : class;
        Task<HttpResult<T>> HttpPostAsync<T>(string url, object content, Dictionary<string, string> headers=null) where T : class;
        Task<HttpResult<T>> HttpPutAsync<T>(string url, object content, Dictionary<string, string> headers = null) where T : class;
        Task<HttpResult<T>> HttpDeleteAsync<T>(string url, Dictionary<string, string> headers = null) where T : class;
    }
}
