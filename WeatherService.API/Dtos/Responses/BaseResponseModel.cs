using System.Collections.Generic;

namespace WeatherService.API.Server.Dtos.Responses
{
    public class BaseResponseModel<T>
    {
        public PaginationResponseModel PageModel { get; set; }

        public IEnumerable<T> Objects { get; set; }
    }
}
