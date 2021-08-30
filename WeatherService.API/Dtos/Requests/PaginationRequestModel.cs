using WeatherService.API.Infrastructure;

namespace WeatherService.API.Dtos.Requests
{
    public abstract class PaginationRequestModel
    {
        public int PageNumber { get; set; } = Constants.BASE_PAGE_NUMBER;

        public int PageSize { get; set; } = Constants.BASE_PAGE_SIZE;
    }
}
