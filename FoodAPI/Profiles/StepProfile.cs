using AutoMapper;
using FoodAPI.Entities;
using FoodAPI.Models;

namespace FoodAPI.Profiles
{
    public class StepProfile : Profile
    {
        public StepProfile()
        {
            CreateMap<Step, StepDto>();
            CreateMap<StepForCreateDto, Step>();
            CreateMap<StepForUpdateDto, Step>();
        }
    }
}
