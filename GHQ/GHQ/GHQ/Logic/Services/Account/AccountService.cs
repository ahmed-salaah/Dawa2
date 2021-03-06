﻿using System;
using System.Threading.Tasks;
using Exceptions;
using GHQ.Logic.Translators;
using GHQLogic.Models.Data;
using Service.Database;
using Service.Dialog;
using Service.Internet;
using Service.Naviagtion;
using Service.Network;
using SQLite;
using Xamarin.Forms;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

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

        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        public NewUser CurrentAccount { get; set; }

        public void HandleUnAuthorizedException(UnAuthorizedException ex)
        {

        }

        public async Task<NewUser> AddEditUser(NewUser user)
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
                user.Id = 1; //This will be removed after backend implemnted
                CurrentAccount = user;
                AppSettings.AddOrUpdateValue<int>(Constant.Constant.UserIDKey, user.Id);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public NewUser GetUser(int userId)
        {
            try
            {
                SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
                var user = database.Table<Database.Entities.User>().FirstOrDefault(m => m.Id == userId);
                if (user != null)
                {
                    var translateduser = UserTranslator.EntityToModel(user);
                    CurrentAccount = translateduser;
                    return CurrentAccount;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<NewUser> Login(string userName, string Password)
        {
            try
            {
                SQLiteConnection database = DependencyService.Get<IDatabaseService>().GetInstance();
                var user = database.Table<Database.Entities.User>().FirstOrDefault(m => m.UserName.ToLower() == userName.ToLower() && m.Password == Password);
                if (user != null)
                {
                    var translateduser = UserTranslator.EntityToModel(user);
                    CurrentAccount = translateduser;
                    AppSettings.AddOrUpdateValue<int>(Constant.Constant.UserIDKey, translateduser.Id);
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
