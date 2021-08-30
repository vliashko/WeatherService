using System.Collections.Generic;

namespace WeatherService.API.Dtos.Responses
{
    /// <summary>
    /// Base Response Model for result
    /// </summary>
    /// <typeparam name="T">Type of DTO Model</typeparam>
    public class BaseResponseModel<T>
    {
        /// <summary>
        /// Page Model for pagination
        /// </summary>
        public PaginationResponseModel PageModel { get; set; }

        /// <summary>
        /// Collection of DTO models
        /// </summary>
        public IEnumerable<T> Objects { get; set; }
    }
}
