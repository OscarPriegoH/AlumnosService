using Exodus.BaseAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlumnosService.API.Controllers.v1
{

    [ApiVersion("1.0")]
    public class DefaultController : BaseController
    {
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public string Get()
        {
            _logger.LogInformation($"Peticion realizada a version 1.0");
            return "Running v1";
        }

    }
}
