using GHQ.Logic;
using GHQ.Logic.ViewModels.ServiceRegistration;

namespace GHQ.UI.Pages.ServiceRegistration
{
    public partial class UpdateContactPage : BasePage
    {
        readonly UpdateContactViewModel UpdateContactViewModel = Locator.Default.UpdateContactViewModel;
        public UpdateContactPage()
        {
            InitializeComponent();
            BindingContext = UpdateContactViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateContactViewModel.OnIntializeCommand.Execute(null);
        }
    }
}
