using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GHQ.Logic.Models.Response;
using Service.Network;
using Exceptions;
using Newtonsoft.Json;
using Service.Internet;
using GHQ.Logic.Models.Data.Notification;
using GHQ.Logic.Service.Account;
using System.Linq;

namespace GHQ.Logic.Service.Notification
{
    public class NotificationService : INotificationService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        IAccountService accountService;

        public NotificationData SelectedNotification { get; set; }

        #endregion

        public NotificationService(INetworkService _networkService, IInternetService _internetService, IAccountService _accountService)
        {
            networkService = _networkService;
            internetService = _internetService;
            accountService = _accountService;
        }

        public async Task<List<NotificationData>> GetNotificationsAsync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    Dictionary<string, string> headers = new Dictionary<string, string>();
                    headers.Add("Accept", "application/json;odata=verbose");
                    headers.Add("Authorization", "Bearer " + accountService.AccessToken);
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Get_Notifications;
                    var result = await networkService.HttpGetAsync<List<NotificationResponse>>(resource, headers);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null && result.Result != null)
                        {
                            return NotificationTranslator.Translate(result.Result.ToList());
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
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return null;
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
                throw new ApplicationError(ex.Message, "", "NotificationService.GetNewsAsync", ex);
            }
        }

        public async Task<bool> RegisterUserDevice(string deviceId)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json;odata=verbose");
            headers.Add("Authorization", "Bearer " + accountService.AccessToken);
            var resource = Constant.ServiceConstant.ApiBaseUrl + string.Format(Constant.ServiceConstant.Api_RegisterUserDevices, deviceId);
            var result = await networkService.HttpGetAsync<string>(resource, headers);
            if (result.HttpResponseMessage.IsSuccessStatusCode)
            {
                if (result.Result != null)
                {
                    if (result.Result == "Succeeded")
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), headers, resource, null);
            }
        }

        public async Task<bool> UnRegisterUserDevice(string deviceId)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json;odata=verbose");
            headers.Add("Authorization", "Bearer " + accountService.AccessToken);
            var resource = Constant.ServiceConstant.ApiBaseUrl + string.Format(Constant.ServiceConstant.Api_UnRegisterUserDevice, deviceId);
            var result = await networkService.HttpGetAsync<string>(resource, headers);
            if (result.HttpResponseMessage.IsSuccessStatusCode)
            {
                if (result.Result != null)
                {
                    if (result.Result == "Succeeded")
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), headers, resource, null);
            }
        }
    }
}
