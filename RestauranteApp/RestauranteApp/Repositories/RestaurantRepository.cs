using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestauranteApp.Models;

namespace RestauranteApp.Repositories
{
    public class RestaurantRepository
    {
        async public Task<List<RestaurantModel>> GetRestaurants()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(new
                    Uri("https://cedesistemas-app-api.azurewebsites.net/api/Restaurantes"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<RestaurantModel>>(content);
                }
            }
            return null;
        }
    }
}
