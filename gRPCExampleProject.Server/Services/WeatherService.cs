using AutoMapper;
using gRPCExampleProject.Server.Contracts;
using gRPCExampleProject.Server.Dtos.Requests;
using gRPCExampleProject.Server.Dtos.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gRPCExampleProject.Server.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;
        private readonly IMapper _mapper;

        public WeatherService(IWeatherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel<WeatherResponseDto>> GetWeathers(WeatherRequestDto request)
        {
            var weathers = await _repository.GetWeathers(request.City, request.Date, request.PageNumber, request.PageSize).ConfigureAwait(false);

            var dtoWeathers = _mapper.Map<List<WeatherResponseDto>>(weathers);

            var count = await _repository.GetWeathersCount(request.City, request.Date);

            var result = new BaseResponseModel<WeatherResponseDto>()
            {
                Objects = dtoWeathers,
                PageModel = new PaginationResponseModel(count, request.PageNumber, request.PageSize)
            };

            return result;
        }
    }
}
