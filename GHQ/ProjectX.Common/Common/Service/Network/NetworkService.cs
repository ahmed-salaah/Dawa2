using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service.Network
{
    public class NetworkService : INetworkService
    {
        HttpClient client;
        public NetworkService()
        {
            client = new HttpClient();
        }

        public async Task<HttpResult<T>> HttpDeleteAsync<T>(string url, Dictionary<string, string> headers = null) where T : class
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Delete,
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            HttpResponseMessage result = await client.SendAsync(request);
            var responseJSON = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                var responseObject = JsonConvert.DeserializeObject<T>(responseJSON);
                return new HttpResult<T>(responseObject, null, result);
            }
            else
            {
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnAuthorizedException("UnAuthorized", headers, url);
                }
                else
                {
                    var responseObject = JsonConvert.DeserializeObject<ErrorResponse>(responseJSON);
                    return new HttpResult<T>(null, responseObject, result);
                }
            }
        }

        public async Task<HttpResult<T>> HttpGetAsync<T>(string url, Dictionary<string, string> headers) where T : class
        {
            HttpResponseMessage result = null;
            try
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                };

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                result = await client.SendAsync(request);
                var responseJSON = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {

                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Include
                    };
                    var responseObject = JsonConvert.DeserializeObject<T>(responseJSON, settings);
                    return new HttpResult<T>(responseObject, null, result);
                }
                else
                {
                    if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new UnAuthorizedException("UnAuthorized", headers, url);
                    }
                    else
                    {
                        var responseObject = JsonConvert.DeserializeObject<ErrorResponse>(responseJSON);
                        return new HttpResult<T>(null, responseObject, result);
                    }

                }
            }
            catch (UnAuthorizedException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                ErrorResponse newError = new ErrorResponse() { ErrorMessages = errors };
                return new HttpResult<T>(null, newError, result);
            }

        }

        public async Task<HttpResult<T>> HttpPostAsync<T>(string url, object content, Dictionary<string, string> headers = null) where T : class
        {
            var json = JsonConvert.SerializeObject(content);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post,
                Content = jsonContent,
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            HttpResponseMessage result = await client.SendAsync(request);
            var responseJSON = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                var responseObject = JsonConvert.DeserializeObject<T>(responseJSON);
                return new HttpResult<T>(responseObject, null, result);
            }
            else
            {
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnAuthorizedException("UnAuthorized", headers, url);
                }
                else
                {
                    var responseObject = JsonConvert.DeserializeObject<ErrorResponse>(responseJSON);
                    return new HttpResult<T>(null, responseObject, result);
                }
            }
        }

        public async Task<HttpResult<T>> HttpPutAsync<T>(string url, object content, Dictionary<string, string> headers = null) where T : class
        {
            var json = JsonConvert.SerializeObject(content);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Put,
                Content = jsonContent,
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            HttpResponseMessage result = await client.SendAsync(request);
            var responseJSON = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                var responseObject = JsonConvert.DeserializeObject<T>(responseJSON);
                return new HttpResult<T>(responseObject, null, result);
            }
            else
            {
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnAuthorizedException("UnAuthorized", headers, url);
                }
                else
                {
                    var responseObject = JsonConvert.DeserializeObject<ErrorResponse>(responseJSON);
                    return new HttpResult<T>(null, responseObject, result);
                }
            }
        }
    }
}
