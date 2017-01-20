using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.Lookup
{
    public interface ILookupService
    {
        Task<List<LookupData>> GetGenderAsync();

        Task<List<LookupData>> GetMealTypesAsync();

        Task<List<LookupData>> GetMealTimeTypesAsync();
    }
}
