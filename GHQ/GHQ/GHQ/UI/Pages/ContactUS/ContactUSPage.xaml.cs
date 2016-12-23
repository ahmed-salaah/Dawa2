using GHQ.Logic;
using GHQ.Logic.ViewModels.ContactUs;

namespace GHQ.UI.Pages.ContactUS
{
    public partial class ContactUSPage : BasePage
    {
        readonly ContactUsViewModel ContactUsViewModel = Locator.Default.ContactUsViewModel;

        public ContactUSPage()
        {
            InitializeComponent();
            BindingContext = ContactUsViewModel;
        }
    }
}
