using BrokenFaxMobile.Services;
using BrokenFaxMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrokenFaxMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStoreActiveThreads>();
            DependencyService.Register<MockDataStoreItem>();
            DependencyService.Register<MockDataStoreCompleted>();
            var isLoogged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;
            if (isLoogged == "1")
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
