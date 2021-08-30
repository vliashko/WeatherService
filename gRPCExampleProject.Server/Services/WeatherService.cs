using AutoMapper;
using gRPCExampleProject.Server.Contracts;
using gRPCExampleProject.Server.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gRPCExampleProject.Server.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;
        private readonly IMapper _mapper;

        public WeatherService(IWeatherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<WeatherResponseDto>> GetWeathers()
        {
            var weathers = await _repository.GetWeathers().ConfigureAwait(false);

            var dtoWeathers = _mapper.Map<List<WeatherResponseDto>>(weathers);

            return dtoWeathers;
        }
    }
}
