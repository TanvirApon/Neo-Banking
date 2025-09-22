using BankingSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Banking_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly BankingSystemContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, BankingSystemContext context)
        {
            _logger = logger;
            this._context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
           var model = _context.Users.ToList();
            return Ok(model);
        }
    }
}
