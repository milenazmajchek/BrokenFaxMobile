using BrokenFaxMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private string _userName;

        public Command RegisterCommand { get; }

        public string RegisterEmail
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        public string RegisterPassword
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
            }
        }

        public string RegisterUsername
        {
            get { return _userName; }
            set
            {
                SetProperty(ref _userName, value);
            }
        }

        public RegisterViewModel()
        {
            Title = "Register";
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnRegisterClicked(object obj)
        {
            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync($"//main");
        }
    }
}
