using System;

namespace WeatherService.API.Dtos.Responses
{
    /// <summary>
    /// Weather model to Response
    /// </summary>
    public class WeatherResponseDto
    {
        /// <summary>
        /// Id of weather
        /// </summary>
        /// <example>
        /// 1c0151fe-b2fb-4f68-b8a5-7b2ca8a77dff
        /// </example>
        public Guid Id { get; set; }

        /// <summary>
        /// Date of tracking
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
        /// Temperature in Fahrenheit
        /// </summary>
        /// <example>
        /// 78
        /// </example>
        public int TemperatureF { get; set; }

        /// <summary>
        /// Description of tracking weather
        /// </summary>
        /// <example>
        /// Cool
        /// </example>
        public string Summary { get; set; }
    }
}
