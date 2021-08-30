using gRPCExampleProject.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gRPCExampleProject.Server.Contracts
{
    public interface IWeatherRepository
    {
        public Task<List<Weather>> GetWeathers();
    }
}
