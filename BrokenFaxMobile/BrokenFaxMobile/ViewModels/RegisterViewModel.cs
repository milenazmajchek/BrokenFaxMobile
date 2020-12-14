using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string email;
        private string password;
        private string userName;

        public RegisterViewModel()
        {
            Title = "Register";
            RegisterCommand = new Command(OnRegisterClicked);
        }

        public Command RegisterCommand { get; }

        public string RegisterEmail
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string RegisterPassword
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string RegisterUsername
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private async void OnRegisterClicked(object obj)
        {
            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync($"//main");
        }
    }
}
