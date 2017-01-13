using System.Threading.Tasks;

namespace Service.Media
{
    public interface IImageService
    {
        Task<string> SavePictureToDisk(string filename, byte[] imageData);
    }

}
