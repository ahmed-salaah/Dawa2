namespace GHQ.Logic.Constant
{
    static public class ServiceConstant
    {
        //WebAPI:https://registration.uaensr.ae/regapi/api/

        static public readonly string BaseUrl_Prod = "https://registration.uaensr.ae";
        static public readonly string BaseUrl_Dev = "http://ghq-reg.linkdev.com";
        static public readonly string BaseUrl = Constant.IsProduction ? BaseUrl_Prod : BaseUrl_Dev;

        static public readonly string ApiBaseUrl_Prod = BaseUrl + "/regapi/api";
        static public readonly string ApiBaseUrl_Dev = BaseUrl + "/WebApis/api";
        static public readonly string ApiBaseUrl = Constant.IsProduction ? ApiBaseUrl_Prod : ApiBaseUrl_Dev;

        static public readonly string ApiSharePointBaseUrl = "https://www.uaensr.ae/_api";
        static public readonly string ApiPhotoAlbums = "https://dl.dropboxusercontent.com/u/15405714/Android_icons-assets/GHQPhotoGalleryJson.txt";
        static public readonly string InquiryUrl = "https://www.uaensr.ae/Pages/%D8%A7%D8%AA%D8%B5%D9%84-%D8%A8%D9%86%D8%A7.aspx";

        static public readonly string AuthorizeBaseUrl_Prod = "https://login.uaensr.ae";
        static public readonly string AuthorizeBaseUrl_Dev = "https://ghq-identityserver.linkdev.com";
        static public readonly string AuthorizeBaseUrl = Constant.IsProduction ? AuthorizeBaseUrl_Prod : AuthorizeBaseUrl_Dev;

        static public readonly string AuthorizeUrl = AuthorizeBaseUrl + "/core/connect/authorize";
        static public readonly string LogoutUrl = AuthorizeBaseUrl + "/core/logout";

        static public readonly string Api_Registeration_GetStepOfAccountCreation = "/AccountCreation/GetStepOfAccountCreation";
        static public readonly string Api_Registeration_GetMOIUserInfo = "/AccountCreation/GetMOIUserInfo";
        static public readonly string Api_Registeration_GetUserMobileNumbers = "/AccountCreation/GetUserMobileNumbers";
        static public readonly string Api_Registeration_SendVerificationCodeBySMS = "/AccountCreation/SendVerificationCodeBySMS";
        static public readonly string Api_Registeration_SendVerificationCodeByEmail = "/AccountCreation/SendVerificationCodeByEmail";
        static public readonly string Api_Registeration_VerifyMyCode = "/AccountCreation/VerifyMyCode";
        static public readonly string Api_Registeration_IsEmailRequired = "/AccountCreation/IsEmailRequired";
        static public readonly string Api_Registeration_UpdateUserAccount = "/AccountCreation/UpdateUserAccount";
        static public readonly string Api_Registeration_GetUserByEmiratesId = "/AccountCreation/GetUserByEmiratesId";

        static public readonly string Api_Lookups_WorkingType = "/Lookups?code=WS";
        static public readonly string Api_Lookups_MilitaryType = "/Lookups?code=ME";
        static public readonly string Api_Lookups_Gender = "/Lookups?code=GN";
        static public readonly string Api_Lookups_Nationality = "/Lookups?code=NL";
        static public readonly string Api_Lookups_Tribe = "/Lookups?code=TRB";
        static public readonly string Api_Lookups_MaritalStatus = "/Lookups?code=MS";
        static public readonly string Api_Lookups_PassportType = "/Lookups?code=PT";
        static public readonly string Api_Lookups_PassportIssuanceLocation = "/Lookups?code=PIL";
        static public readonly string Api_Lookups_Cities = "/Lookups?code=AR";
        static public readonly string Api_Lookups_Emirate = "/Lookups?code=EM";
        static public readonly string Api_Lookups_WorkEntityType = "/Lookups?code=WET";
        static public readonly string Api_Lookups_RelativeTypes = "/Lookups?code=RL";
        static public readonly string Api_Lookups_RelativeStatus = "/Lookups?code=AL";

        static public readonly string Api_Lookups_AcademicQualification = "/Lookups?code=AQ";
        static public readonly string Api_Lookups_Countries = "/Lookups?code=CN";
        static public readonly string Api_Lookups_EducationInstitutes = "/Lookups?code=EI";
        static public readonly string Api_Lookups_WorkEntity = "/Lookups?code=WE";
        static public readonly string Api_Lookups_MajorSpecialty = "/Lookups?code=MJR";
        static public readonly string Api_Lookups_SecondarySpecialty = "/Lookups?code=MNR&ParentID={0}";
        static public readonly string Api_Lookups_HighShcool = "/Lookups?code=HS";

        static public readonly string Api_Get_News = "/web/lists/GetByTitle('News')/Items";

        static public readonly string Api_Get_Notifications = "/Notifications/GetNotificationsForMobile?pageSize=&pageIndex=&notificationType=";
        static public readonly string Api_RegisterUserDevices = "/Notifications/RegisterUserDevice?deviceID={0}";
        static public readonly string Api_UnRegisterUserDevice = "/Notifications/UnRegisterUserDevice?deviceID={0}";

        static public readonly string Api_Registration_SubmitAll = "/Registration/SubmitAll";
        static public readonly string Api_Registration_UpdateRegistrationAttachements = "/Registration/UpdateRegistrationAttachements";
        static public readonly string Api_Registration_GetCandidateInfoByEmiratesId = "/Registration/GetCandidateInfoByEmiratesId";
        static public readonly string Api_Registration_UpdateCandidateData = "/Registration/UpdateCandidateData";
        static public readonly string Api_Registration_UpdateWorkData = "/Registration/UpdateWorkData";
        static public readonly string Api_Registration_UpdateAcademicQualificationsData = "/Registration/UpdateAcademicQualificationsData";
        static public readonly string Api_Registration_UpdateAddress = "/Registration/UpdateAddress";
        static public readonly string Api_Registration_UpdateRelative = "/Registration/AddRelatives";
        static public readonly string Api_Registration_GetServiceAttachement = "/Registration/GetServiceAttachement";
        static public readonly string Api_Registration_UploadFile = "/Registration/UploadFile";
        static public readonly string Api_Registration_DeleteFile = "/Registration/DeleteFile?FileID={0}";
        static public readonly string Api_Registration_GetFile = "/Registration/GetFile";
        static public readonly string Api_Registration_GetIsRegistered = "/registration/IsRegistered";
        static public readonly string Api_Registration_AddUpdateRequest = "/Registration/AddUpdateRequest";
        static public readonly string Api_Registration_FillUpdateRequestData = "/Registration/FillUpdateRequestData";

        static public readonly string Api_GetPhotos = "/web/GetFolderByServerRelativeUrl('/PhotoGallery/{0}')/Files";

        static public readonly string GetBRConfiguration = "/BusinessRule/GetBRConfiguration?id=1";

        static public readonly string PhotoBaseURL = "https://www.uaensr.ae";
    }
}
