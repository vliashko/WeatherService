using WeatherService.API.Dtos.Requests;
using WeatherService.API.Dtos.Responses;
using System.Threading.Tasks;

namespace WeatherService.API.Contracts
{
    public interface IWeatherService
    {
        public Task<BaseResponseModel<WeatherResponseDto>> GetWeathersAsync(WeatherRequestDto request);
    }
}
