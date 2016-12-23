using Exceptions;
using GHQ.Logic.Models.Account.Data;
using GHQ.Logic.Models.Account.Requests;
using GHQ.Logic.Models.Response;
using GHQ.Logic.Translators;
using GHQ.Resources.Strings;
using GHQ.UI.Pages.Master;
using Newtonsoft.Json;
using Service.Dialog;
using Service.Internet;
using Service.Naviagtion;
using Service.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.Account
{
    public class AccountService : IAccountService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        INavigationService navigationService;
        IDialogService dialogService;
        #endregion

        public string AccessToken { get; set; } = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImEzck1VZ01Gdjl0UGNsTGE2eUYzekFrZnF1RSIsImtpZCI6ImEzck1VZ01Gdjl0UGNsTGE2eUYzekFrZnF1RSJ9.eyJpc3MiOiJodHRwczovL2docS1pZGVudGl0eXNlcnZlci5saW5rZGV2LmNvbS9jb3JlLyIsImF1ZCI6Imh0dHBzOi8vZ2hxLWlkZW50aXR5c2VydmVyLmxpbmtkZXYuY29tL2NvcmUvcmVzb3VyY2VzIiwiZXhwIjoxNDgyNTM4NjAwLCJuYmYiOjE0ODI0NTIyMDAsImNsaWVudF9pZCI6IkJBNERBMjdBLUM3MDAtNEFFRC05MTM0LUVCQzY0RDZDMDE0QiIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJlbWFpbCIsIkdIUS5CYWNrZW5kIl0sInN1YiI6Ijc4NC0xOTY2LTE0MTM0NjctMCIsImF1dGhfdGltZSI6MTQ4MjQ1MjE5OSwiaWRwIjoiaWRzcnYiLCJlbWFpbCI6Ijc4NC0xOTY2LTE0MTM0NjctMEBjaXRpemVucy5jb20iLCJlbWlyYXRlc2lkIjoiNzg0LTE5NjYtMTQxMzQ2Ny0wIiwiYW1yIjpbInBhc3N3b3JkIl19.WYJLFO7NBJrjFNSGjFmo65VXI0JZEif9pMvQyQz7X1XpYDDPMPpCw_To1yvKSBml3XBFVFr9hmaOZba5v2y1d5EB9sAqKRPVWpKfTifVgkDhOn-sooAqUz0HJZz7AHaKzKYem3JG8Wc92j-3O6D8yk1Dyes8fuJGuQ4bUsM-cRq_oBz5v-ROHYC8YrD-eYjHAVSY6QYsyKI4vsoPvRqy9OUVrol9tix-O8hWBZwVc_fX3DkUY3vY6nA_oRGXD9q8_m2DfFa8GJ9xGp-i1bFmPqfbPc-UFPe_sBX71A18OUnX6ixdafk082iGg1Gvbx5WoVJDbpn4DJO3kk_R_4DDqg";

        public bool IsLogin
        {
            get
            {
                return !string.IsNullOrEmpty(AccessToken);
            }
        }

        public AccountService(INetworkService _networkService, IInternetService _internetService, INavigationService _navigationService, IDialogService _dialogService)
        {
            networkService = _networkService;
            internetService = _internetService;
            navigationService = _navigationService;
            dialogService = _dialogService;
        }

        public void HandleUnAuthorizedException(UnAuthorizedException ex)
        {
            AccessToken = "";
            dialogService.DisplayAlert(AppResources.UnAuthoirzed_Message_Title, AppResources.UnAuthoirzed_Message_Description);
            navigationService.SetAppCurrentPage(typeof(MainPage));
        }

        public async Task<int> GetStepOfAccountCreationAsync(string emiratesID, string unifiedNumber)
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var requestObject = new GetStepOfAccountCreationRequest() { EmiratesID = emiratesID, UnifiedNumber = unifiedNumber };
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registeration_GetStepOfAccountCreation;
                    var result = await networkService.HttpPostAsync<string>(resource, requestObject);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = int.Parse(result.Result);
                            return value;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        throw new BackendException(result.ErrorResponse.ErrorMessagesString, requestObject, resource, null);
                    }
                }
                else
                {
                    throw new InternetException();
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
            catch (ParsingException ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1},{2}:{3}", "emiratesID", emiratesID, "unifiedNumber", unifiedNumber), "AccountService.GetUserMobileNumbersAsync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1},{2}:{3}", "emiratesID", emiratesID, "unifiedNumber", unifiedNumber), "AccountService.GetUserMobileNumbersAsync", ex);
            }
        }

        public async Task<NewAccountData> GetMOIUserInfoAsync(string emiratesID, string unifiedNumber)
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var requestObject = new GetMOIUserInfoRequest() { EmiratesID = emiratesID, UnifiedNumber = unifiedNumber };
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registeration_GetMOIUserInfo;
                    var result = await networkService.HttpPostAsync<UserInfoResponse>(resource, requestObject);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var translatedData = UserInfoTranslator.Translate(result.Result);
                            return translatedData;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(AppResources.NewAccount_Messages_DataIsInvalid, requestObject, resource, null);
                    }
                }
                else
                {
                    throw new InternetException();
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
            catch (ParsingException ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1},{2}:{3}", "emiratesID", emiratesID, "unifiedNumber", unifiedNumber), "AccountService.GetUserMobileNumbersAsync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1},{2}:{3}", "emiratesID", emiratesID, "unifiedNumber", unifiedNumber), "AccountService.GetUserMobileNumbersAsync", ex);
            }
        }

        public async Task<List<UserMobileData>> GetUserMobileNumbersAsync(string emiratesID, string unifiedNumber)
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var requestObject = new GetUserMobileNumbersRequest() { EmiratesID = emiratesID, UnifiedNumber = unifiedNumber };
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registeration_GetUserMobileNumbers;
                    var result = await networkService.HttpPostAsync<List<GetUserMobileNumbersResponse>>(resource, requestObject);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var translatedData = UserMobileTranslator.Translate(result.Result);
                            return translatedData;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(result.ErrorResponse.ErrorMessagesString, requestObject, resource, null);
                    }
                }
                else
                {
                    throw new InternetException();
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
            catch (ParsingException ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1},{2}:{3}", "emiratesID", emiratesID, "unifiedNumber", unifiedNumber), "AccountService.GetUserMobileNumbersAsync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1},{2}:{3}", "emiratesID", emiratesID, "unifiedNumber", unifiedNumber), "AccountService.GetUserMobileNumbersAsync", ex);
            }
        }

        public async Task<bool> VerifyMyCodeAsync(string emiratesID, string unifiedNumber, string channel, string vrificationCode)
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var requestObject = new VerifyMyCodeRequest() { Channel = channel, EmiratesID = emiratesID, UnifiedNumber = unifiedNumber, VerificationCode = vrificationCode };
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registeration_VerifyMyCode;
                    var result = await networkService.HttpPostAsync<string>(resource, requestObject);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result == "Suuceeded")
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        throw new BackendException(result.ErrorResponse.ErrorMessagesString, requestObject, resource, null);
                    }
                }
                else
                {
                    throw new InternetException();
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
                throw new ApplicationError(ex.Message, string.Format("{0}:{1},{2}:{3},{4}:{5},{6}:{7}", "emiratesID", emiratesID, "unifiedNumber", unifiedNumber, "channel", channel, "vrificationCode", vrificationCode), "AccountService.VerifyMyCode", ex);
            }
        }

        public async Task<bool> IsEmailRequiredAsync(bool isWeb)
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var requestObject = new IsEmailRequiredRequest() { isWeb = isWeb };
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registeration_IsEmailRequired;
                    var result = await networkService.HttpPostAsync<string>(resource, requestObject);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        return bool.Parse(result.Result);
                    }
                    else
                    {
                        throw new BackendException(result.ErrorResponse.ErrorMessagesString, requestObject, resource, null);
                    }
                }
                else
                {
                    throw new InternetException();
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
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "isWeb", isWeb), "AccountService.IsEmailRequired", ex);
            }
        }

        public async Task<bool> SendVerificationCodeByEmailAsync(string emiratesID, string unifiedNumber, string email)
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var requestObject = new SendVerificationCodeByEmailRequest() { EmiratesID = emiratesID, UnifiedNumber = unifiedNumber, Email = email };
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registeration_SendVerificationCodeByEmail;
                    var result = await networkService.HttpPostAsync<string>(resource, requestObject);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result == "Succeeded")
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        throw new BackendException(result.ErrorResponse.ErrorMessagesString, requestObject, resource, null);
                    }
                }
                else
                {
                    throw new InternetException();
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
                throw new ApplicationError(ex.Message, string.Format("{0}:{1},{2}:{3},{4}:{5}", "emiratesID", emiratesID, "unifiedNumber", unifiedNumber, "email", email), "AccountService.SendVerificationCodeByEmail", ex);
            }
        }

        public async Task<bool> SendVerificationCodeBySMSAsync(string emiratesID, string unifiedNumber, string mobileId)
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var requestObject = new SendVerificationCodeBySMSRequest() { EmiratesID = emiratesID, UnifiedNumber = unifiedNumber, MobileID = mobileId };
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registeration_SendVerificationCodeBySMS;
                    var result = await networkService.HttpPostAsync<string>(resource, requestObject);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result == "Succeeded")
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        throw new BackendException(result.ErrorResponse.ErrorMessagesString, requestObject, resource, null);
                    }
                }
                else
                {
                    throw new InternetException();
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
                throw new ApplicationError(ex.Message, string.Format("{0}:{1},{2}:{3},{4}:{5}", "emiratesID", emiratesID, "unifiedNumber", unifiedNumber, "mobileId", mobileId), "AccountService.SendVerificationCodeBySMS", ex);
            }
        }

        public async Task<int> AddUserAccountAsync(NewAccountData accountData)
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    AddAccountRequest requestObject = new AddAccountRequest
                    {
                        EmiratesID = accountData.NewAccountStep1.EmiratesID,
                        UnifiedNumber = accountData.NewAccountStep1.UnifiedNumber,
                        FirstName = accountData.NewAccountStep4.FirstName,
                        SecondName = accountData.NewAccountStep4.SecondName,
                        ThirdName = accountData.NewAccountStep4.ThirdName,
                        FourthName = accountData.NewAccountStep4.FourthName,
                        FifthName = accountData.NewAccountStep4.FifthName,
                        Password = accountData.NewAccountStep4.Password,
                        ConfirmPassword = accountData.NewAccountStep4.ConfirmPassword,
                        Gender = accountData.NewAccountStep4?.SelectedGender?.Id,
                        DateOfBirth = accountData.NewAccountStep4.DOB.ToString(),
                        Nationality = accountData.NewAccountStep4?.SelectedNationality?.Id,
                    };

                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registeration_UpdateUserAccount;

                    var result = await networkService.HttpPostAsync<string>(resource, requestObject);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result == "Succeeded")
                            return 1;
                        else
                        {
                            int failedNumber = 0;
                            int.TryParse(result.Result, out failedNumber);
                            return failedNumber;
                        }

                    }
                    else
                    {
                        throw new BackendException(result.ErrorResponse.ErrorMessagesString, requestObject, resource, null);
                    }
                }
                else
                {
                    throw new InternetException();
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
                throw new ApplicationError(ex.Message, JsonConvert.SerializeObject(accountData), "AccountService.UpdateUserAccount", ex);
            }
        }

        public async Task<UserData> GetUserByEmiratesId(string accessToken)
        {
            try
            {
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registeration_GetUserByEmiratesId;
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var result = await networkService.HttpGetAsync<UserResponse>(resource, headers);
                if (result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    return new UserData() { BirthDate = result.Result.BirthDate, FullName = result.Result.FullName, RegStatus = result.Result.RegStatus, IsRegistrationSubmitted = result.Result.IsRegistrationSubmitted.HasValue ? result.Result.IsRegistrationSubmitted.Value : true };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, "", "AccountService.GetUserByEmiratesId", ex);
            }
        }
    }
}
