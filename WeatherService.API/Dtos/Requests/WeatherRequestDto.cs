using WeatherService.API.Infrastructure;
using WeatherService.API.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherService.API.Dtos.Requests
{
    public class WeatherRequestDto : PaginationRequestModel
    {
        [Required]
        public City City { get; set; }

        [NotDefaultDateTime]
        public DateTime? Date { get; set; }
    }
}
