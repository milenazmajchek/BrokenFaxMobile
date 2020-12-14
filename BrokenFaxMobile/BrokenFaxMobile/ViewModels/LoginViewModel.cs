using System.ComponentModel;
using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string email;
        private string password;
        private bool isLoading;

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }
        public Command LoginCommand { get; }

        public Command RegisterCommand { get; }

        public string LoginEmail
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string LoginPassword
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (isLoading == value)
                    return;
                isLoading = value;
                SetProperty(ref isLoading, value);
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
            await Shell.Current.GoToAsync($"//RegisterPage");
        }
    }
}
