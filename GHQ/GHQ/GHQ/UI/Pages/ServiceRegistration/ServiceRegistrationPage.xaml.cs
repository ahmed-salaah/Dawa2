using GHQ.Logic;
using GHQ.Logic.Models.Data.Registration;
using GHQ.Logic.ViewModels.ServiceRegistration;
using System;
using Xamarin.Forms;

namespace GHQ.UI.Pages.ServiceRegistration
{
    public partial class ServiceRegistrationPage : CarouselPage
    {
        readonly ServiceRegistrationViewModel ServiceRegistrationViewModel = Locator.Default.ServiceRegistrationViewModel;
        public ServiceRegistrationPage()
        {
            InitializeComponent();
            BindingContext = ServiceRegistrationViewModel;
            this.CurrentPageChanged += ServiceRegistrationPage_CurrentPageChanged;
            attachmentList.ItemSelected += AttachmentList_ItemSelected;
            NavigationPage.SetBackButtonTitle(this, "");
        }

        private void AttachmentList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                ServiceRegistrationViewModel.OnUpdateImageCommand.Execute((ServiceAttachementData)e.SelectedItem);
        }

        private async void ServiceRegistrationPage_CurrentPageChanged(object sender, System.EventArgs e)
        {
            var currentIndex = this.Children.IndexOf(this.CurrentPage);
            var contentPageTitle = (sender as ServiceRegistrationPage).CurrentPage.Title;

            if (contentPageTitle == "work")
            {
                await ServiceRegistrationViewModel.LoadWorkData();
            }
            else if (contentPageTitle == "address")
            {
                await ServiceRegistrationViewModel.LoadAddressData();
            }
            else if (contentPageTitle == "relatives")
            {
                await ServiceRegistrationViewModel.LoadRelativesData();
            }
            else if (contentPageTitle == "wife")
            {
                await ServiceRegistrationViewModel.LoadWifesData();
            }
            else if (contentPageTitle == "qualifications")
            {
                await ServiceRegistrationViewModel.LoadAcademicQualificationData();
            }
            else if (contentPageTitle == "attachments")
            {
                await ServiceRegistrationViewModel.LoadAttachmentsData();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.SelectedItem = this.Children[6];
            ServiceRegistrationViewModel.OnIntializeCommand.Execute(null);
        }

    }
}
