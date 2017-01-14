﻿using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;

namespace GHQ.UI.Pages.Home
{
    public partial class HomePage : BasePage
    {
        readonly HomeViewModel HomeViewModel = Locator.Default.HomeViewModel;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = HomeViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HomeViewModel.OnIntializeCommand.Execute(null);
        }

    }
}
