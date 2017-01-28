using Enums;
using Logic.Models.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.Lookup
{
    public interface IMedicineService
    {
        Medicine SelectedMedicine { get; set; }
        Medicine FilteredMedicine { get; set; }

        Task<Medicine> AddEditMedicine(Medicine medicine);
        Task<List<Medicine>> GetMedicine(string medicineName, string doctorName, string diesesName, DateTime StartDate, DateTime EndDate);
        Task<List<Medicine>> GetCurrentMedicine();
        Task<List<Medicine>> GetAllMedicine();
        Task<Medicine> MissedMedicine(int medicineId);
        Task<Medicine> UpdateNextMedicin(int medicineId, ReminderRepeatOptions option);
        Task<Medicine> GetNextMedicine();
    }
}
