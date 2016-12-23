using System.Collections.ObjectModel;
using Exceptions;
using GalaSoft.MvvmLight.Command;
using Service.Dialog;
using GHQ.Logic.Models.Data.PhotosData;
using GHQ.Logic.Service.PhotoGallery;
using GHQ.Resources.Strings;
using Models;
using Service.Exception;
using Service.Naviagtion;
using GHQ.UI.Pages.PhotoGallery;

namespace GHQ.Logic.ViewModels.PhotoGallery
{
    public class PhotoAlbumViewMiodel : BaseViewModel
    {
        public PhotoAlbumViewMiodel(IPhotoGalleryService _photoGalleryService, IDialogService _dialogService, IExceptionService _excpetionService, INavigationService _navigationService)
        {
            photoGalleryService = _photoGalleryService;
            dialogService = _dialogService;
            excpetionService = _excpetionService;
            navigationService = _navigationService;
        }

        #region Private Members

        IPhotoGalleryService photoGalleryService;
        IDialogService dialogService;
        IExceptionService excpetionService;
        INavigationService navigationService;
        #endregion

        #region Properties

        private ObservableCollection<PhotoAlbum> _Albums;

        public ObservableCollection<PhotoAlbum> Albums
        {
            get { return _Albums; }
            set
            {
                Set(() => Albums, ref _Albums, value);
            }
        }


        private PhotoAlbum _SelectedAlbum;

        public PhotoAlbum SelectedAlbum
        {
            get { return _SelectedAlbum; }
            set
            {
                Set(() => SelectedAlbum, ref _SelectedAlbum, value);
            }
        }
        #endregion

        #region Private Methods
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
                var response = await photoGalleryService.GetPhotoALbumssAsync();
                if (response != null)
                {
                    Albums = new ObservableCollection<PhotoAlbum>(response);
                }

                //           var response = await photoGalleryService.GetPhotosAsync();
                //           if (response != null)
                //           {
                //Photos = new ObservableCollection<PhotosData>(response);
                //           }
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

        #region Commands


        #region PhotoSelectedCommand

        private RelayCommand<PhotoAlbum> _OnAlbumSelectedCommand;
        public RelayCommand<PhotoAlbum> OnAlbumSelectedCommand
        {
            get
            {
                if (_OnAlbumSelectedCommand == null)
                {
                    _OnAlbumSelectedCommand = new RelayCommand<PhotoAlbum>(OpenAlbumPage);
                }
                return _OnAlbumSelectedCommand;
            }
        }
        async private void OpenAlbumPage(PhotoAlbum album)
        {
            SelectedAlbum = album;
            photoGalleryService.SelectedAlbum = SelectedAlbum;
            navigationService.NavigateToPage(typeof(ImagesLibraryPage));
        }

        #endregion

        #endregion
    }
}
