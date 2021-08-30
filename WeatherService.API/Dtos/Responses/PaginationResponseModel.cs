using System;

namespace WeatherService.API.Server.Dtos.Responses
{
    public class PaginationResponseModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int Count { get; set; }

        public PaginationResponseModel(int count, int pageNumber, int pageSize)
        {
            Count = count;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageNumber > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageNumber < TotalPages;
            }
        }
    }
}
