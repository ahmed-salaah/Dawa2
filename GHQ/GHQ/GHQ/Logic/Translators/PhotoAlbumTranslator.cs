using System.Collections.Generic;
using GHQ.Logic.Models.Response;
using Exceptions;
using Newtonsoft.Json;
using GHQ.Logic.Models.Data.PhotosData;

namespace GHQ
{
    public class PhotoAlbumTranslator
    {
        static public List<PhotoAlbum> Translate(List<Galleryname> response)
        {
            try
            {
                var translatedPhotos = new List<PhotoAlbum>();

                foreach (var item in response)
                {
                    PhotoAlbum photo = new PhotoAlbum();
                    photo.Image = item.ImageUrl;
                    photo.GalleryName = item.GalleryName;
                    photo.DisplayName = item.DisplayName;
                    translatedPhotos.Add(photo);
                }

                return translatedPhotos;
            }
            catch (System.Exception ex)
            {
                throw new ParsingException("Error Translating PhotoData", JsonConvert.SerializeObject(response));
            }
        }
    }
}
