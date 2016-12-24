using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;

namespace GHQ.UI.Pages.Medicine
{
    public partial class MedicineHistory : BasePage
    {
        readonly MedicineHistoryViewModel MedicineHistoryViewModel = Locator.Default.MedicineHistoryViewModel;
        public MedicineHistory()
        {
            InitializeComponent();
            BindingContext = MedicineHistoryViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MedicineHistoryViewModel.OnIntializeCommand.Execute(null);
        }
    }
}
