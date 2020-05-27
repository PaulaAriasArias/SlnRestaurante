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
    public partial class RestaurantDetailPage : ContentPage
    {
        public RestaurantDetailPage(ViewsModels.RestaurantDetailPageViewModel restaurantDetailPageViewModel)
        {
            InitializeComponent();
            BindingContext = restaurantDetailPageViewModel;
        }

        async private void btn_Map_Clicked(object sender, EventArgs e)
        {
            var vm_item = (RestaurantDetailPageViewModel)BindingContext;

            await Navigation.PushModalAsync(
                new MapPage(
                    vm_item.Item.Nombre,
                    vm_item.Item.Direccion,
                    vm_item.Item.Latitud,
                    vm_item.Item.Longitud));
        }
    }
}