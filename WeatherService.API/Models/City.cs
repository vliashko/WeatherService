using System;
using System.Collections.Generic;

namespace WeatherService.API.Models
{
    public class City
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Weather> Weathers { get; set; }
    }
}
