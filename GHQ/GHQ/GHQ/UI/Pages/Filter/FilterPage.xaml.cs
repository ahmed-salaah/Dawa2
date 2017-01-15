using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;

namespace GHQ.UI.Pages.Filter
{
    public partial class FilterPage : BasePage
    {
		readonly FilterMedicineViewModel FilterVM = Locator.Default.FilterMedicineViewModel;
        public FilterPage()
        {
            InitializeComponent();
            BindingContext = FilterVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
			FilterVM.OnIntializeCommand.Execute(null);
        }
    }
}
