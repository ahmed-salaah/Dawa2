using System.Threading.Tasks;
using Service.Dialog;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

namespace Service.Exception
{
    public class ExceptionService : IExceptionService
    {
        IDialogService dialogService;
        public ExceptionService(IDialogService _dialogService)
        {
            dialogService = _dialogService;
        }

        public async Task LogException(System.Exception ex, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int? lineNumber = null)
        {
#if DEBUG
//Do Nothing
#else
            //Xamarin.Insights.Report(ex, new Dictionary<string, string> {
            //        {"error-local-time", DateTime.Now.ToString()}, {"Caller", caller}, {"filePath", filePath}, {"lineNumber", lineNumber.HasValue?lineNumber.Value.ToString():"-1" }
            //    }, Xamarin.Insights.Severity.Error);
#endif

        }

        public async Task LogExceptionAndDisplayAlert(System.Exception ex, string title, string description, string accept = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int? lineNumber = null)
        {
            await LogException(ex, caller, filePath, lineNumber);
            await dialogService.DisplayErrorAlert(title, description, accept);
        }
    }
}
