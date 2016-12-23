//using GHQ;
//using GHQ.Resources.Strings;
//using Plugin.Toasts;
//using System.Threading.Tasks;
//using Xamarin.Forms;

//namespace Service.Dialog
//{
//    public class DialogService : IDialogService
//    {
//        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
//        {
//            return await App.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
//        }

//        public async Task DisplayAlert(string title, string description, string accept = null, string cancel = null)
//        {
//            if (cancel == null)
//            {
//                if (accept == null)
//                    accept = AppResources.Dialog_Confirm;

//                await App.Current.MainPage.DisplayAlert(title, description, accept);
//            }
//            else
//            {
//                await App.Current.MainPage.DisplayAlert(title, description, accept, cancel);
//            }
//        }

//        public async Task ShowToast(string title, string description)
//        {
//            //https://github.com/EgorBo/Toasts.Forms.Plugin
//            var notificator = DependencyService.Get<IToastNotificator>();
//            var options = new NotificationOptions()
//            {
//                Title = title,
//                Description = description,
//            };
//            var notificationResult = await notificator.Notify(options);
//        }
//    }
//}
