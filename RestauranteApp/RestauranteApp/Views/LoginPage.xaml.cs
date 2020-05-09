using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestauranteApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
#if DEBUG
            txt_email.Text = "admin@admin.com";
            txt_pasword.Text = "admin";
#endif

        }

        async private void btn_login_Clicked(object sender, EventArgs e)
        {
            string email = txt_email.Text;
            string password = txt_pasword.Text;

            if (email == "admin@admin.com" && password =="admin")
            {
                await this.Navigation.PushModalAsync(new HomePage());
            }
            else
            {
                await this.DisplayAlert("Campos Incorrectos", "Email o Password Incorrectos", "Aceptar");
            }
        }
    }
}