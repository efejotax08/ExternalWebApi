using Microsoft.AspNetCore.Mvc;

namespace ExternalWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Cities = new[]
        {
            "Quito", "Guayaquil",  "Ambato"
        };

        private static readonly Random rng = new Random();

        [HttpGet]
        public IActionResult Get()
        {
            DateTime startDate = new DateTime(2025, 1, 1);

            var weatherData = Enumerable.Range(1, 365)
                .SelectMany(index =>
                {
                    var fecha = startDate.AddDays(index).ToString("yyyy-MM-dd");
                    // generar 2 registros por día del anio
                    return new[] {
            new {
                fecha = fecha,
                ciudad = Cities[rng.Next(Cities.Length)],
                temperatura = rng.Next(10, 30), //mas
                humedad = rng.Next(40, 90),
                precipitacion = rng.NextDouble() < 0.3 ? rng.Next(0, 10) : 0
            },
            new {
                fecha = fecha,
                ciudad = Cities[rng.Next(Cities.Length)],
                temperatura = rng.Next(10, 30),
                humedad = rng.Next(40, 90),
                precipitacion = rng.NextDouble() < 0.3 ? rng.Next(0, 10) : 0
            }
                    };
                })
                .ToList();



            return Ok(weatherData);
        }
    }
}
