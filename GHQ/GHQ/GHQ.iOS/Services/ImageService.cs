using Foundation;
using GHQ.ios.Services;
using Service.Media;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageService))]

namespace GHQ.ios.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> SavePictureToDisk(string filename, byte[] imageData)
        {
            var chartImage = new UIImage(NSData.FromArray(imageData));
            chartImage.SaveToPhotosAlbum((image, error) =>
            {

            });
            return filename;
        }
    }
}
