using System;
using AmberWeatherDashboard.Server.Database.Entities;
using AmberWeatherDashboard.Server.Database.Repositories;
using AmberWeatherDashboard.Server.Helpers;
using AmberWeatherDashboard.Server.Services;
namespace AmberWeatherDashboard.Server.Jobs
{
	public class GetWeatherDataJob
	{
        private readonly WeatherService weatherService;
        private readonly WeatherHistoricalDataRepository weatherHistoricalDataRepository;

        public GetWeatherDataJob(WeatherService weatherService, WeatherHistoricalDataRepository weatherHistoricalDataRepository)
		{
            this.weatherService = weatherService;
            this.weatherHistoricalDataRepository = weatherHistoricalDataRepository;
        }
        //run na job
        public async Task Run()
        {
            var weatherData = await weatherService.GetWeatherData();
            var historicalData = new WeatherData
            {
                Pressure = weatherData.Main.Pressure,
                Humidity = weatherData.Main.Humidity,
                Rainfall = weatherData.Rain?.Oneh ?? 0,
                Temperature = weatherData.Main.Temp,
                WindDirection = WeatherDataHelpers.GetWindDirection(weatherData.Wind.Deg),
                WindGusts = 0,
                WindSpeed = WeatherDataHelpers.GetWindSpeedInKmPerHours(weatherData.Wind.Speed)
            };

            await weatherHistoricalDataRepository.Create(historicalData);
        }
	}
}

