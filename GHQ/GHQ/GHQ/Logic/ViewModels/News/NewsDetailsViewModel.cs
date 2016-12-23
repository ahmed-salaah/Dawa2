using System;
using Exceptions;
using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Models.Data.News;
using GHQ.Logic.Service.News;
using GHQ.Resources.Strings;
using Models;
using Service.Dialog;
using Service.Exception;

namespace GHQ
{
    public class NewsDetailsViewModel : BaseViewModel
    {
        public NewsDetailsViewModel(INewsService _newsService, IExceptionService _excpetionService, IDialogService _dialogService)
        {
            newsService = _newsService;
            excpetionService = _excpetionService;
            dialogService = _dialogService;
        }

        #region Private Members


        INewsService newsService;
        IExceptionService excpetionService;
        IDialogService dialogService;
        #endregion

		#region Properties

		private string _Title;
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				Set(() => Title, ref _Title, value);
			}
		}

		private String _DateString;
		public string DateString
		{
			get
			{
				return _DateString;
			}
			set
			{
				Set(() => DateString, ref _DateString, value);
			}
		}
		private string _EventDescription;
		public string EventDescription
		{
			get
			{
				return _EventDescription;
			}
			set
			{
				Set(() => EventDescription, ref _EventDescription, value);
			}
		}


		private string _Image;
		public string Image
		{
			get
			{
				return _Image ;
			}
			set
			{
				Set(() => Image, ref _Image, value);
			}
		}

		#endregion
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
				Title =  newsService.SelectedNew.Title;
				Image = newsService.SelectedNew.Image;
				EventDescription = newsService.SelectedNew.EventDescription;
				DateString = newsService.SelectedNew.DateString;
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
    }
}
