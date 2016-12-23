using System;
using System.Threading.Tasks;
using GHQ.Logic.Models.Data.Registration;
using Service.Network;
using System.Collections.Generic;
using Exceptions;
using GHQ.Logic.Models.Response;
using GHQ.Logic.Translators;
using System.Linq;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Models.Account.Requests;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace GHQ.Logic.Service.ServiceRegistration
{
    public class ServiceRegistrationService : IServiceRegistrationService
    {
        #region Members

        INetworkService networkService;
        IAccountService accountService;
        #endregion

        public ServiceRegistrationService(INetworkService _networkService, IAccountService _accountService)
        {
            networkService = _networkService;
            accountService = _accountService;
        }

        public async Task<List<BREData>> GetBRConfiguration()
        {
            try
            {
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.GetBRConfiguration;
                var result = await networkService.HttpGetAsync<List<BREData>>(resource);
                if (result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    if (result.Result != null)
                    {
                        return result.Result;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, null, resource, null);
                }
            }

            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, "", "ServiceRegistrationService.GetBRConfiguration", ex);
            }
        }

        public async Task<RegistrationData> GetCandidateInfoByEmiratesId(string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_GetCandidateInfoByEmiratesId;
                var result = await networkService.HttpGetAsync<RegistrationData>(resource, headers);
                if (result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    if (result.Result != null)
                    {
                        return result.Result;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, null, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.GetCandidateInfoByEmiratesId", ex);
            }
        }

        public async Task<bool> UpdateCandidateData(RegistrationData data, string workStatusId, string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_UpdateCandidateData;
                data.WorkStatusID = workStatusId == null ? Constant.Constant.DefaultWorkingTypeId : workStatusId;
                var result = await networkService.HttpPostAsync<string>(resource, data, headers);
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
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, data, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.UpdateCandidateData", ex);
            }
        }

        public async Task<bool> UpdateWorkData(Work data, string maritalStatus, string workStatusId, string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_UpdateWorkData;

                GHQ.Logic.Models.ServiceRegistration.Requests.UpdateWorkRequest request = new GHQ.Logic.Models.ServiceRegistration.Requests.UpdateWorkRequest();
                request.CampaignAdminID = null;
                request.MaritalStatus = maritalStatus == null ? Constant.Constant.DefaultMaritalStatusId : maritalStatus;
                request.WorkStatusID = workStatusId == null ? Constant.Constant.DefaultWorkingTypeId : workStatusId;
                request.Work = new List<Models.ServiceRegistration.Requests.Work>();
                request.Work.Add(new Models.ServiceRegistration.Requests.Work()
                {
                    WorkFax = data.WorkFax,
                    WorkJobName = data.WorkJobName,
                    WorkOrganization = data.WorkOrganization,
                    WorkOrgCityID = data.WorkOrgCityID,
                    WorkOrgTypeID = data.WorkOrgTypeID,
                    WorkPhone1 = data.WorkPhone1,
                    WorkPhone2 = data.WorkPhone2,
                    WorkPosition = data.WorkPosition,
                    Salary = data.Salary,
                    EducationInstituteID = data.EducationInstituteID,
                    MilitaryEntityID = data.MilitaryEntityID,
                }
                );
                var result = await networkService.HttpPostAsync<string>(resource, request, headers);
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
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, data, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.UpdateWorkData", ex);
            }
        }

        public async Task<bool> UpdateAddress(Address data, string maritalStatus, string workStatusId, string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_UpdateAddress;

                GHQ.Logic.Models.ServiceRegistration.Requests.UpdateAddressRequest request = new GHQ.Logic.Models.ServiceRegistration.Requests.UpdateAddressRequest();
                request.CampaignAdminID = null;
                request.MaritalStatus = maritalStatus == null ? Constant.Constant.DefaultMaritalStatusId : maritalStatus;
                request.WorkStatusID = workStatusId == null ? Constant.Constant.DefaultWorkingTypeId : workStatusId;
                request.Addresses = new List<Models.ServiceRegistration.Requests.Address>();
                request.Addresses.Add(new Models.ServiceRegistration.Requests.Address()
                {
                    AddressText = data.AddressText,
                    BldgName = data.BldgName,
                    BldgNumber = data.BldgNumber,
                    CityID = data.CityID,
                    EmailCandidate = data.EmailCandidate,
                    FloorNumber = data.FloorNumber,
                    GuardianNumber = data.GuardianNumber,
                    HomePhone1 = data.HomePhone1,
                    HomePhone2 = data.HomePhone2,
                    Mobile1 = data.Mobile1,
                    Mobile2 = data.Mobile2,
                    POBox = data.POBox,
                    RegionID = data.RegionID,
                    Source = null,
                    StreetName = data.StreetName,
                    StreetNumber = data.StreetNumber,
                }
                );

                var result = await networkService.HttpPostAsync<string>(resource, request, headers);
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
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, data, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.UpdateAddress", ex);
            }
        }

        public async Task<bool> UpdateAcademicQualificationsData(Academicqualification data, string maritalStatus, string workStatusId, string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_UpdateAcademicQualificationsData;

                GHQ.Logic.Models.ServiceRegistration.Requests.UpdateAcademicQualificationRequest request = new GHQ.Logic.Models.ServiceRegistration.Requests.UpdateAcademicQualificationRequest();
                request.CampaignAdminID = null;
                request.MaritalStatus = maritalStatus == null ? Constant.Constant.DefaultMaritalStatusId : maritalStatus;
                request.WorkStatusID = workStatusId == null ? Constant.Constant.DefaultWorkingTypeId : workStatusId;
                request.AcademicQualifications = new List<Models.ServiceRegistration.Requests.Academicqualification>();
                request.AcademicQualifications.Add(new Models.ServiceRegistration.Requests.Academicqualification()
                {
                    AcademicCountryID = data.AcademicCountryID,
                    AcademicQualificationID = data.AcademicQualificationID,
                    EducationInstituteID = data.EducationInstituteID,
                    GPA = data.GPA,
                    Grade = data.Grade,
                    GraduationDate = data.GraduationDate,
                    ISEducationFinished = data.ISEducationFinishedValue,
                    IsDeleted = false,
                    JobLevel = data.JobLevel,
                    MainSpecializationID = data.MainSpecializationID,
                    Notes = data.Notes,
                    SubSpecializationID = data.SubSpecializationID,
                }
                );
                var result = await networkService.HttpPostAsync<string>(resource, request, headers);
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
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, data, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.UpdateAcademicQualificationsData", ex);
            }
        }

        public async Task<bool> UpdateRelative(List<Relative> data, string maritalStatus, string workStatusId, bool onlySon, string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_UpdateRelative;

                GHQ.Logic.Models.ServiceRegistration.Requests.UpdateRelativeRequest request = new GHQ.Logic.Models.ServiceRegistration.Requests.UpdateRelativeRequest();
                request.CampaignAdminID = null;
                request.OnlySon = onlySon;
                request.MaritalStatus = maritalStatus == null ? Constant.Constant.DefaultMaritalStatusId : maritalStatus;
                request.WorkStatusID = workStatusId == null ? Constant.Constant.DefaultWorkingTypeId : workStatusId;
                request.Relatives = new List<Models.ServiceRegistration.Requests.Relative>();
                foreach (var relative in data)
                {
                    request.Relatives.Add(new Models.ServiceRegistration.Requests.Relative()
                    {
                        AgeOfRelative = relative.AgeOfRelative,
                        BirthPlace = relative.BirthPlace,
                        FifthName_Arabic = relative.FifthName_Arabic,
                        FifthName_English = relative.FifthName_English,
                        FourthName_Arabic = relative.FourthName_Arabic,
                        FourthName_English = relative.FourthName_English,
                        FirstName_Arabic = relative.FirstName_Arabic,
                        FirstName_English = relative.FirstName_English,
                        GHQID = relative.GHQID == "Local" ? null : relative.GHQID,
                        HalfBrotherRelation = relative.HalfBrotherReltiveType,
                        isBrother = relative.IsBrotherValue,
                        JobName = relative.JobName,
                        IsAlive = relative.IsAliveValue,
                        Nationality = relative.Nationality,
                        RelativeType = relative.Relativetype,
                        ResidencePlaceID = relative.ResidencePlaceID,
                        SecondName_Arabic = relative.SecondName_Arabic,
                        SecondName_English = relative.SecondName_English,
                        StatusOfRelative = relative.StatusOfRelative,
                        ThirdName_Arabic = relative.ThirdName_Arabic,
                        ThirdName_English = relative.ThirdName_English,
                        TribeID = relative.TribeID,
                        WorkPlace = relative.WorkPlace,
                        Tribe = new Models.ServiceRegistration.Requests.Tribe() { LookupValueID = relative.TribeID },
                        RelativeTypeObj = new Models.ServiceRegistration.Requests.Relativetypeobj() { LookupValueID = relative.Relativetype },
                        A_Name = relative.FirstName_Arabic + " " + relative.SecondName_Arabic + " " + relative.ThirdName_Arabic + " " + relative.FourthName_Arabic + " " + relative.FifthName_Arabic,
                        E_Name = relative.FirstName_English + " " + relative.SecondName_English + " " + relative.ThirdName_English + " " + relative.FourthName_English + " " + relative.FifthName_English,
                        Source = "1",
                        IsDeleted = relative.IsDeleted.HasValue ? relative.IsDeleted.Value : false,
                    }
               );
                }

                var result = await networkService.HttpPostAsync<string>(resource, request, headers);
                if (result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    if (result.Result != null)
                    {
                        if (result.Result == "true")
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
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, data, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.UpdateRelative", ex);
            }
        }

        public async Task<bool> UpdateAttachments(List<ServiceAttachementData> data, string maritalStatus, string workStatusId, string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_UpdateRegistrationAttachements;

                GHQ.Logic.Models.ServiceRegistration.Requests.UpdateAttachmentRequest request = new GHQ.Logic.Models.ServiceRegistration.Requests.UpdateAttachmentRequest();
                request.CampaignAdminID = null;
                request.MaritalStatus = maritalStatus == null ? Constant.Constant.DefaultMaritalStatusId : maritalStatus;
                request.WorkStatusID = workStatusId == null ? Constant.Constant.DefaultWorkingTypeId : workStatusId;
                request.RegistrationAttachments = new List<Models.ServiceRegistration.Requests.UpdateAttachment>();
                foreach (var file in data)
                {
                    if (file.Attachment != null)
                    {
                        request.RegistrationAttachments.Add(new Models.ServiceRegistration.Requests.UpdateAttachment()
                        {
                            FileName = file.Attachment == null ? null : file.Attachment.FileName,
                            AttachmentCode = file.AttachmentCode,
                            FileID = file.Attachment == null ? null : file.Attachment.FileID,
                            ServiceAttachmentID = file.ServiceAttachmentID,
                            URL = null,
                            IsDeleted = file.IsDeleted,
                        });
                    }
                }

                var result = await networkService.HttpPostAsync<string>(resource, request, headers);
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
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, data, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.UpdateRelative", ex);
            }
        }

        public async Task<List<ServiceAttachementData>> GetServiceAttachement()
        {
            try
            {
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_GetServiceAttachement;
                var result = await networkService.HttpGetAsync<List<GetServiceAttachementResponse>>(resource, null);
                if (result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    if (result.Result != null)
                    {
                        var attachmets = ServiceAttachementTranslator.Translate(result.Result.Where(a => a.ForMobile).ToList());
                        return attachmets;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, null, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, "", "ServiceRegistrationService.GetServiceAttachement", ex);
            }
        }

        public async Task<bool> UploadAttachment(byte[] file, string fileName, string attachmentCode, string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);

                UploadImageRequest data = new UploadImageRequest() { AttachmentCode = attachmentCode, File = file, FileName = fileName };
                var resource = Constant.ServiceConstant.ApiBaseUrl + string.Format(Constant.ServiceConstant.Api_Registration_UploadFile);
                var result = await networkService.HttpPostAsync<List<UploadFileResponse>>(resource, data, headers);
                if (result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    if (result.Result != null && result.Result[0] != null && result.Result[0].IsDone)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, "", "ServiceRegistrationService.UploadAttachment", ex);
            }
        }

        public async Task<bool> DeleteFile(string fileId)
        {
            try
            {
                var resource = Constant.ServiceConstant.ApiBaseUrl + string.Format(Constant.ServiceConstant.Api_Registration_DeleteFile, fileId);
                var result = await networkService.HttpPostAsync<ImageFile>(resource, null, null);
                if (result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, "", "ServiceRegistrationService.DeleteFile", ex);
            }
        }

        public async Task<bool> Submit(List<ServiceAttachementData> data, string maritalStatus, string workStatusId, string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_SubmitAll;

                GHQ.Logic.Models.ServiceRegistration.Requests.UpdateAttachmentRequest request = new GHQ.Logic.Models.ServiceRegistration.Requests.UpdateAttachmentRequest();
                request.CampaignAdminID = null;
                request.MaritalStatus = maritalStatus == null ? Constant.Constant.DefaultMaritalStatusId : maritalStatus;
                request.WorkStatusID = workStatusId == null ? Constant.Constant.DefaultWorkingTypeId : workStatusId;
                request.RegistrationAttachments = new List<Models.ServiceRegistration.Requests.UpdateAttachment>();
                foreach (var file in data)
                {
                    if (file.Attachment != null)
                    {
                        request.RegistrationAttachments.Add(new Models.ServiceRegistration.Requests.UpdateAttachment()
                        {
                            FileName = file.Attachment == null ? null : file.Attachment.FileName,
                            AttachmentCode = file.AttachmentCode,
                            FileID = file.Attachment == null ? null : file.Attachment.FileID,
                            ServiceAttachmentID = file.ServiceAttachmentID,
                            URL = null,
                            IsDeleted = file.IsDeleted,
                        });
                    }
                }

                var result = await networkService.HttpPostAsync<string>(resource, request, headers);
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
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, data, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.Submit", ex);
            }
        }

        public async Task<bool> GetIsRegistered(string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_GetIsRegistered;

                var result = await networkService.HttpGetAsync<string>(resource, headers);
                if (result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    if (result.Result != null)
                    {
                        if (result.Result == "true")
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
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, null, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.GetIsRegistered", ex);
            }
        }

        public async Task<UpdateContactData> FillUpdateRequestData(string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_FillUpdateRequestData;

                var result = await networkService.HttpGetAsync<UpdateContactData>(resource, headers);
                if (result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    if (result.Result != null)
                    {
                        return result.Result;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, null, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.FillUpdateRequestData", ex);
            }
        }

        public async Task<bool> AddUpdateRequest(UpdateContactData data, string accessToken)
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + accessToken);
                var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Registration_AddUpdateRequest;

                var result = await networkService.HttpPostAsync<string>(resource, data, headers);
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
                    throw new BackendException(result.ErrorResponse.ErrorMessagesString, data, resource, null);
                }
            }
            catch (UnAuthorizedException ex)
            {
                accountService.HandleUnAuthorizedException(ex);
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, string.Format("{0}:{1}", "accessToken", accessToken), "ServiceRegistrationService.Submit", ex);
            }
        }
    }
}
