using GHQ.Logic.Models.Data.Registration;
using GHQ.Logic.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.ServiceRegistration
{
    public interface IServiceRegistrationService
    {
        Task<RegistrationData> GetCandidateInfoByEmiratesId(string accessToken);

        Task<List<BREData>> GetBRConfiguration();

        Task<bool> UpdateCandidateData(RegistrationData data, string workStatusId, string accessToken);

        Task<bool> UpdateWorkData(Work data, string maritalStatus, string workStatusId, string accessToken);

        Task<bool> UpdateAddress(Address data, string maritalStatus, string workStatusId, string accessToken);

        Task<bool> UpdateRelative(List<Relative> data, string maritalStatus, string workStatusId,bool onlySon, string accessToken);

        Task<bool> UpdateAcademicQualificationsData(Academicqualification data, string maritalStatus, string workStatusId, string accessToken);

        Task<bool> UpdateAttachments(List<ServiceAttachementData> data, string maritalStatus, string workStatusId, string accessToken);

        Task<bool> UploadAttachment(byte[] file, string fileName, string attachmentCode, string accessToken);

        Task<bool> DeleteFile(string fileId);

        Task<List<ServiceAttachementData>> GetServiceAttachement();

        Task<bool> Submit(List<ServiceAttachementData> data, string maritalStatus, string workStatusId, string accessToken);

        Task<bool> GetIsRegistered(string accessToken);

        Task<UpdateContactData> FillUpdateRequestData(string accessToken);

        Task<bool> AddUpdateRequest(UpdateContactData data,string accessToken);
    }
}
