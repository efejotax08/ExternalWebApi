using Microsoft.AspNetCore.Mvc;

namespace ExternalWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Cities = new[]
        {
            "Quito", "Guayaquil", "Cuenca", "Ambato", "Loja"
        };

        private static readonly Random rng = new Random();

        [HttpGet]
        public IActionResult Get()
        {
            var weatherData = Enumerable.Range(1, 200).Select(index => new
            {
                fecha = DateTime.Now.AddDays(index).ToString("yyyy-MM-dd"),
                ciudad = Cities[rng.Next(Cities.Length)],
                temperatura = rng.Next(10, 30),       // grados 
                humedad = rng.Next(40, 90),           // %
                precipitacion = rng.NextDouble() < 0.3 ? rng.Next(0, 10) : 0  // mm de lluvia
            })
            .ToList();

            return Ok(weatherData);
        }
    }
}
