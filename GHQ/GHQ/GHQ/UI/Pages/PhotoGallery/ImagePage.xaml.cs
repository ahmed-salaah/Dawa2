using GHQ.Logic;
using GHQ.Logic.ViewModels.PhotoGallery;

namespace GHQ.UI.Pages.PhotoGallery
{
    public partial class ImagePage : BasePage
    {
        readonly PhotoDetailsViewModel PhotoDetailsViewModel = Locator.Default.PhotoDetailsViewModel;
        public ImagePage()
        {
            InitializeComponent();
            BindingContext = PhotoDetailsViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PhotoDetailsViewModel.OnIntializeCommand.Execute(null);
        }
    }
}
