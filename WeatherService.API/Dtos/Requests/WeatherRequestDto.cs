using WeatherService.API.Infrastructure;
using WeatherService.API.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherService.API.Dtos.Requests
{
    /// <summary>
    /// Request model for to get weather information
    /// </summary>
    public class WeatherRequestDto : PaginationRequestModel
    {
        /// <summary>
        /// City for weather search [Minsk, Brest, Grodno, Gomel, Vitebsk, Mogilev]
        /// </summary>
        /// <example>
        /// Minsk
        /// </example>
        [Required]
        public City City { get; set; }

        /// <summary>
        /// Date for search
        /// </summary>
        /// <example>
        /// 2021-07-30
        /// </example>
        [NotDefaultDateTime]
        public DateTime? Date { get; set; }
    }
}
