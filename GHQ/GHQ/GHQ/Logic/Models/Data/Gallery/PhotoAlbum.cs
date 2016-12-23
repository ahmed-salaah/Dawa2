using System.Collections.Generic;
using Models;

namespace GHQ.Logic.Models.Data.PhotosData
{
    public class PhotoAlbum : BaseModel
    {
        private List<PhotosData> _Photos;
        public List<PhotosData> Photos
        {
            get
            {
                return _Photos;
            }
            set
            {
                Set(() => Photos, ref _Photos, value);
            }
        }

        private string _Image;
        public string Image
        {
            get
            {
                return _Image;
            }
            set
            {
                Set(() => Image, ref _Image, value);
            }
        }

        private string _GalleryName;
        public string GalleryName
        {
            get
            {
                return _GalleryName;
            }
            set
            {
                Set(() => GalleryName, ref _GalleryName, value);
            }
        }

        private string _DisplayName;
        public string DisplayName
        {
            get
            {
                return _DisplayName;
            }
            set
            {
                Set(() => DisplayName, ref _DisplayName, value);
            }
        }

        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            return errors;
        }

    }
}
