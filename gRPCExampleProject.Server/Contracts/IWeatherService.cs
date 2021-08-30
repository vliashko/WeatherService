using gRPCExampleProject.Server.Dtos.Requests;
using gRPCExampleProject.Server.Dtos.Responses;
using System.Threading.Tasks;

namespace gRPCExampleProject.Server.Contracts
{
    public interface IWeatherService
    {
        public Task<BaseResponseModel<WeatherResponseDto>> GetWeathers(WeatherRequestDto request);
    }
}
