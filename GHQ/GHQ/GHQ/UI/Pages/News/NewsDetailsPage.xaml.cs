using GHQ.Logic;

namespace GHQ.UI.Pages.News
{
    public partial class NewsDetailsPage : BasePage
    {
        readonly NewsDetailsViewModel NewsViewModel = Locator.Default.NewsDetailsViewModel;

        public NewsDetailsPage()
        {
            InitializeComponent();
            NewsViewModel.OnIntializeCommand.Execute(null);
            BindingContext = NewsViewModel;
        }
    }
}
