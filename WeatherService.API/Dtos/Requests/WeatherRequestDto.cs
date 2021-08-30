using WeatherService.API.Server.Infrastructure;
using WeatherService.API.Server.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherService.API.Server.Dtos.Requests
{
    public class WeatherRequestDto : PaginationRequestModel
    {
        [Required]
        public City City { get; set; }

        [NotDefaultDateTime]
        public DateTime? Date { get; set; }
    }
}
