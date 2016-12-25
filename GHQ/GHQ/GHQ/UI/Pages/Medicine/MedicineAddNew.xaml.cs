using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;

namespace GHQ.UI.Pages.Medicine
{
    public partial class MedicineAddNew : BasePage
    {
        readonly MedicineAddNewViewModel MedicineAddNewViewModel = Locator.Default.MedicineAddNewViewModel;
        public MedicineAddNew()
        {
            InitializeComponent();
            BindingContext = MedicineAddNewViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MedicineAddNewViewModel.OnIntializeCommand.Execute(null);
        }
    }
}
