using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exceptions;
using GHQ.Logic.Database.Entities;
using GHQ.Logic.Translators;
using GHQLogic.Models.Data;
using Service.Database;
using Service.Dialog;
using Service.Internet;
using Service.Naviagtion;
using Service.Network;
using SQLite;
using Xamarin.Forms;

namespace GHQ.Logic.Service.Account
{
    public class AccountService : IAccountService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        INavigationService navigationService;
        IDialogService dialogService;
        #endregion

        public AccountService(INetworkService _networkService, IInternetService _internetService, INavigationService _navigationService, IDialogService _dialogService)
        {
            networkService = _networkService;
            internetService = _internetService;
            navigationService = _navigationService;
            dialogService = _dialogService;
        }

        public void HandleUnAuthorizedException(UnAuthorizedException ex)
        {

        }
		public async Task<NewUSer> AddEditUser(NewUSer user)
		{
			try
			{
				SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
				Database.Entities.User m = UserTranslator.ModelToEntity(user);

				if (user.Id != 0)
				{
					int rows = database.Update(m);
				}
				else
				{
					int rows = database.Insert(m);
				}

				return user;
			}
			catch (Exception ex)
			{
				return null;
			}

		}

		public async Task<NewUSer> Login(string userName, string Password)
		{
			try
			{
				SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
				var user = database.Table<Database.Entities.User>().FirstOrDefault(m => m.UserName.ToLower() == userName.ToLower() && m.Password == Password);
				if (user != null)
				{
					var translateduser = UserTranslator.EntityToModel(user);
					return translateduser;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				return null;

			}
		
		}

    }
}
