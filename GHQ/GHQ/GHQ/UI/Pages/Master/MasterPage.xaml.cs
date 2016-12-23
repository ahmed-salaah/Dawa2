using GHQ.Logic;
using Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Master
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            List<SideMenuItem> menuItems = new List<SideMenuItem>();

            if (Locator.Default.AccountService.IsLogin)
            {
                menuItems = Locator.Default.SideMenuService.GetLogginSideMenuItems();
            }
            else
            {
                menuItems = Locator.Default.SideMenuService.GetNotLogginSideMenuItems();
            }

            listView.ItemsSource = menuItems;
        }
    }
}