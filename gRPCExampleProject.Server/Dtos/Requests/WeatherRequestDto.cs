using gRPCExampleProject.Server.Infrastructure;
using gRPCExampleProject.Server.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace gRPCExampleProject.Server.Dtos.Requests
{
    public class WeatherRequestDto : PaginationRequestModel
    {
        [Required]
        public City City { get; set; }

        [NotDefaultDateTime]
        public DateTime? Date { get; set; }
    }
}
