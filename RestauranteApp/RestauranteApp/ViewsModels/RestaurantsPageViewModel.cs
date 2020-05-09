using RestauranteApp.Models;
using RestauranteApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RestauranteApp.ViewsModels
{
    public class RestaurantsPageViewModel
    {
        public ObservableCollection<RestaurantModel> Restaurantes { get; set; }

        public RestaurantsPageViewModel()
        {
            Restaurantes = new ObservableCollection<RestaurantModel>();
            LoadRestaurants();
        }

        async private void LoadRestaurants()
        {
            foreach (var item in await new RestaurantRepository().GetRestaurants())
            {
                Restaurantes.Add(item);
            }
        }
    }
}
