using System.Collections.Generic;
using Models;
using GHQ.Resources.Strings;
using GHQ.UI.Pages.Home;
using GHQ.UI.Pages.Account;
using GHQ.UI.Pages.PhotoGallery;
using GHQ.UI.Pages.ContactUS;
using GHQ.UI.Pages.Notification;
using GHQ.UI.Pages.News;
using GHQ.UI.Pages.ServiceRegistration;
using GHQ.UI.Pages.MapLocation;
using GHQ.UI.Pages.WepPages;
using GHQ.UI.Pages.AboutUs;
using GHQ.Logic.Constant;

namespace Service.SideMenu
{
    public class SideMenuService : ISideMenuService
    {
        public List<SideMenuItem> GetLogginSideMenuItems()
        {
            List<SideMenuItem> menuItems = new List<SideMenuItem>();
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_Home,
                IconSource = "MenuHome.png",
                TargetType = typeof(HomePage)
            });

            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_MediaCenter,
                IconSource = "MenuMedia.png",
                TargetType = typeof(AlbumLibraryPage)
            });
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.PageHeader_ContactUs,
                IconSource = "MenuContact.png",
                TargetType = typeof(ContactUSPage)
            });
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.PageHeader_AboutUs,
                IconSource = "MenuInfo.png",
                TargetType = typeof(AboutUSPage)
            });

            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_GeneralDept,
                IconSource = "MenuLawaa.png",
                TargetType = typeof(WalaaPage)
            });
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_ServiceRegistration,
                IconSource = "MenuTasgel.png",
                TargetType = Constant.UseServiceRegisterationAsWebView ? typeof(ServiceRegistrationWebPage) : typeof(ServiceRegistrationHomePage)
            });
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_Map,
                IconSource = "MenuMap.png",
                TargetType = typeof(MapPage)
            });

            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_Website,
                IconSource = "MenuWeb.png",
                TargetType = typeof(GHQWebPage)
            });

            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_Inquiry,
                IconSource = "Inquiry.png",
                TargetType = typeof(InquiryWebPage)
            });

            if (!Constant.UseServiceRegisterationAsWebView)
            {
                menuItems.Add(new SideMenuItem
                {
                    Title = AppResources.Home_Navigation_Logout,
                    IconSource = "logout.png",
                    TargetType = typeof(LogoutPage)
                });
            }
            return menuItems;
        }

        public List<SideMenuItem> GetNotLogginSideMenuItems()
        {
            List<SideMenuItem> menuItems = new List<SideMenuItem>();
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_Home,
                IconSource = "MenuHome.png",
                TargetType = typeof(HomePage)
            });

            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_NewUser,
                IconSource = "MenuNewUser.png",
                TargetType = typeof(NewAccountStep1Page)
            });
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_Login,
                IconSource = "MenuMembers.png",
                TargetType = typeof(IdentityLoginPage)
            });
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_MediaCenter,
                IconSource = "MenuMedia.png",
                TargetType = typeof(AlbumLibraryPage)
            });
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.PageHeader_ContactUs,
                IconSource = "MenuContact.png",
                TargetType = typeof(ContactUSPage)
            });
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.PageHeader_AboutUs,
                IconSource = "MenuInfo.png",
                TargetType = typeof(AboutUSPage)
            });

            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_GeneralDept,
                IconSource = "MenuLawaa.png",
                TargetType = typeof(WalaaPage)
            });

            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_Map,
                IconSource = "MenuMap.png",
                TargetType = typeof(MapPage)
            });

            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_Website,
                IconSource = "MenuWeb.png",
                TargetType = typeof(GHQWebPage)
            });
            menuItems.Add(new SideMenuItem
            {
                Title = AppResources.Home_Navigation_Inquiry,
                IconSource = "Inquiry.png",
                TargetType = typeof(InquiryWebPage)
            });

            return menuItems;
        }
    }
}
