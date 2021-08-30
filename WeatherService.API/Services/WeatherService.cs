using AutoMapper;
using WeatherService.API.Contracts;
using WeatherService.API.Dtos.Requests;
using WeatherService.API.Dtos.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherService.API.Services
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

        public async Task<BaseResponseModel<WeatherResponseDto>> GetWeathersAsync(WeatherRequestDto request)
        {
            var weathers = await _repository.GetWeathersAsync(request.City, request.Date, request.PageNumber, request.PageSize).ConfigureAwait(false);

            var dtoWeathers = _mapper.Map<List<WeatherResponseDto>>(weathers);

            var count = await _repository.GetWeathersCountAsync(request.City, request.Date);

            var result = new BaseResponseModel<WeatherResponseDto>()
            {
                Objects = dtoWeathers,
                PageModel = new PaginationResponseModel(count, request.PageNumber, request.PageSize)
            };

            return result;
        }
    }
}
