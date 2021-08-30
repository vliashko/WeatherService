using WeatherService.API.Server.Contracts;
using WeatherService.API.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherService.API.Server.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private static readonly Random random = new();

        private static readonly Array enumValues = Enum.GetValues(typeof(City));

        private readonly static string[] states = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IEnumerable<Weather> weathers = Enumerable.Range(1, 200).Select(i => new Weather()
        {
            City = (City)enumValues.GetValue(random.Next(enumValues.Length)),
            Date = DateTime.Now.AddDays(-i),
            Summary = states[random.Next(states.Length)],
            TemperatureC = random.Next(-20, 55)
        });

        public async Task<int> GetWeathersCountAsync(City city, DateTime? date)
        {
            var result = weathers.Where(w => w.City == city);

            if (date.HasValue)
            {
                result = weathers.Where(w => w.Date == date.Value.Date);
            }

            return result.Count();
        }

        public async Task<List<Weather>> GetWeathersAsync(City city, DateTime? date, int pageNumber, int pageSize)
        {
            var result = weathers.Where(w => w.City == city);

            if (date.HasValue)
            {
                result = weathers.Where(w => w.Date == date.Value.Date);
            }

            return result.Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize)
                         .OrderBy(w => w.Date)
                         .ToList();
        }
    }
}
