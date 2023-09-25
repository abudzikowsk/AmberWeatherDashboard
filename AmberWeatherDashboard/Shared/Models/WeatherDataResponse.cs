using System;
namespace AmberWeatherDashboard.Shared.Models
{
	public class WeatherDataResponse
	{
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Rainfall { get; set; }
        public double Pressure { get; set; }
        public double WindSpeed { get; set; }
        public double WindGusts { get; set; }
        public string WindDirection { get; set; }
    }
}

