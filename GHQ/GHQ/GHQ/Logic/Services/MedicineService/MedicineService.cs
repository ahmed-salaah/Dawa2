using GHQ.Logic.Translators;
using Logic.Models.Data;
using Service.Database;
using Service.Internet;
using Service.Network;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GHQ.Logic.Service.Lookup
{
    public class MedicineService : IMedicineService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        #endregion

        public MedicineService(INetworkService _networkService, IInternetService _internetService)
        {
            networkService = _networkService;
            internetService = _internetService;
        }

        public Medicine SelectedMedicine { get; set; }

		public Medicine FilteredMedicine { get; set; }


		public async Task<Medicine> AddEditMedicine(Medicine medicine)
        {
            try
            {
                SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
                Database.Entities.Medicine m = MedicineTranslator.ModelToEntity(medicine);

                if (medicine.Id != 0)
                {
                    int rows = database.Update(m);
                }
                else
                {
                    int rows = database.Insert(m);
                }

                return medicine;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<Medicine>> GetMedicine(string medicineName, string doctorName, string diesesName, DateTime StartDate, DateTime EndDate)
        {
            SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
            var medicineList = database.Table<Database.Entities.Medicine>().Where(m => m.Name == medicineName || m.DoctorName == doctorName || m.DiseaseName == diesesName || m.StartDate.Date == StartDate.Date || m.EndDate == EndDate);
            if (medicineList != null && medicineList.Count() > 0)
            {
                var translatedMedicineList = MedicineTranslator.EntitiesToModels(medicineList.ToList());
                return translatedMedicineList;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Medicine>> GetCurrentMedicine()
        {
            SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
            var medicineList = database.Table<Database.Entities.Medicine>().Where(m => m.StartDate <= DateTime.Now || m.EndDate >= DateTime.Now);
            if (medicineList != null && medicineList.Count() > 0)
            {
                var translatedMedicineList = MedicineTranslator.EntitiesToModels(medicineList.ToList());
                return translatedMedicineList;
            }
            else
            {
                return null;
            }

        }

        public async Task<List<Medicine>> GetAllMedicine()
        {
            SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
            var medicineList = database.Table<Database.Entities.Medicine>().OrderByDescending(m => m.StartDate);
            if (medicineList != null && medicineList.Count() > 0)
            {
                var translatedMedicineList = MedicineTranslator.EntitiesToModels(medicineList.ToList());
                return translatedMedicineList;
            }
            else
            {
                return null;
            }
        }

        public async Task<Medicine> MissedMedicine(int medicineId)
        {
            SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
            var medicine = database.Table<Database.Entities.Medicine>().FirstOrDefault(m => m.Id == medicineId);
            medicine.IsMissed = false;
            int rows = database.Update(medicine);
            var translatedMedicine = MedicineTranslator.EntityToModel(medicine);
            return translatedMedicine;

        }

        public async Task<Medicine> GetNextMedicine()
        {
            SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
            var medicine = database.Table<Database.Entities.Medicine>().OrderByDescending(m => m.NextDate).FirstOrDefault();
            var translatedMedicine = MedicineTranslator.EntityToModel(medicine);
            return translatedMedicine;

        }
    }
}
