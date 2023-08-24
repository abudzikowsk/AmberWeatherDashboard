using System;
using System.Text.Json.Serialization;

namespace AmberWeatherDashboard_Server.Models.OpenWeather
{
	public class Rain
	{
        [JsonPropertyName("1h")]
        public double Oneh { get; set; }
	}
}

