using BrokenFaxMobile.ViewModels;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrokenFaxMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActiveThreadsPage : ContentPage
    {
        private ActiveThreadsViewModel viewModel;

        public ActiveThreadsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ActiveThreadsViewModel(); ;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

        public void ProvideInputClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var activeThread = button.BindingContext as ActiveFaxThreadViewData;
            viewModel.ProvideInputCmd.Execute(activeThread);
        }
    }
}