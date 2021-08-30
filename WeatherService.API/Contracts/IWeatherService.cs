using WeatherService.API.Server.Dtos.Requests;
using WeatherService.API.Server.Dtos.Responses;
using System.Threading.Tasks;

namespace WeatherService.API.Server.Contracts
{
    public interface IWeatherService
    {
        public Task<BaseResponseModel<WeatherResponseDto>> GetWeathersAsync(WeatherRequestDto request);
    }
}
