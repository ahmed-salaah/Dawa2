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
                return null;
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
