using System.Collections.Generic;

namespace GHQ.Logic.Models.Response
{
    public class PhotoAlbumResponse
    {
        public List<Galleryname> GalleryNames { get; set; }
    }

    public class Galleryname
    {
        public string GalleryName { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
    }

}
