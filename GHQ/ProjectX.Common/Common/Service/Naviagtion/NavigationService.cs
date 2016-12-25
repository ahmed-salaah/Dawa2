using Enums;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Service.Naviagtion
{
    public class NavigationService : INavigationService
    {
        public AppState AppState { get; set; }
        public bool IsExternalAppOpen { get; set; }
        public Page CurrentPage { get; set; }
        public bool SetAppCurrentPage<TPageType>(TPageType pageType) where TPageType : Type
        {
            try
            {
                Page displayPage = (Page)Activator.CreateInstance(pageType);
                CurrentPage = displayPage;
                Task.Delay(100).Wait();
                Application.Current.MainPage = displayPage;
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool NavigateToPage<TPageType>(TPageType pageType) where TPageType : Type
        {
            try
            {
                Page displayPage = (Page)Activator.CreateInstance(pageType);
                CurrentPage = displayPage;
                if (Application.Current.MainPage is MasterDetailPage)
                {
                    (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(displayPage);
                }
                else
                {
                    (Application.Current.MainPage as Page).Navigation.PushAsync(displayPage);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public async void GoBack()
        {
            try
            {
                if (Application.Current.MainPage is MasterDetailPage)
                {
                    CurrentPage = await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();
                }
                else
                {
                    CurrentPage = await (Application.Current.MainPage as Page).Navigation.PopAsync();
                }
            }
            catch (System.Exception ex)
            {
                ///TODO Log this error
            }
        }

        public void ClearNavigationStack()
        {
            //(Application.Current.MainPage as Page).Navigation.PopAsync();
        }
    }
}
