using BrokenFaxMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrokenFaxMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActiveThreadsPage : ContentPage
    {
        private ActiveThreadsViewModel _viewModel;

        public ActiveThreadsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ActiveThreadsViewModel(); ;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        public void ProvideInputClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var experience = button.BindingContext as ActiveFaxThreadViewData;
            _viewModel.ProvideInputCmd.Execute(experience);
        }
    }
}