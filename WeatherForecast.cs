namespace ExternalWebApi
{
    public class WeatherForecast
    {
        public DateTime Fecha { get; set; }
        public string Ciudad { get; set; } = string.Empty;
        public double Temperatura { get; set; }
        public int Humedad { get; set; }
        public double Precipitacion { get; set; }

    }
}
