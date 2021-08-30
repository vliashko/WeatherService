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
    public class WeatherRepository : IWeatherRepository
    {
        private readonly RepositoryDbContext _context;

        public WeatherRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetWeathersCountAsync(Guid cityId, DateTime? date)
        {
            var result = _context.Weathers.Where(w => w.CityId == cityId);

            if (date.HasValue)
            {
                result = _context.Weathers.Where(w => w.DateTime.Date == date.Value.Date);
            }

            return await result.CountAsync()
                               .ConfigureAwait(false);
        }

        public async Task<List<Weather>> GetWeathersAsync(Guid cityId, DateTime? date, int pageNumber, int pageSize)
        {
            var result = _context.Weathers.Where(w => w.CityId == cityId);

            if (date.HasValue)
            {
                result = _context.Weathers.Where(w => w.DateTime.Date == date.Value.Date);
            }

            return await result
                         .OrderBy(w => w.DateTime)
                         .Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync()
                         .ConfigureAwait(false);
        }

        public async Task<Weather> GetWeatherByIdAsync(Guid id)
        {
            var result = await _context.Weathers.FindAsync(id).ConfigureAwait(false);

            return result;
        }

        public async Task<Weather> AddWeatherAsync(Weather weather)
        {
            var result = await _context.Weathers.AddAsync(weather).ConfigureAwait(false);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Weather> UpdateWeatherAsync(Weather weather)
        {
            var result = _context.Weathers.Update(weather);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteWeatherAsync(Weather weather)
        {
            _context.Weathers.Remove(weather);

            await _context.SaveChangesAsync();
        }
    }
}
