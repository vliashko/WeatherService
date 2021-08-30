using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.API.Contracts;
using WeatherService.API.Dtos.Requests;
using WeatherService.API.Dtos.Responses;

namespace WeatherService.API.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;

        private readonly IMapper _mapper;

        public CityService(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel<CityResponseDto>> GetAllCitiesAsync(CityRequestDto request)
        {
            var cities = await _repository.GetAllCitiesAsync(request.PageNumber, request.PageSize).ConfigureAwait(false);

            var dtoCities = _mapper.Map<List<CityResponseDto>>(cities);

            var count = await _repository.GetAllCitiesCountAsync().ConfigureAwait(false);

            var result = new BaseResponseModel<CityResponseDto>()
            {
                Objects = dtoCities,
                PageModel = new PaginationResponseModel(count, request.PageNumber, request.PageSize)
            };

            return result;
        }

        public async Task<CityResponseDto> GetCityByIdAsync(Guid id)
        {
            var result = await _repository.GetCityByIdAsync(id).ConfigureAwait(false);

            var cityDto = result == null ? null : _mapper.Map<CityResponseDto>(result);

            return cityDto;
        }
    }
}
