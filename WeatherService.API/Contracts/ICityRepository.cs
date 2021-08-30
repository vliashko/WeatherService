using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.API.Models;

namespace WeatherService.API.Contracts
{
    public interface ICityRepository
    {
        public Task<City> GetCityByIdAsync(Guid id);

        public Task<int> GetAllCitiesCountAsync();

        public Task<List<City>> GetAllCitiesAsync(int pageNumber, int pageSize);
    }
}
