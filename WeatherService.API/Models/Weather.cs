using System;

namespace WeatherService.API.Models
{
    public class Weather
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }

        public Guid CityId { get; set; }

        public City City { get; set; }
    }
}
