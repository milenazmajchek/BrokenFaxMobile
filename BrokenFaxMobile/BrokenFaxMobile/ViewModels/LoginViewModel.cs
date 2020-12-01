using BrokenFaxMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string email;

        public string LoginEmail
        {
            get { return email; }
            set
            {
                email = value;
                SetProperty(ref email, value);
            }
        }

        private string password;

        public string LoginPassword
        {
            get { return password; }
            set
            {
                password = value;
                SetProperty(ref password, value);
            }
        }

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading == value)
                    return;
                _isLoading = value;
                SetProperty(ref _isLoading, value);
            }
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//main");
        }

        private async void OnRegisterClicked(object obj)
        {
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
    }
}
