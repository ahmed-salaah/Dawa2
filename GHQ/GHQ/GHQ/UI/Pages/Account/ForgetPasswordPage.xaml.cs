using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;

namespace GHQ.UI.Pages.Account
{
    public partial class ForgetPasswordPage : BasePage
    {
        readonly ForgetPasswordViewModel ForgetPasswordViewModel = Locator.Default.ForgetPasswordViewModel;
        public ForgetPasswordPage()
        {
            InitializeComponent();
            BindingContext = ForgetPasswordViewModel;
            ToolbarItems.Clear();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ForgetPasswordViewModel.OnIntializeCommand.Execute(null);
        }
    }
}
