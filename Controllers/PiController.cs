using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using piapi.Models;
using piapi.Services;

namespace piapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PiController : ControllerBase
    {
        private readonly ILogger<PiController> _logger;
        private readonly ILedService _ledService;

        public PiController(ILogger<PiController> logger, ILedService ledService)
        {
            _logger = logger;
            _ledService = ledService;
        }

        [HttpGet]
        public async Task<GpioModel> Get() => new GpioModel
        {
            LedIlluminated = await _ledService.GetIlluminatedAsync()
        };
    }
}
