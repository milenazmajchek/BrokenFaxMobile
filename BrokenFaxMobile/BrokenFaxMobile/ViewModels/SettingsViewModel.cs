﻿using BrokenFaxMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command LogoutCommand { get; }
        public SettingsViewModel()
        {
            LogoutCommand = new Command(OnLogoutClicked);
        }

        private async void OnLogoutClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "0");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
