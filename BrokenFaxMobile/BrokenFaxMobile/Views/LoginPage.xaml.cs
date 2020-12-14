using BrokenFaxMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrokenFaxMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            Email.Completed += Email_Completed;
            Password.Completed += Password_Completed;
        }

        private void Password_Completed(object sender, System.EventArgs e)
        {
            loginbtn.Command.Execute(loginbtn);
        }

        private void Email_Completed(object sender, System.EventArgs e)
        {
            Password.Focus();
        }
    }
}