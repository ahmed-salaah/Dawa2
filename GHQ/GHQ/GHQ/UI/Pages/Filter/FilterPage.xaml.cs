using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;

namespace GHQ.UI.Pages.Filter
{
    public partial class FilterPage : BasePage
    {
        readonly NewAccountViewModel AccountVM = Locator.Default.NewAccountViewModel;
        public FilterPage()
        {
            InitializeComponent();
            //BindingContext = AccountVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //AccountVM.OnIntializeCommand.Execute(null);
        }
    }
}
