using gRPCExampleProject.Server.Contracts;
using gRPCExampleProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCExampleProject.Server.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly string[] states = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<List<Weather>> GetWeathers()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Weather
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = states[rng.Next(states.Length)]
            })
            .ToList();
        }
    }
}
