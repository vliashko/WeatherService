using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using WeatherService.API.Infrastructure;

namespace WeatherService.API.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ConfigureJsonSerializer();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetCorrelationId()
        {
            HttpContext.Request.Headers.TryGetValue(Constants.CORRELATION_ID, out var correlationId);

            if (!correlationId.Any())
                throw new KeyNotFoundException("Request is missing a correlationId");

            return correlationId.First();
        }

        public static void ConfigureJsonSerializer()
        {
            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),

                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    DateFormatHandling = DateFormatHandling.IsoDateFormat
                };

                return settings;
            };
        }

        public static string GetErrorMessage(ModelStateDictionary modelState)
        {
            return string.Join(" ", modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
        }
    }
}
