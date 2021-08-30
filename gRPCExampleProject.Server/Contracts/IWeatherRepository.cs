using gRPCExampleProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gRPCExampleProject.Server.Contracts
{
    public interface IWeatherRepository
    {
        public Task<int> GetWeathersCountAsync(City city, DateTime? date);

        public Task<List<Weather>> GetWeathersAsync(City city, DateTime? date, int pageNumber, int pageSize);
    }
}
