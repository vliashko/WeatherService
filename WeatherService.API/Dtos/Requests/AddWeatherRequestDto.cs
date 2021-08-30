using System;

namespace WeatherService.API.Dtos.Requests
{
    /// <summary>
    /// Add model for weather
    /// </summary>
    // TODO: Add validation
    public class AddWeatherRequestDto
    {
        /// <summary>
        /// Date and time for weather
        /// </summary>
        /// <example>
        /// 2021-08-31T09:56:57.7292855+03:00
        /// </example>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Temperature in Сelsius
        /// </summary>
        /// <example>
        /// 26
        /// </example>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Description of tracking weather
        /// </summary>
        /// <example>
        /// Cool
        /// </example>
        public string Summary { get; set; }
    }
}
