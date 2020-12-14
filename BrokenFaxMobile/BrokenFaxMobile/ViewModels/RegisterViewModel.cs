using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string email;
        private string password;
        private string userName;
        private bool missingEmail;
        private bool missingPassword;
        private bool missingUsername;

        public RegisterViewModel()
        {
            Title = "Register";
            RegisterCommand = new Command(OnRegisterClicked);
        }

        public Command RegisterCommand { get; }

        public string RegisterEmail
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                if (!string.IsNullOrWhiteSpace(value))
                    MissingEmail = false;
            }
        }

        public string RegisterPassword
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                if (!string.IsNullOrWhiteSpace(value))
                    MissingPassword = false;
            }
        }

        public string RegisterUsername
        {
            get => userName;
            set
            {
                SetProperty(ref userName, value);
                if (!string.IsNullOrWhiteSpace(value))
                    MissingUsername = false;
            }
        }

        public bool MissingEmail
        {
            get => missingEmail;
            set => SetProperty(ref missingEmail, value);
        }

        public bool MissingPassword
        {
            get => missingPassword;
            set => SetProperty(ref missingPassword, value);
        }

        public bool MissingUsername
        {
            get => missingUsername;
            set => SetProperty(ref missingUsername, value);
        }

        private async void OnRegisterClicked(object obj)
        {
            var canRegister = true;
            if(string.IsNullOrWhiteSpace(RegisterEmail))
            {
                canRegister = false;
                MissingEmail = true;
            }
            
            if (string.IsNullOrWhiteSpace(RegisterPassword))
            {
                canRegister = false;
                MissingPassword = true;
            }
            
            if (string.IsNullOrWhiteSpace(RegisterUsername))
            {
                canRegister = false;
                MissingUsername = true;
            }

            if (!canRegister)
                return;

            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync($"//main");
        }
    }
}
