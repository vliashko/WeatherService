using AutoMapper;
using gRPCExampleProject.Server.Dtos;
using gRPCExampleProject.Server.Models;

namespace gRPCExampleProject.Server.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Weather, WeatherResponseDto>();
        }
    }
}