using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.API.Contracts;
using WeatherService.API.Dtos.Requests;
using WeatherService.API.Dtos.Responses;
using WeatherService.API.Models;

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

        public async Task<WeatherResponseDto> AddWeatherAsync(Guid cityId, AddWeatherRequestDto request)
        {
            var weather = _mapper.Map<Weather>(request);

            weather.TemperatureF = 32 + (int)(weather.TemperatureC / 0.5556);

            weather.CityId = cityId;

            var result = await _repository.AddWeatherAsync(weather).ConfigureAwait(false);

            var weatherDto = _mapper.Map<WeatherResponseDto>(result);

            return weatherDto;
        }

        public async Task DeleteWeatherAsync(WeatherResponseDto weatherDto)
        {
            var weather = _mapper.Map<Weather>(weatherDto);

            await _repository.DeleteWeatherAsync(weather);
        }

        public async Task<WeatherResponseDto> GetWeatherByIdAsync(Guid id)
        {
            var weather = await _repository.GetWeatherByIdAsync(id).ConfigureAwait(false);

            var weatherDto = weather == null ? null : _mapper.Map<WeatherResponseDto>(weather);

            return weatherDto;
        }

        public async Task<BaseResponseModel<WeatherResponseDto>> GetWeathersAsync(WeatherRequestDto request)
        {
            var weathers = await _repository.GetWeathersAsync(request.CityId, request.Date, request.PageNumber, request.PageSize).ConfigureAwait(false);

            var dtoWeathers = _mapper.Map<List<WeatherResponseDto>>(weathers);

            var count = await _repository.GetWeathersCountAsync(request.CityId, request.Date).ConfigureAwait(false);

            var result = new BaseResponseModel<WeatherResponseDto>()
            {
                Objects = dtoWeathers,
                PageModel = new PaginationResponseModel(count, request.PageNumber, request.PageSize)
            };

            return result;
        }

        public async Task<WeatherResponseDto> UpdateWeatherAsync(WeatherResponseDto weatherDto, UpdateWeatherRequestDto request)
        {
            var weather = _mapper.Map<Weather>(weatherDto);

            _mapper.Map(request, weather);

            weather.TemperatureF = 32 + (int)(weather.TemperatureC / 0.5556);

            await _repository.UpdateWeatherAsync(_mapper.Map<Weather>(weather)).ConfigureAwait(false);

            return _mapper.Map<WeatherResponseDto>(weather);
        }
    }
}
