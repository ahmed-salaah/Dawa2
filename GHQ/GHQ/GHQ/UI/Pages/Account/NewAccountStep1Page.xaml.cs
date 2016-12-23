using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;

namespace GHQ.UI.Pages.Account
{
    public partial class NewAccountStep1Page : BasePage
    {
        readonly NewAccountViewModel AccountVM = Locator.Default.NewAccountViewModel;
        public NewAccountStep1Page()
        {
            InitializeComponent();
            BindingContext = AccountVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AccountVM.OnIntializeCommand.Execute(null);
        }
    }
}
