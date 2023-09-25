using System;
namespace AmberWeatherDashboard_Server.Models.OpenWeather
{
	public class Sys
	{
		public int Type { get; set; }
		public int Id { get; set; }
		public string Country { get; set; }
		public int Sunrise { get; set; }
		public int Sunset { get; set; }
	}
}

