using WeatherService.API.Contracts;
using WeatherService.API.Dtos.Requests;
using WeatherService.API.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace WeatherService.API.Controllers
{
    [ApiController]
    [Route("api/v1/weathers")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _service;

        public WeatherController(IWeatherService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get list of weather
        /// </summary>
        /// <param name="correlationId">The value that is used to combine several requests into a common group</param>
        /// <param name="request">Model for search</param>
        /// <response code="200">Success. List of weather was received successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(BaseResponseModel<WeatherResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader(Name = "x-correlation-id")] string correlationId, [FromQuery] WeatherRequestDto request)
        {
            if (request is null)
            {
                return BadRequest(new BaseErrorResponse((int)HttpStatusCode.BadRequest, "WeatherRequestDto cannot be null."));
            }

            var response = await _service.GetWeathersAsync(request).ConfigureAwait(false);

            return Ok(response);
        }
    }
}
