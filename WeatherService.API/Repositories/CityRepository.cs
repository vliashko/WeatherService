using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherService.API.Contracts;
using WeatherService.API.Infrastructure;
using WeatherService.API.Models;

namespace WeatherService.API.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly RepositoryDbContext _context;

        public CityRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllCitiesAsync(int pageNumber, int pageSize)
        {
            return await _context.Cities
                     .OrderBy(w => w.Name)
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .AsNoTracking()
                     .ToListAsync()
                     .ConfigureAwait(false);
        }

        public Task<int> GetAllCitiesCountAsync()
        {
            var count = _context.Cities.CountAsync();

            return count;
        }

        public async Task<City> GetCityByIdAsync(Guid id)
        {
            var result = await _context.Cities.FindAsync(id).ConfigureAwait(false);

            return result;
        }
    }
}
