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
using System.Linq;
using GHQ.UI.Pages.PhotoGallery;

namespace GHQ.Logic.ViewModels.PhotoGallery
{
    public class PhotoGalleryViewModel : BaseViewModel
    {
        public PhotoGalleryViewModel(IPhotoGalleryService _photoGalleryService, IDialogService _dialogService, IExceptionService _excpetionService, INavigationService _navigationService)
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

        private ObservableCollection<PhotosData> _Photos;
        public ObservableCollection<PhotosData> Photos
        {
            get { return _Photos; }
            set
            {
                Set(() => Photos, ref _Photos, value);
            }
        }


        private PhotosData _SelectedPhoto;
        public PhotosData SelectedPhoto
        {
            get { return _SelectedPhoto; }
            set
            {
                Set(() => SelectedPhoto, ref _SelectedPhoto, value);
            }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                Set(() => Title, ref _Title, value);
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
                Photos = new ObservableCollection<PhotosData>();
                Title = photoGalleryService.SelectedAlbum.DisplayName;
                var response = await photoGalleryService.GetPhotosAsync(photoGalleryService.SelectedAlbum.GalleryName);
                if (response != null)
                {
                    Photos = new ObservableCollection<PhotosData>(response);
                    photoGalleryService.SelectedAlbum.Photos = Photos.ToList();
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


        private RelayCommand<PhotosData> _PhotoSelectedCommand;
        public RelayCommand<PhotosData> PhotoSelectedCommand
        {
            get
            {
                if (_PhotoSelectedCommand == null)
                {
                    _PhotoSelectedCommand = new RelayCommand<PhotosData>(OpenPhotoPage);
                }
                return _PhotoSelectedCommand;
            }
        }
        private void OpenPhotoPage(PhotosData photo)
        {
            SelectedPhoto = photo;
            photoGalleryService.SelectedPhoto = SelectedPhoto;
            navigationService.NavigateToPage(typeof(ImagePage));
        }


        #endregion
    }
}
