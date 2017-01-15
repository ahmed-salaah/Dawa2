using System.Threading.Tasks;

namespace Service.FileHelper
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);

        Task<string> SaveByteArrayToDisk(string filename, byte[] imageData, string folderName = "");

        Task<byte[]> GetByteArray(string filePath);

        Task<string> SaveImageToDisk(string filename, byte[] imageData, string folderName = "");
    }
}
