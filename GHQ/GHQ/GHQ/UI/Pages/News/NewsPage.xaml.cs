using GHQ.Logic;
using GHQ.Logic.ViewModels.News;

namespace GHQ.UI.Pages.News
{
    public partial class NewsPage : BasePage
    {
        readonly NewsViewModel NewsViewModel = Locator.Default.NewsViewModel;
        public NewsPage()
        {
            InitializeComponent();
            BindingContext = NewsViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NewsViewModel.OnIntializeCommand.Execute(null);
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            NewsViewModel.OnNewsSelectedCommand.Execute(NewsViewModel.SelectedNews);
        }
    }
}
