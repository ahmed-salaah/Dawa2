using System.Threading.Tasks;

namespace Service.FileHelper
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);

        Task<string> SaveByteArrayToDisk(string filename, byte[] imageData,string folderName="");

        Task<string> SaveImageToDisk(string filename, byte[] imageData, string folderName = "");
    }
}
