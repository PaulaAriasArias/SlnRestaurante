using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using RestauranteApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestauranteApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("1c44ddf2-0c70-40be-92dc-d922aba580f5",
                   typeof(Analytics), typeof(Crashes));
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        
    }
}
