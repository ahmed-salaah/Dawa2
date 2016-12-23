using Exceptions;
using GHQ.Logic.Models.Response;
using GHQ.Logic.Translators;
using GHQ.Resources.Strings;
using Models;
using Newtonsoft.Json;
using Service.Internet;
using Service.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.Lookup
{
    public class LookupService : ILookupService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        #endregion

        public LookupService(INetworkService _networkService, IInternetService _internetService)
        {
            networkService = _networkService;
            internetService = _internetService;
        }

        public async Task<List<LookupData>> GetGenderAsync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_Gender;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetGender", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetGender", ex);
            }
        }

        public async Task<List<LookupData>> GetNationalityAsync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_Nationality;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetNationality", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetNationality", ex);
            }

        }

        public async Task<List<LookupData>> GetTribeAsync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_Tribe;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetTribeAsync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetTribeAsync", ex);
            }
        }

        public async Task<List<LookupData>> GetMaritalStatusAsync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_MaritalStatus;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetMaritalStatusAsync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetMaritalStatusAsync", ex);
            }
        }

        public async Task<List<LookupData>> GetPassportTypeAsync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_PassportType;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetPassportTypeAsync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetPassportTypeAsync", ex);
            }
        }

        public async Task<List<LookupData>> GetPassportIssuanceLocationsync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_PassportIssuanceLocation;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetPassportIssuanceLocationsync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetPassportIssuanceLocationsync", ex);
            }
        }

        public async Task<List<LookupData>> GetAreaAync()
        {

            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_Cities;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetAreaAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetAreaAync", ex);
            }
        }

        public async Task<List<LookupData>> GetEmiratesAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_Emirate;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetEmiratesAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetEmiratesAync", ex);
            }
        }

        public async Task<List<LookupData>> GetWorkEntityTypeAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_WorkEntityType;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetWorkEntityTypeAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetWorkEntityTypeAync", ex);
            }
        }

        public async Task<List<LookupData>> GetRelativesTypesAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_RelativeTypes;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetRelativesTypesAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetRelativesTypesAync", ex);
            }
        }

        public async Task<List<LookupData>> GetRelativesStatusAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_RelativeStatus;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetRelativesTypesAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetRelativesTypesAync", ex);
            }
        }

        public async Task<List<LookupData>> GetAcademicQualificationAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_AcademicQualification;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetAcademicQualificationAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetAcademicQualificationAync", ex);
            }
        }

        public async Task<List<LookupData>> GetEducationInstitutesAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_EducationInstitutes;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetEducationInstitutesAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetEducationInstitutesAync", ex);
            }
        }

        public async Task<List<LookupData>> GetWorkEntityAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_WorkEntity;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetWorkEntityAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetWorkEntityAync", ex);
            }
        }

        public async Task<List<LookupData>> GetMajorSpecialtyAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_MajorSpecialty;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetMajorSpecialtyAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetMajorSpecialtyAync", ex);
            }
        }

        public async Task<List<LookupData>> GetSecondarySpecialtyAync(string majorSpeciality)
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + string.Format(Constant.ServiceConstant.Api_Lookups_SecondarySpecialty, majorSpeciality);
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetMajorSpecialtyAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetMajorSpecialtyAync", ex);
            }
        }

        public async Task<List<LookupData>> GetHighShcoolAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_HighShcool;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetCountriesnAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetCountriesnAync", ex);
            }
        }

        public async Task<List<LookupData>> GetCountriesnAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_Countries;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetCountriesnAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetCountriesnAync", ex);
            }
        }

        public async Task<List<LookupData>> GetWorkTypesAync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_WorkingType;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            value.Insert(0, new LookupData() { Id = "-1", ValueAr = AppResources.NewAccount_Combo_Placeholder, ValueEn = AppResources.NewAccount_Combo_Placeholder });
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetWorkTypesAync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetWorkTypesAync", ex);
            }
        }

        public async Task<List<LookupData>> GetMilitaryTypes()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiBaseUrl + Constant.ServiceConstant.Api_Lookups_MilitaryType;
                    var result = await networkService.HttpGetAsync<List<LookupValueResponse>>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            var value = LookupTranslator.Translate(result.Result);
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException(JsonConvert.SerializeObject(result.ErrorResponse), null, resource, null);
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetMilitaryTypes", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetMilitaryTypes", ex);
            }
        }
    }
}
