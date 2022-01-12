using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public interface IRestaurantService
    {
        public Models.RestaurantDTO GetById(int id);

        public IEnumerable<Models.RestaurantDTO> GetAll();

        public int Create(CreateRestaurantDTO dto);

        public void Delete(int id);

        public void Modify(int id, UpdateRestaurantDTO dto);
    }
}
