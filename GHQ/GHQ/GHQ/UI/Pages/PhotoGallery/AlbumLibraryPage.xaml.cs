using GHQ.Logic;
using GHQ.Logic.ViewModels.PhotoGallery;
namespace GHQ.UI.Pages.PhotoGallery
{
    public partial class AlbumLibraryPage : BasePage
    {
        readonly PhotoAlbumViewMiodel PhotoAlbumViewMiodel = Locator.Default.PhotoAlbumViewMiodel;
        public AlbumLibraryPage()
        {
            InitializeComponent();
            BindingContext = PhotoAlbumViewMiodel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            PhotoAlbumViewMiodel.OnIntializeCommand.Execute(null);
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            PhotoAlbumViewMiodel.OnAlbumSelectedCommand.Execute(PhotoAlbumViewMiodel.SelectedAlbum);
        }
    }
}
