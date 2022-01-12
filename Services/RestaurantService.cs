using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Entities;
using Restaurant.Exceptions;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDBContext _dBContext;
        private readonly IMapper _mapper;

        public RestaurantService(Entities.RestaurantDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var restaurant = _dBContext
               .Restaurants
               .FirstOrDefault(r => r.Id == id);

            if (restaurant == null) throw new NotFoundException("Restaurant not found");

            _dBContext.Restaurants.Remove(restaurant);
            _dBContext.SaveChanges();
        }

        public int Create(CreateRestaurantDTO dto)
        {
            var restaurant = _mapper.Map<Entities.Restaurant>(dto);
            _dBContext.Restaurants.Add(restaurant);
            _dBContext.SaveChanges();
            return restaurant.Id;
        }

        public IEnumerable<RestaurantDTO> GetAll()
        {
            var restaurants = _dBContext
              .Restaurants
              .Include(r => r.Address)
              .Include(r => r.Dishes)
              .ToList();

            var restaurantsDTO = _mapper.Map<List<RestaurantDTO>>(restaurants);
            return restaurantsDTO;
        }

        public RestaurantDTO GetById(int id)
        {
            var restaurant = _dBContext
               .Restaurants
               .Include(r => r.Address)
               .Include(r => r.Dishes)
               .FirstOrDefault(r => r.Id == id);

            var result = _mapper.Map<RestaurantDTO>(restaurant);
            return result;
        }

        public void Modify(int id, UpdateRestaurantDTO dto)
        {
            var restaurant = _dBContext
               .Restaurants
               .FirstOrDefault(r => r.Id == id);

            if (restaurant == null) throw new NotFoundException("Restaurant not found");

            restaurant.Name = dto.Name;
            restaurant.HasDelivery = dto.HasDelivery;
            restaurant.Description = dto.Description;

            _dBContext.SaveChanges();

        }
    }
}
