using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Service.Exception
{
    public interface IExceptionService
    {
        Task LogException(System.Exception ex, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int? lineNumber = null);
        Task LogExceptionAndDisplayAlert(System.Exception ex, string title, string description, string accept = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int? lineNumber = null);

    }
}
