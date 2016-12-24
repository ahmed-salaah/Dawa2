using Exceptions;
using Models;
using Service.Internet;
using Service.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.Lookup
{
    public class LookupService : ILookupService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        #endregion

        public LookupService(INetworkService _networkService, IInternetService _internetService)
        {
            networkService = _networkService;
            internetService = _internetService;
        }

        public async Task<List<LookupData>> GetGenderAsync()
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
                throw new ApplicationError(ex.Message, null, "LookupService.GetGender", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetGender", ex);
            }
        }


    }
}
