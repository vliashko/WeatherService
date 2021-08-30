using System;
using System.ComponentModel.DataAnnotations;
using WeatherService.API.Infrastructure;

namespace WeatherService.API.Dtos.Requests
{
    /// <summary>
    /// Request model for to get weather information
    /// </summary>
    public class WeatherRequestDto : PaginationRequestModel
    {
        /// <summary>
        /// City id for search
        /// </summary>
        /// <example>
        /// b06479a2-4c2f-425b-a7da-baed1e364dc7
        /// </example>
        [Required]
        [NonEmptyGuid]
        public Guid CityId { get; set; }

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
