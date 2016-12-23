using GHQ.Logic;
using GHQ.Logic.ViewModels.Notification;

namespace GHQ.UI.Pages.Notification
{
    public partial class NotificationsPage : BasePage
    {
        readonly NotificationViewModel NotificationViewModel = Locator.Default.NotificationViewModel;
        public NotificationsPage()
        {
            InitializeComponent();
            BindingContext = NotificationViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NotificationViewModel.OnIntializeCommand.Execute(null);
        }
    }
}
