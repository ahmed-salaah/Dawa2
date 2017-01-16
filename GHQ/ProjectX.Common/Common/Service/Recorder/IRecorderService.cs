using System.Threading.Tasks;

namespace Service.Recorder
{
    public interface IRecorderService
    {
        void Record();
		void Play(string Path);
        Task<byte[]> Stop();
    }
}
