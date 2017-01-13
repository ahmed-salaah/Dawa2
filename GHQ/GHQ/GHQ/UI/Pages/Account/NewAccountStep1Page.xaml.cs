using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Account
{
    public partial class NewAccountStep1Page : BasePage
    {
        readonly NewAccountViewModel AccountVM = Locator.Default.NewAccountViewModel;
        public NewAccountStep1Page()
        {
            InitializeComponent();
            ToolbarItems.Clear();
            BindingContext = AccountVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AccountVM.OnIntializeCommand.Execute(null);
        }
    }
}
