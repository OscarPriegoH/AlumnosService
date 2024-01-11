using Exodus.BaseAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlumnosService.API.Controllers.v2
{
    

    [ApiVersion("2.0")]
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
            _logger.LogInformation("Recuperando informacion de v2");
            return "Running v2.0";
        }

    }
}
