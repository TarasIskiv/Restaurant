using AutoMapper;
using Restaurant.Models;

namespace Restaurant
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Entities.Restaurant, RestaurantDTO>()
                .ForMember(c => c.City, r => r.MapFrom(s => s.Address.City))
                .ForMember(c => c.Street, r => r.MapFrom(s => s.Address.Street))
                .ForMember(c => c.PostalCode, r => r.MapFrom(s => s.Address.PostalCode));

            CreateMap<Entities.Dish, DishDTO>();

            CreateMap<CreateRestaurantDTO, Entities.Restaurant>()
                .ForMember(c => c.Address, r => r.MapFrom(dto => new Entities.Address()
                {
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode
                }));
        }
    }
}
