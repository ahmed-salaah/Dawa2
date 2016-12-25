using Enums;
using System;
using Xamarin.Forms;

namespace Service.Naviagtion
{
    public interface INavigationService
    {
        AppState AppState { get; set; }
        bool IsExternalAppOpen { get; set; }
        Page CurrentPage { get; set; }

        bool SetAppCurrentPage<TPageType>(TPageType pageType) where TPageType : Type;

        bool NavigateToPage<TPageType>(TPageType pageTypes) where TPageType : Type;

        void GoBack();

        void ClearNavigationStack();
    }
}
