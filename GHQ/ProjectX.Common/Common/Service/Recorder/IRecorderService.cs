using System.Threading.Tasks;

namespace Service.Recorder
{
    public interface IRecorderService
    {
        void Record();
        void Play();
        Task<byte[]> Stop();
    }
}
