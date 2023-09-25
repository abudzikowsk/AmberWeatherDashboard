using System;
using AmberWeatherDashboard.Server.Database.Repositories;
using AmberWeatherDashboard.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmberWeatherDashboard.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherHistoricalDataRepository weatherHistoricalDataRepository;

        public WeatherController(WeatherHistoricalDataRepository weatherHistoricalDataRepository)
		{
            this.weatherHistoricalDataRepository = weatherHistoricalDataRepository;
        }

        [HttpGet]
        public async Task<WeatherDataResponse[]> GetWeatherData()
        {
            var data = await weatherHistoricalDataRepository.GetAll();

            var mappedData = new List<WeatherDataResponse>();

            foreach (var d in data)
            {
                mappedData.Add(new WeatherDataResponse
                {
                    Id = d.Id,
                    Date = d.Date,
                    Humidity = d.Humidity,
                    Pressure = d.Pressure,
                    Rainfall = d.Rainfall,
                    Temperature = d.Temperature,
                    WindDirection = d.WindDirection,
                    WindGusts = d.WindGusts,
                    WindSpeed = d.WindSpeed
                });
            }
            return mappedData.ToArray();
        }

    }

}

