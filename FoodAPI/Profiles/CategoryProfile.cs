using AutoMapper;
using FoodAPI.Entities;
using FoodAPI.Models;

namespace FoodAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreateDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
            CreateMap<Category, CategoryForDishDto>();
        }
    }
}
