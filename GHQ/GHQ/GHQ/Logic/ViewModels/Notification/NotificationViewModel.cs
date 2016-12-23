using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Models;
using Service.Naviagtion;
using Exceptions;
using GHQ.Resources.Strings;
using Service.Dialog;
using Service.Exception;
using GHQ.Logic.Service.Notification;
using GHQ.Logic.Models.Data.Notification;

namespace GHQ.Logic.ViewModels.Notification
{
    public class NotificationViewModel : BaseViewModel
    {
        public NotificationViewModel(INotificationService _notificationService, IDialogService _dialogService, INavigationService _navigationService, IExceptionService _excpetionService)
        {
            notificationService = _notificationService;
            dialogService = _dialogService;
            navigationService = _navigationService;
            excpetionService = _excpetionService;
        }

        #region Private Members

        IDialogService dialogService;
        INotificationService notificationService;
        INavigationService navigationService;
        IExceptionService excpetionService;

        #endregion

        #region Properties


        private ObservableCollection<NotificationData> _Notifications;
        public ObservableCollection<NotificationData> Notifications
        {
            get { return _Notifications; }
            set
            {
                Set(() => Notifications, ref _Notifications, value);
            }
        }

        #endregion

        #region Private Methods

        #endregion

        #region Commands

        #region OnIntializeCommand

        private RelayCommand _OnIntializeCommand;
        public RelayCommand OnIntializeCommand
        {
            get
            {
                if (_OnIntializeCommand == null)
                {
                    _OnIntializeCommand = new RelayCommand(Intialize);
                }
                return _OnIntializeCommand;
            }
        }
        async private void Intialize()
        {
            try
            {
                IsLoading = true;
                var response = await notificationService.GetNotificationsAsync();
                if (response != null)
                {
                    Notifications = new ObservableCollection<NotificationData>(response);
                }
            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
            }
            catch (BackendException ex)
            {
                await excpetionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_BackendTitle, ex.Message);
            }
            catch (ApplicationError ex)
            {
                await excpetionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_ApplicationTitle, ex.Message);
            }
            catch (System.Exception ex)
            {
                await excpetionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_GeneralTitle, ex.Message);
            }
            finally
            {
                IsLoading = false;
                IsPageEnabled = true;
            }
        }

        #endregion


        #endregion
    }
}
