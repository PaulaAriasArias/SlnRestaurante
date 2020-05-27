using RestauranteApp.Interface;
using RestauranteApp.Models;
using RestauranteApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace RestauranteApp.ViewsModels
{
    public class RestaurantsPageViewModel : BaseViewModel
    {

        private bool _IsRefreshing;

        public bool IsRefreshing
        {
            get { return _IsRefreshing; }
            set { _IsRefreshing = value;
                OnPropertyChanged("IsRefreshing");
                }
        }


        public ObservableCollection<RestaurantModel> Restaurantes { get; set; }

        public RestaurantsPageViewModel()
        {
            Restaurantes = new ObservableCollection<RestaurantModel>();
            LoadRestaurants();
        }

        async private void LoadRestaurants()
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            if(deviceService.CheckConnectivity())
            {
                IsRefreshing = true;
                foreach (var item in await new RestaurantRepository().GetRestaurants())
                {
                    Restaurantes.Add(item);
                }
                IsRefreshing = false;
            }


            
        }
    }
}
