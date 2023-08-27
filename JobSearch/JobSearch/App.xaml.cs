using JobSearch.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var navPage = new NavigationPage(new Login());
            MainPage = navPage;
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
