using WeatherService.API.Dtos.Requests;
using WeatherService.API.Dtos.Responses;
using System.Threading.Tasks;
using System;

namespace WeatherService.API.Contracts
{
    public interface IWeatherService
    {
        public Task<BaseResponseModel<WeatherResponseDto>> GetWeathersAsync(WeatherRequestDto request);

        public Task<WeatherResponseDto> GetWeatherByIdAsync(Guid id);

        public Task<WeatherResponseDto> AddWeatherAsync(AddWeatherRequestDto request);

        public Task<WeatherResponseDto> UpdateWeatherAsync(UpdateWeatherRequestDto request);
    }
}
