using BrokenFaxMobile.Models;
using BrokenFaxMobile.ViewModels;

using Xamarin.Forms;

namespace BrokenFaxMobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}