using AutoMapper;
using WeatherService.API.Server.Dtos.Responses;
using WeatherService.API.Server.Models;

namespace WeatherService.API.Server.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Weather, WeatherResponseDto>();
        }
    }
}