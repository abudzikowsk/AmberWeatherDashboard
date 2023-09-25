using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace AmberWeatherDashboard_Server.Models.OpenWeather
{
	public class OpenWeatherResponse
    {
		public Coordinates Coord { get; set; }
		public Weather[] Weather { get; set; }

        public string Base { get; set; }

		public Main Main { get; set; }

        public int Visibility { get; set; }

		public Wind Wind { get; set; }
		public Rain Rain { get; set; }
		public Clouds Clouds { get; set; }

        public int Dt { get; set; }

		public Sys Sys { get; set; }

		public int Timezone { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public int Cod { get; set; }
	}
}

