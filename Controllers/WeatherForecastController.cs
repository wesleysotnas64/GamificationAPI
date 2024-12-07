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
            // Carrega as variáveis do arquivo .env
            Env.Load();

            // Obtém a variável de ambiente
            string? message = Environment.GetEnvironmentVariable("MESSAGE");

            // Retorna um erro caso a variável seja null
            if (string.IsNullOrEmpty(message))
            {
                return BadRequest("MESSAGE não encontrada ou está vazia.");
            }

            return Ok(message);
        }
    }
}
