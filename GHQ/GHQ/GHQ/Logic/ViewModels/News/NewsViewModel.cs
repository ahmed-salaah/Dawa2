using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Models.Data.News;
using GHQ.Logic.Service.News;
using Models;
using Service.Naviagtion;
using Exceptions;
using GHQ.Resources.Strings;
using Service.Dialog;
using Service.Exception;
using GHQ.UI.Pages.News;

namespace GHQ.Logic.ViewModels.News
{
    public class NewsViewModel : BaseViewModel
    {
        public NewsViewModel(INewsService _newsService, IDialogService _dialogService, INavigationService _navigationService, IExceptionService _excpetionService)
        {
            newsService = _newsService;
            dialogService = _dialogService;
            navigationService = _navigationService;
            excpetionService = _excpetionService;
        }

        #region Private Members

        IDialogService dialogService;
        INewsService newsService;
        INavigationService navigationService;
        IExceptionService excpetionService;

        #endregion

        #region Properties


        private ObservableCollection<NewsData> _News;
        public ObservableCollection<NewsData> News
        {
            get { return _News; }
            set
            {
                Set(() => News, ref _News, value);
            }
        }

        private NewsData _SelectedNews;
        public NewsData SelectedNews
        {
            get { return _SelectedNews; }
            set
            {
                Set(() => SelectedNews, ref _SelectedNews, value);
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
                var response = await newsService.GetNewsAsync();
                if (response != null)
                {
                    News = new ObservableCollection<NewsData>(response);
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

        private RelayCommand<NewsData> _OnNewsSelectedCommand;
        public RelayCommand<NewsData> OnNewsSelectedCommand
        {
            get
            {
                if (_OnNewsSelectedCommand == null)
                {
                    _OnNewsSelectedCommand = new RelayCommand<NewsData>(OpenNewstDetailsPage);
                }
                return _OnNewsSelectedCommand;
            }
        }

        private void OpenNewstDetailsPage(NewsData news)
        {
			newsService.SelectedNew = news;
            navigationService.NavigateToPage(typeof(NewsDetailsPage));
        }

        #endregion

    }
}
