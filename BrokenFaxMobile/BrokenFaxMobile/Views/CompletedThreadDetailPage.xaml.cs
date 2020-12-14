using BrokenFaxMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrokenFaxMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedThreadDetailPage : ContentPage
    {
        public CompletedThreadDetailPage()
        {
            InitializeComponent();
            BindingContext = new CompletedThreadDetailViewModel();
        }
    }
}