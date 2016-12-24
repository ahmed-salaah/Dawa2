using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;

namespace GHQ.UI.Pages.Medicine
{
    public partial class MedicineHistory : BasePage
    {
        //readonly NewAccountViewModel AccountVM = Locator.Default.NewAccountViewModel;
        public MedicineHistory()
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
