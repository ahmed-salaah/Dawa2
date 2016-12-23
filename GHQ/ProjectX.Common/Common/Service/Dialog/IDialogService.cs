using System.Threading.Tasks;

namespace Service.Dialog
{
    public interface IDialogService
    {
        Task ShowToast(string title, string description);
        Task DisplayAlert(string title, string description, string accept = null, string cancel = null);
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
    }
}
