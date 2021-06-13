using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AirportDistance.Features.Distance {
    [ApiController]
    [Route("[controller]")]
    public class DistanceController: ControllerBase {
        private readonly ILogger<DistanceController> _logger;
        private readonly Distance _distanceRequestHandler;
        public DistanceController(ILogger<DistanceController> logger, Distance distanceRequestHandler) {
            _logger = logger;
            _distanceRequestHandler = distanceRequestHandler;
        }
        
        /// <summary>
        ///     Gets distance in miles between two airports
        /// </summary>
        /// <returns>Distance in miles</returns>
        /// <example>10188</example>
        [HttpGet]
        [ProducesResponseType(typeof(double), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), (int) HttpStatusCode.InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public double GetDistance([FromQuery] Distance.Request request) {
            _logger.LogInformation("Requesting distance from {Src} to {Dst}", request.From, request.To);
            return _distanceRequestHandler.GetDistanceInMiles(request);
        }
    }
}