using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.API.Models;

namespace WeatherService.API.Contracts
{
    public interface IWeatherRepository
    {
        public Task<int> GetWeathersCountAsync(Guid cityId, DateTime? date);

        public Task<List<Weather>> GetWeathersAsync(Guid cityId, DateTime? date, int pageNumber, int pageSize);

        public Task<Weather> GetWeatherByIdAsync(Guid id);

        public Task<Weather> AddWeatherAsync(Weather weather);

        public Task<Weather> UpdateWeatherAsync(Weather weather);
    }
}
