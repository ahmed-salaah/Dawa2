using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;

namespace GHQ.UI.Pages.Medicine
{
    public partial class MedicineSchedule : BasePage
    {
        readonly MedicineScheduleViewModel MedicineScheduleViewModel = Locator.Default.MedicineScheduleViewModel;
        public MedicineSchedule()
        {
            InitializeComponent();
            BindingContext = MedicineScheduleViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MedicineScheduleViewModel.OnIntializeCommand.Execute(null);
        }
    }
}
