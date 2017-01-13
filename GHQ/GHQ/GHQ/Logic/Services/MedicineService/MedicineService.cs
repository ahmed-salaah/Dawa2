using Exceptions;
using Logic.Models.Data;
using Service.Database;
using Service.Internet;
using Service.Network;
using SQLite;
using System;
using System.Collections.Generic;
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

        public async Task<List<Medicine>> GetHistory()
        {
            try
            {
                List<Medicine> medicineList = new List<Medicine>();
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Name = "جلوكوفيج إكس ر", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = false });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Name = "أورغامتريل", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = true });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Name = "بانادول كولد اند فلو اقراص بيضوية", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = false });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Name = "زيرتك", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = false });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Name = "لورادي اقراص", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = true });
                return medicineList;
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
                throw new ApplicationError(ex.Message, null, "MedicineService.GetHistory", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "MedicineService.GetHistory", ex);
            }
        }

        public async Task<List<Medicine>> GetSchedule()
        {
            try
            {
                List<Medicine> medicineList = new List<Medicine>();
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Name = "جلوكوفيج إكس ر", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = false });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Name = "أورغامتريل", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = true });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Name = "بانادول كولد اند فلو اقراص بيضوية", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = false });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Name = "زيرتك", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = false });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Name = "لورادي اقراص", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = true });
                return medicineList;
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
                throw new ApplicationError(ex.Message, null, "MedicineService.GetSchedule", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "MedicineService.GetSchedule", ex);
            }
        }

        public async Task<Medicine> AddMedicine(Medicine medicine)
        {
            try
            {
                SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
                //var m = database.Table<Database.Entities.Medicine>().FirstOrDefault();
                Database.Entities.Medicine m = new Database.Entities.Medicine()
                {
                    Id = medicine.Id,
                    DiseaseName = medicine.DiseaseName,
                    DoctorName = medicine.DoctorName,
                    EndDate = medicine.EndDate,
                    ImagePath = medicine.ImagePath,
                    IsMissed = medicine.IsMissed,
                    Name = medicine.Name,
                    NexDate = medicine.NextDate,
                    Note = medicine.Note,
                    StartDate = medicine.StartDate,
                    VoiceNotePath = medicine.VoiceNotePath,
                };

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
    }
}
