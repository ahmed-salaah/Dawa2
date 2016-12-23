using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Account
{
    public partial class ForgetPasswordPage : ContentPage
    {
        readonly ForgetPasswordViewModel ForgetPasswordViewModel = Locator.Default.ForgetPasswordViewModel;
        public ForgetPasswordPage()
        {
            InitializeComponent();
            BindingContext = ForgetPasswordViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ForgetPasswordViewModel.OnIntializeCommand.Execute(null);
        }
    }
}
