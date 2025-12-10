using Microsoft.AspNetCore.Mvc;

namespace ExternalWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Cities = new[]
        {
            "Quito", "Guayaquil", "Cuenca", "Ambato","Riobamba"
        };

        private static readonly Random rng = new Random();

        [HttpGet]
        public IActionResult Get()
        {
            DateTime startDate = new DateTime(2025, 1, 1);
            var weatherData = Enumerable.Range(1, 400).Select(index => new
            {
                fecha = startDate.AddDays(index).ToString("yyyy-MM-dd"),
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
