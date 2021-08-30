using AutoMapper;
using WeatherService.API.Dtos.Requests;
using WeatherService.API.Dtos.Responses;
using WeatherService.API.Models;

namespace WeatherService.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Weather, WeatherResponseDto>().ReverseMap();
            CreateMap<AddWeatherRequestDto, Weather>();
            CreateMap<UpdateWeatherRequestDto, Weather>().ReverseMap();

            CreateMap<City, CityResponseDto>();
        }
    }
}