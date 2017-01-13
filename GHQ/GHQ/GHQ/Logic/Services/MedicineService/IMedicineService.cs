using Logic.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.Lookup
{
    public interface IMedicineService
    {
        Task<List<Medicine>> GetHistory();

        Task<List<Medicine>> GetSchedule();

        Medicine AddMedicine(Medicine medicine);
    }
}
