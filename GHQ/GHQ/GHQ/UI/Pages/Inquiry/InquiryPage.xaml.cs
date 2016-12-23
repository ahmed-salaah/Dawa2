using GHQ.Logic;
using GHQ.Logic.ViewModels.Inquiry;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Inquiry
{
    public partial class InquiryPage : ContentPage
    {
        readonly InquiryViewModel InquiryViewModel = Locator.Default.InquiryViewModel;
        public InquiryPage()
        {
            InitializeComponent();
            BindingContext = InquiryViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            InquiryViewModel.OnIntializeCommand.Execute(null);
        }
    }
}
