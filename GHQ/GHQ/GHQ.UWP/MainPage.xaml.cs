using Plugin.Toasts.UWP;
using Xamarin.Forms;

namespace GHQ.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            DependencyService.Register<ToastNotification>();
            ToastNotification.Init();
            LoadApplication(new GHQ.App());
        }
    }
}
