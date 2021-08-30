using WeatherService.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherService.API.Contracts
{
    public interface IWeatherRepository
    {
        public Task<int> GetWeathersCountAsync(City city, DateTime? date);

        public Task<List<Weather>> GetWeathersAsync(City city, DateTime? date, int pageNumber, int pageSize);

        public Task<Weather> GetWeatherByIdAsync(Guid id);

        public Task<Weather> AddWeather(Weather weather);

        public Task<Weather> UpdateWeather(Weather weather);
    }
}
