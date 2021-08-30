using gRPCExampleProject.Server.Contracts;
using gRPCExampleProject.Server.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gRPCExampleProject.Server.Controllers
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
        /// <response code="200">Success. List of weather was received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<WeatherResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader(Name = "x-correlation-id")] string correlationId)
        {
            var weathers = await _service.GetWeathers().ConfigureAwait(false);

            return Ok(weathers);
        }
    }
}
