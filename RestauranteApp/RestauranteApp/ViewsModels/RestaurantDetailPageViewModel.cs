using RestauranteApp.Interface;
using RestauranteApp.Models;
using RestauranteApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RestauranteApp.ViewsModels
{
    public class RestaurantDetailPageViewModel : BaseViewModel
    {
        public ICommand OpenUrlCommand { get; set; }

        public ICommand OpenPhoneCommand { get; set; }

        public RestaurantModel Item { get; set; }

        public ObservableCollection<ProductModel> Products { get; set; }

        public RestaurantDetailPageViewModel(RestaurantModel item)
        {
            OpenUrlCommand = new Command(OpenUrl);

            OpenPhoneCommand = new Command(OpenPhone);

            this.Item = item;

            Products = new ObservableCollection<ProductModel>();
            LoadProducts();

        }

        async private void LoadProducts()
        {
            foreach (var item in await new RestaurantRepository().GetProducts(Item.Id))
            {
                Products.Add(item);
            }
        }

        private void OpenUrl()
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            deviceService.OpenBrowser(Item.SitioWeb);
        }

        private void OpenPhone()
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            deviceService.Call(Item.Telefono);
        }
    }
}
