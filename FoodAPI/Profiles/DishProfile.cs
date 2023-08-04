using AutoMapper;
using FoodAPI.Entities;
using FoodAPI.Models;

namespace FoodAPI.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDto>();
            CreateMap<DishForCreateDto, Dish>();
            CreateMap<DishForUpdateDto, Dish>();
            CreateMap<Dish, DishForPreview>();
        }
    }
}
