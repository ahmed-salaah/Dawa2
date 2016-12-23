using System.Collections.Generic;
using System.Threading.Tasks;
using GHQ.Logic.Models.Data.PhotosData;
namespace GHQ.Logic.Service.PhotoGallery
{
    public interface IPhotoGalleryService
    {
        PhotosData SelectedPhoto { get; set; }
        PhotoAlbum SelectedAlbum { get; set; }
        Task<List<PhotosData>> GetPhotosAsync(string albumName);

        Task<List<PhotoAlbum>> GetPhotoALbumssAsync();
    }
}
