using System;

namespace WeatherService.API.Dtos.Responses
{
    /// <summary>
    /// Pagination response
    /// </summary>
    public class PaginationResponseModel
    {
        /// <summary>
        /// Page Number
        /// </summary>
        /// <example>
        /// 2
        /// </example>
        public int PageNumber { get; set; }

        /// <summary>
        /// Page Size
        /// </summary>
        /// <example>
        /// 10
        /// </example>
        public int PageSize { get; set; }

        /// <summary>
        /// Total pages
        /// </summary>
        /// <example>
        /// 20
        /// </example>
        public int TotalPages { get; set; }

        /// <summary>
        /// Total count of objects with specified filtration
        /// </summary>
        /// <example>
        /// 200
        /// </example>
        public int Count { get; set; }

        public PaginationResponseModel(int count, int pageNumber, int pageSize)
        {
            Count = count;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        /// <summary>
        /// Is there previous page
        /// </summary>
        /// <example>
        /// true
        /// </example>
        public bool HasPreviousPage
        {
            get
            {
                return PageNumber > 1;
            }
        }

        /// <summary>
        /// Is there next page
        /// </summary>
        /// <example>
        /// true
        /// </example>
        public bool HasNextPage
        {
            get
            {
                return PageNumber < TotalPages;
            }
        }
    }
}
