using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDBContext _restaurantDB;
        public RestaurantSeeder(RestaurantDBContext restaurantDb)
        {
            _restaurantDB = restaurantDb;
        }
        public void Seed()
        {
            if(_restaurantDB.Database.CanConnect())
            {
                if(!_restaurantDB.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _restaurantDB.Restaurants.AddRange(restaurants);
                    _restaurantDB.SaveChanges();
                }
               
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast food",
                    Description = "KFC - is American fast food restaurant",
                    ContactEmail = "kfs.poland@gmail.com",
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville hot chicken",
                            Price = 10.30M
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M
                        },
                    },

                    Address = new Address()
                    {
                        City = "Krakow",
                        Street = "Dluga 5",
                        PostalCode = "30-001"
                    }
                },
            };
            return restaurants;
        }

    }
}
