using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using WeatherService.API.Contracts;
using WeatherService.API.Dtos.Requests;
using WeatherService.API.Dtos.Responses;

namespace WeatherService.API.Controllers
{
    [ApiController]
    [Route("api/v1/cities")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class CityController : BaseController
    {
        private readonly ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get list of cities
        /// </summary>
        /// <param name="correlationId">The value that is used to combine several requests into a common group</param>
        /// <param name="request">Model for search</param>
        /// <response code="200">Success. List of cities was received successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(BaseResponseModel<CityResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader(Name = "x-correlation-id")] string correlationId, [FromQuery] CityRequestDto request)
        {
            var response = await _service.GetAllCitiesAsync(request).ConfigureAwait(false);

            return Ok(response);
        }

        /// <summary>
        /// Get city by Id
        /// </summary>
        /// <param name="correlationId">The value that is used to combine several requests into a common group</param>
        /// <param name="id">Id for search</param>
        /// <response code="200">Success. City was received successfully</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(CityResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromHeader(Name = "x-correlation-id")] string correlationId, [FromRoute] Guid id)
        {
            var response = await _service.GetCityByIdAsync(id).ConfigureAwait(false);

            if (response is null)
            {
                return NotFound(new BaseErrorResponse((int)HttpStatusCode.NotFound, "City by provided id not found."));
            }

            return Ok(response);
        }
    }
}
