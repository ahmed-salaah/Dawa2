using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;
using GHQ.UI.Pages.Master;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Account
{
    public partial class NewAccountStep3Page : BasePage
    {
        readonly NewAccountViewModel RegistrationViewModel = Locator.Default.NewAccountViewModel;
        public NewAccountStep3Page()
        {
            InitializeComponent();
            BindingContext = RegistrationViewModel;
            NavigationPage.SetHasBackButton(this,false);
        }

        protected override bool OnBackButtonPressed()
        {
            Locator.Default.NavigationService.SetAppCurrentPage(typeof(MainPage));
            return base.OnBackButtonPressed();
        }
    }
}
