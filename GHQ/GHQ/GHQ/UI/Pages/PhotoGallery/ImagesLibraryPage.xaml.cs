using GHQ.Logic;
using GHQ.Logic.ViewModels.PhotoGallery;
namespace GHQ.UI.Pages.PhotoGallery
{
    public partial class ImagesLibraryPage : BasePage
    {
        readonly PhotoGalleryViewModel PhotosViewModel = Locator.Default.PhotoGalleryViewModel;
        public ImagesLibraryPage()
        {
            InitializeComponent();
            BindingContext = PhotosViewModel;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            PhotosViewModel.OnIntializeCommand.Execute(null);
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            PhotosViewModel.PhotoSelectedCommand.Execute(PhotosViewModel.SelectedPhoto);
        }
    }
}
