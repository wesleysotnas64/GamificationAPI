using Microsoft.AspNetCore.Mvc;
using DotNetEnv;

namespace GamificationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            // Carrega as vari�veis do arquivo .env
            Env.Load();

            // Obt�m a vari�vel de ambiente
            string? message = Environment.GetEnvironmentVariable("MESSAGE");

            // Retorna um erro caso a vari�vel seja null
            if (string.IsNullOrEmpty(message))
            {
                return BadRequest("MESSAGE n�o encontrada ou est� vazia.");
            }

            return Ok(message);
        }
    }
}
