using WeatherService.API.Infrastructure;

namespace WeatherService.API.Dtos.Requests
{
    /// <summary>
    /// Model with request model for pagination
    /// </summary>
    public abstract class PaginationRequestModel
    {
        /// <summary>
        /// Page Number
        /// </summary>
        /// <example>
        /// 2
        /// </example>
        public int PageNumber { get; set; } = Constants.BASE_PAGE_NUMBER;

        /// <summary>
        /// Page Size
        /// </summary>
        /// <example>
        /// 10
        /// </example>
        public int PageSize { get; set; } = Constants.BASE_PAGE_SIZE;
    }
}
