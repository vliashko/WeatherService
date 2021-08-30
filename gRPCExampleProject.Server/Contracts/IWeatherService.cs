using gRPCExampleProject.Server.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gRPCExampleProject.Server.Contracts
{
    public interface IWeatherService
    {
        public Task<List<WeatherResponseDto>> GetWeathers();
    }
}
