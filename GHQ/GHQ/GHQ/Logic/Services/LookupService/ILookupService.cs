using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.Lookup
{
    public interface ILookupService
    {
        Task<List<LookupData>> GetGenderAsync();

        Task<List<LookupData>> GetNationalityAsync();

        Task<List<LookupData>> GetTribeAsync();

        Task<List<LookupData>> GetMaritalStatusAsync();

        Task<List<LookupData>> GetPassportTypeAsync();

        Task<List<LookupData>> GetPassportIssuanceLocationsync();

        Task<List<LookupData>> GetAreaAync();

        Task<List<LookupData>> GetEmiratesAync();

        Task<List<LookupData>> GetWorkEntityTypeAync();

        Task<List<LookupData>> GetRelativesTypesAync();

        Task<List<LookupData>> GetRelativesStatusAync();

        Task<List<LookupData>> GetAcademicQualificationAync();

        Task<List<LookupData>> GetCountriesnAync();

        Task<List<LookupData>> GetEducationInstitutesAync();

        Task<List<LookupData>> GetWorkEntityAync();

        Task<List<LookupData>> GetMajorSpecialtyAync();

        Task<List<LookupData>> GetSecondarySpecialtyAync(string majorSpeciality);

        Task<List<LookupData>> GetHighShcoolAync();

        Task<List<LookupData>> GetWorkTypesAync();

        Task<List<LookupData>> GetMilitaryTypes();
    }
}
