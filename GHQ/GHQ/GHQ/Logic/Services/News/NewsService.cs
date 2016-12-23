using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GHQ.Logic.Models.Data.News;
using GHQ.Logic.Models.Response;
using Service.Network;
using Exceptions;
using Newtonsoft.Json;
using Service.Internet;

namespace GHQ.Logic.Service.News
{
    public class NewsService : INewsService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        #endregion

        List<NewsData> CachedNews = null;

        public NewsData SelectedNew { get; set; }

        public NewsService(INetworkService _networkService, IInternetService _internetService)
        {
            networkService = _networkService;
            internetService = _internetService;
        }

        public async Task<List<NewsData>> GetNewsAsync()
        {
            try
            {
                if (CachedNews == null)
                {
                    if (internetService.HasInternetAccess())
                    {
                        Dictionary<string, string> headers = new Dictionary<string, string>();
                        headers.Add("Accept", "application/json;odata=verbose");

                        var resource = Constant.ServiceConstant.ApiSharePointBaseUrl + Constant.ServiceConstant.Api_Get_News;
                        var result = await networkService.HttpGetAsync<NewsResponse>(resource, headers);
                        if (result.HttpResponseMessage.IsSuccessStatusCode)
                        {
                            if (result.Result != null)
                            {
                                CachedNews = NewsTranslator.Translate(result.Result);
                                return CachedNews;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), headers, resource, null);
                        }
                    }
                    else
                    {
                        throw new InternetException();
                    }
                }
                else
                {
                    return CachedNews;
                }
            }
            catch (InternetException ex)
            {
                throw ex;
            }
            catch (BackendException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, "", "NewsService.GetNewsAsync", ex);
            }
        }
    }
}
