using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exceptions;
using GHQ.Logic.Models.Data.PhotosData;
using GHQ.Logic.Models.Response;
using Service.Internet;
using Service.Network;

namespace GHQ.Logic.Service.PhotoGallery
{
    public class PhotoGalleryService : IPhotoGalleryService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        #endregion

        public PhotosData SelectedPhoto { get; set; }
        public PhotoAlbum SelectedAlbum { get; set; }

        public PhotoGalleryService(INetworkService _networkService, IInternetService _internetService)
        {
            networkService = _networkService;
            internetService = _internetService;
        }
        public async Task<List<PhotosData>> GetPhotosAsync(string albumName)
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    Dictionary<string, string> headers = new Dictionary<string, string>();
                    headers.Add("Accept", "application/json;odata=verbose");
                    var resource = Constant.ServiceConstant.ApiSharePointBaseUrl + string.Format(Constant.ServiceConstant.Api_GetPhotos, albumName);
                    var result = await networkService.HttpGetAsync<PhtotGalleryRespose>(resource, headers);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            return PhotoGalleryTranslator.Translate(result.Result.d.results.ToList());
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException("", "", resource, null);
                    }
                }
                else
                {
                    throw new InternetException();
                }
            }
            catch (InternetException ex)
            {
                throw ex;
            }
            catch (BackendException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, "", "PhotoGalleryService.GetPhotosAsync", ex);
            }

        }

        public async Task<List<PhotoAlbum>> GetPhotoALbumssAsync()
        {
            try
            {
                if (internetService.HasInternetAccess())
                {
                    var resource = Constant.ServiceConstant.ApiPhotoAlbums;
                    var result = await networkService.HttpGetAsync<PhotoAlbumResponse>(resource, null);
                    if (result.HttpResponseMessage.IsSuccessStatusCode)
                    {
                        if (result.Result != null)
                        {
                            return PhotoAlbumTranslator.Translate(result.Result.GalleryNames);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new BackendException("", "", resource, null);
                    }
                }
                else
                {
                    throw new InternetException();
                }
            }
            catch (InternetException ex)
            {
                throw ex;
            }
            catch (BackendException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, "", "PhotoGalleryService.GetPhotoALbumssAsync", ex);
            }

        }
    }
}
