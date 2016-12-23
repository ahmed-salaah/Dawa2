using System.Threading.Tasks;
using Service.Dialog;

namespace Service.Exception
{
    public class ExceptionService : IExceptionService
    {
        IDialogService dialogService;
        public ExceptionService(IDialogService _dialogService)
        {
            dialogService = _dialogService;
        }

        public async Task LogException(System.Exception ex)
        {
        }

        public async Task LogExceptionAndDisplayAlert(System.Exception ex, string title, string description, string accept = null)
        {
            await LogException(ex);
            await dialogService.DisplayAlert(title, description, accept);
        }
    }
}
