using BrokenFaxMobile.ViewModels;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrokenFaxMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupsPage : ContentPage
    {
        private GroupsViewModel viewModel;
        public GroupsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new GroupsViewModel(); ;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

        public void ChangeMembershipClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var group = button.BindingContext as GroupsViewData;
            viewModel.ChangeMembershipCmd.Execute(group);
        }
    }
}