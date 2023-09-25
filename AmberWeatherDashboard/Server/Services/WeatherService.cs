using System;
using System.Net.Http;
using System.Text.Json;
using AmberWeatherDashboard_Server.Models.OpenWeather;

namespace AmberWeatherDashboard.Server.Services
{
	public class WeatherService
	{
        private readonly HttpClient httpClient;

        public WeatherService(HttpClient httpClient)
		{
            this.httpClient = httpClient;
        }

        public async Task<OpenWeatherResponse> GetWeatherData()
        {
            var response = await httpClient.GetAsync("https://api.openweathermap.org/data/2.5/weather?lat=54.50&lon=18.55&appid=e786afb775c09fd77cf5e682e1901660&units=metric");
            var stringResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<OpenWeatherResponse>(stringResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }
}

