using GHQ.Logic;
using GHQ.Logic.ViewModels.ServiceRegistration;

namespace GHQ.UI.Pages.ServiceRegistration
{
    public partial class ServiceRegistrationHomePage : BasePage
    {
        readonly ServiceRegistrationHomeViewModel ServiceRegistrationHomeViewModel = Locator.Default.ServiceRegistrationHomeViewModel;
        public ServiceRegistrationHomePage()
        {
            InitializeComponent();
            BindingContext = ServiceRegistrationHomeViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ServiceRegistrationHomeViewModel.OnIntializeCommand.Execute(null);
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ServiceRegistrationHomeViewModel.OnNewsSelectedCommand.Execute(ServiceRegistrationHomeViewModel.SelectedNews);
        }

    }
}
