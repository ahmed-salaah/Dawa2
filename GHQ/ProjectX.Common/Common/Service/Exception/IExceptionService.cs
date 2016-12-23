using System.Threading.Tasks;

namespace Service.Exception
{
    public interface IExceptionService
    {
        Task LogException(System.Exception ex);
        Task LogExceptionAndDisplayAlert(System.Exception ex, string title, string description, string accept = null);

    }
}
