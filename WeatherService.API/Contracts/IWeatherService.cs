using System;
using System.Threading.Tasks;
using WeatherService.API.Dtos.Requests;
using WeatherService.API.Dtos.Responses;

namespace WeatherService.API.Contracts
{
    public interface IWeatherService
    {
        public Task<BaseResponseModel<WeatherResponseDto>> GetWeathersAsync(WeatherRequestDto request);

        public Task<WeatherResponseDto> GetWeatherByIdAsync(Guid id);

        public Task<WeatherResponseDto> AddWeatherAsync(Guid cityId, AddWeatherRequestDto request);

        public Task<WeatherResponseDto> UpdateWeatherAsync(WeatherResponseDto weatherDto, UpdateWeatherRequestDto request);

        public Task DeleteWeatherAsync(WeatherResponseDto weatherDto);
    }
}
