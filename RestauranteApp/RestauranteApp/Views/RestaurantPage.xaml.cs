using RestauranteApp.Models;
using RestauranteApp.ViewsModels;
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
    public partial class RestaurantPage : ContentPage
    {
        public RestaurantPage()
        {
            InitializeComponent();
            BindingContext = new RestaurantsPageViewModel();
        }

        async private void grd_restaurants_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //sender hace referencia a objeto que realizo el evento
            //SelectedItemChangedEventArgs e argumentos que viajaran con el elemento
            var item = e.SelectedItem as RestaurantModel;

            if(item==null)
                return;

            await this.Navigation.PushAsync(new RestaurantDetailPage(new RestaurantDetailPageViewModel(item)));

            grd_restaurants.SelectedItem = null;

        }
    }
}