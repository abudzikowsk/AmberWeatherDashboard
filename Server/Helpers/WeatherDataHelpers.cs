using System;
namespace AmberWeatherDashboard.Server.Helpers
{
	public static class WeatherDataHelpers
	{
        private static string[] compassSectors = new string[] { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };

        public static string GetWindDirection(int deg)
        {
            var index = deg % 360;
            index = (int)Math.Round(index / 22.5);
            return compassSectors[index];
        }

        public static double GetWindSpeedInKmPerHours(double speed)
        {
            return (speed * 3600) / 1000;
        }
    }
}

