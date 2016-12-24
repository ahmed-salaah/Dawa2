using Exceptions;
using Logic.Models.Data;
using Models;
using Service.Internet;
using Service.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Image = "", Name = "جلوكوفيج إكس ر", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = false });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Image = "", Name = "أورغامتريل", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = true });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Image = "", Name = "بانادول كولد اند فلو اقراص بيضوية", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = false });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Image = "", Name = "زيرتك", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = false });
                medicineList.Add(new Medicine() { Id = 1, DiseaseName = "Aids", DoctorName = "Sean Conary", NextDate = DateTime.Now, EndDate = DateTime.Now, Image = "", Name = "لورادي اقراص", Note = "واحد قرص يوميا بعد العشاء", StartDate = DateTime.Now, IsMissed = true });
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


    }
}
