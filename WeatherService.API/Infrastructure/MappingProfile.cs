using AutoMapper;
using WeatherService.API.Dtos.Responses;
using WeatherService.API.Models;

namespace WeatherService.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Weather, WeatherResponseDto>();
        }
    }
}