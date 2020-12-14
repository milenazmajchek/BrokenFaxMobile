using BrokenFaxMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrokenFaxMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedThreadsPage : ContentPage
    {
        CompletedThreadsViewModel viewModel;

        public CompletedThreadsPage()
        {
            BindingContext = viewModel = new CompletedThreadsViewModel();
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}