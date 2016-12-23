using Plugin.Connectivity;
using Service.Dialog;

namespace Service.Internet
{
    public class InternetService : IInternetService
    {
        public InternetService(IDialogService _dialogService)
        {
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                if (!args.IsConnected)
                {
                    //_dialogService.DisplayAlert("Connectivity Changed", "IsConnected: " + args.IsConnected.ToString(), "OK");
                    _dialogService.DisplayAlert("", NoInternetMessage);
                }

            };
        }

        public string NoInternetMessage { get; set; } = "No Internet Connection";

        public bool HasInternetAccess()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
