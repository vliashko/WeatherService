using System;
using System.Threading.Tasks;
using WeatherService.API.Dtos.Requests;
using WeatherService.API.Dtos.Responses;

namespace WeatherService.API.Contracts
{
    public interface ICityService
    {
        public Task<CityResponseDto> GetCityByIdAsync(Guid id);

        public Task<BaseResponseModel<CityResponseDto>> GetAllCitiesAsync(CityRequestDto request);
    }
}
