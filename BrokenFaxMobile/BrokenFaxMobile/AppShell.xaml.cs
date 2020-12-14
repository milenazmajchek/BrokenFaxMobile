using BrokenFaxMobile.ViewModels;
using BrokenFaxMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BrokenFaxMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(ProvideInputPage), typeof(ProvideInputPage));
            Routing.RegisterRoute(nameof(CompletedThreadDetailPage), typeof(CompletedThreadDetailPage));
            Routing.RegisterRoute(nameof(GroupsPage), typeof(GroupsPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }

    }
}
