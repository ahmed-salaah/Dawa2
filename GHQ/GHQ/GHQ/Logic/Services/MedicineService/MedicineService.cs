using GHQ.Logic.Service.Account;
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
using Enums;

namespace GHQ.Logic.Service.Lookup
{
    public class MedicineService : IMedicineService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        IAccountService accountService;
        #endregion

        public MedicineService(INetworkService _networkService, IInternetService _internetService, IAccountService _accountService)
        {
            accountService = _accountService;
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
                m.User_Id = accountService.CurrentAccount.Id;
                if (medicine.Id != 0)
                {
                    int rows = database.Update(m);
                }
                else
                {
                    int inserted = database.Insert(m);
                }

                return medicine;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private void Database_TableChanged(object sender, NotifyTableChangedEventArgs e)
        {
        }

        public async Task<List<Medicine>> GetMedicine(string medicineName, string doctorName, string diesesName, DateTime StartDate, DateTime EndDate)
        {
            SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
            var currentUserId = accountService.CurrentAccount.Id;

            var medicineList = database.Table<Database.Entities.Medicine>().Where(m => m.User_Id == currentUserId &&
            m.Name.ToLower().Contains(medicineName) ||
            m.DoctorName.ToLower().Contains(doctorName) ||
            m.DiseaseName.ToLower().Contains(diesesName) ||
            m.StartDate == StartDate ||
            m.EndDate == EndDate);

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
            var currentUserId = accountService.CurrentAccount.Id;
            var medicineList = database.Table<Database.Entities.Medicine>().Where(m => m.User_Id == currentUserId && m.StartDate <= DateTime.Now || m.EndDate >= DateTime.Now);
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
            var currentUserId = accountService.CurrentAccount.Id;
            var medicineList = database.Table<Database.Entities.Medicine>().Where(m => m.User_Id == currentUserId).OrderByDescending(m => m.StartDate);
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
            var currentUserId = accountService.CurrentAccount.Id;
            var medicine = database.Table<Database.Entities.Medicine>().FirstOrDefault(m => m.User_Id == currentUserId && m.Id == medicineId);
            medicine.IsMissed = false;
            int rows = database.Update(medicine);
            var translatedMedicine = MedicineTranslator.EntityToModel(medicine);
            return translatedMedicine;

        }

        public async Task<Medicine> GetNextMedicine()
        {
            SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
            var currentUserId = accountService.CurrentAccount.Id;
            var medicine = database.Table<Database.Entities.Medicine>().OrderByDescending(m => m.NextDate).FirstOrDefault(m => m.User_Id == currentUserId);
            var translatedMedicine = MedicineTranslator.EntityToModel(medicine);
            return translatedMedicine;

        }

        public async Task<Medicine> UpdateNextMedicin(int medicineId, ReminderRepeatOptions option)
        {
            SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
            var currentUserId = accountService.CurrentAccount.Id;
            var medicine = database.Table<Database.Entities.Medicine>().FirstOrDefault(m => m.User_Id == currentUserId && m.Id == medicineId);
            var addedDays = 0;
            if (option == ReminderRepeatOptions.Daily || option == ReminderRepeatOptions.EventBased)
            {
                addedDays = 1;
            }
            else if (option == ReminderRepeatOptions.Weekly)
            {
                addedDays = 7;
            }
            else if (option == ReminderRepeatOptions.Monthly)
            {
                addedDays = 24;
            }
            else if (option == ReminderRepeatOptions.Yearly)
            {
                addedDays = 365;
            }
            medicine.NextDate = medicine.NextDate.AddDays(addedDays);
            int rows = database.Update(medicine);
            var translatedMedicine = MedicineTranslator.EntityToModel(medicine);
            return translatedMedicine;
        }
    }
}
