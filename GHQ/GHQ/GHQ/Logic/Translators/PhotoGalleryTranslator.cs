using System.Collections.Generic;
using GHQ.Logic.Models.Response;
using Exceptions;
using Newtonsoft.Json;
using GHQ.Logic.Models.Data.PhotosData;
using GHQ.Logic.Constant;

namespace GHQ
{
    public class PhotoGalleryTranslator
    {
        static public List<PhotosData> Translate(List<PhtotGalleryResposeResult> response)
        {
            try
            {
                var translatedPhotos = new List<PhotosData>();

				foreach (var item in response)
                {
                    PhotosData photo = new PhotosData();
					photo.Image = ServiceConstant.PhotoBaseURL + item.ServerRelativeUrl;
                    
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
