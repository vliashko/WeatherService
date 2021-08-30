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
    [Route("api/v1/weathers")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class WeatherController : BaseController
    {
        private readonly IWeatherService _service;

        private readonly ICityService _cityService;

        public WeatherController(IWeatherService service, ICityService cityService)
        {
            _service = service;
            _cityService = cityService;
        }

        /// <summary>
        /// Get list of weathers
        /// </summary>
        /// <param name="correlationId">The value that is used to combine several requests into a common group</param>
        /// <param name="request">Model for search</param>
        /// <response code="200">Success. List of weathers was received successfully</response>
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

        /// <summary>
        /// Get weather by Id
        /// </summary>
        /// <param name="correlationId">The value that is used to combine several requests into a common group</param>
        /// <param name="id">Id for search</param>
        /// <response code="200">Success. Weather was received successfully</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(WeatherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromHeader(Name = "x-correlation-id")] string correlationId, [FromRoute] Guid id)
        {
            var response = await _service.GetWeatherByIdAsync(id).ConfigureAwait(false);

            if (response is null)
            {
                return NotFound(new BaseErrorResponse((int)HttpStatusCode.NotFound, "Weather by provided id not found."));
            }

            return Ok(response);
        }

        /// <summary>
        /// Add weather for provided city
        /// </summary>
        /// <param name="correlationId">The value that is used to combine several requests into a common group</param>
        /// <param name="request">Model for create</param>
        /// <param name="cityId">Id of city</param>
        /// <response code="201">Created. Weather was created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(WeatherResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Add([FromHeader(Name = "x-correlation-id")] string correlationId, [FromQuery] Guid cityId, [FromBody] AddWeatherRequestDto request)
        {
            if (request is null)
            {
                return BadRequest(new BaseErrorResponse((int)HttpStatusCode.BadRequest, "AddWeatherRequestDto cannot be null."));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseErrorResponse((int)HttpStatusCode.BadRequest, GetErrorMessage(ModelState)));
            }

            var city = await _cityService.GetCityByIdAsync(cityId).ConfigureAwait(false);

            if (city is null)
            {
                return NotFound(new BaseErrorResponse((int)HttpStatusCode.NotFound, "City by provided cityId not found."));
            }

            var response = await _service.AddWeatherAsync(cityId, request).ConfigureAwait(false);

            return CreatedAtAction(nameof(Get), response.Id, response);
        }

        /// <summary>
        /// Update weather for provided id
        /// </summary>
        /// <param name="correlationId">The value that is used to combine several requests into a common group</param>
        /// <param name="request">Model for update</param>
        /// <param name="id">Id for search</param>
        /// <response code="200">Success. Weather was updated successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(WeatherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromHeader(Name = "x-correlation-id")] string correlationId, [FromRoute] Guid id, [FromBody] UpdateWeatherRequestDto request)
        {
            if (request is null)
            {
                return BadRequest(new BaseErrorResponse((int)HttpStatusCode.BadRequest, "AddWeatherRequestDto cannot be null."));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseErrorResponse((int)HttpStatusCode.BadRequest, GetErrorMessage(ModelState)));
            }

            var weather = await _service.GetWeatherByIdAsync(id).ConfigureAwait(false);

            if (weather is null)
            {
                return NotFound(new BaseErrorResponse((int)HttpStatusCode.NotFound, "Weather by provided id not found."));
            }

            var response = await _service.UpdateWeatherAsync(weather, request).ConfigureAwait(false);

            return Ok(response);
        }

        /// <summary>
        /// Delete weather by provided id
        /// </summary>
        /// <param name="correlationId">The value that is used to combine several requests into a common group</param>
        /// <param name="id">Id for search</param>
        /// <response code="204">Success. Weather was deleted successfully</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(WeatherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromHeader(Name = "x-correlation-id")] string correlationId, [FromRoute] Guid id)
        {
            var weather = await _service.GetWeatherByIdAsync(id).ConfigureAwait(false);

            if (weather is null)
            {
                return NotFound(new BaseErrorResponse((int)HttpStatusCode.NotFound, "Weather by provided id not found."));
            }

            await _service.DeleteWeatherAsync(weather).ConfigureAwait(false);

            return NoContent();
        }
    }
}
