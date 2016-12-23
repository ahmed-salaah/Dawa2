using System.Collections.ObjectModel;
using Exceptions;
using GalaSoft.MvvmLight.Command;
using Service.Dialog;
using GHQ.Logic.Models.Data.PhotosData;
using GHQ.Logic.Service.PhotoGallery;
using Models;
using Service.Exception;
using Service.Naviagtion;

namespace GHQ.Logic.ViewModels.PhotoGallery
{
    public class PhotoDetailsViewModel : BaseViewModel
    {
        public PhotoDetailsViewModel(IPhotoGalleryService _photoGalleryService, IDialogService _dialogService, IExceptionService _excpetionService, INavigationService _navigationService)
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
            SelectedPhoto = photoGalleryService.SelectedPhoto;
            Title = photoGalleryService.SelectedAlbum.DisplayName;
        }

        #endregion

        #region OnNextCommand

        private RelayCommand _OnNextCommand;
        public RelayCommand OnNextCommand
        {
            get
            {
                if (_OnNextCommand == null)
                {
                    _OnNextCommand = new RelayCommand(OnNext);
                }
                return _OnNextCommand;
            }
        }
        async private void OnNext()
        {
            int index = photoGalleryService.SelectedAlbum.Photos.IndexOf(SelectedPhoto);
            int nextIndex = (index + 1) % photoGalleryService.SelectedAlbum.Photos.Count;
            SelectedPhoto = photoGalleryService.SelectedAlbum.Photos[nextIndex];
        }

        #endregion

        #region OnPreviousCommand

        private RelayCommand _OnPreviousCommand;
        public RelayCommand OnPreviousCommand
        {
            get
            {
                if (_OnPreviousCommand == null)
                {
                    _OnPreviousCommand = new RelayCommand(OnPrevious);
                }
                return _OnPreviousCommand;
            }
        }
        async private void OnPrevious()
        {
            int index = photoGalleryService.SelectedAlbum.Photos.IndexOf(SelectedPhoto);
            if (index == 0)
            {
                index = photoGalleryService.SelectedAlbum.Photos.Count;
            }
            int prevIndex = (index - 1) % photoGalleryService.SelectedAlbum.Photos.Count;
            SelectedPhoto = photoGalleryService.SelectedAlbum.Photos[prevIndex];
        }

        #endregion

        #endregion
    }
}
