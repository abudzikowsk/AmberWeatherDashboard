using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AmberWeatherDashboard.Server.Helpers;
using AmberWeatherDashboard.Server.Services;
using AmberWeatherDashboard_Server.Models;
using AmberWeatherDashboard_Server.Models.OpenWeather;
using Microsoft.AspNetCore.Mvc;

namespace AmberWeatherDashboard_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WindController : ControllerBase
    {
        private readonly WeatherService weatherService;

        public WindController(WeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        public async Task<WindResponse> GetWindData()
        {
            var json = await weatherService.GetWeatherData();

            var response = new WindResponse();
            response.Speed = WeatherDataHelpers.GetWindSpeedInKmPerHours(json.Wind.Speed);
            response.Direction = WeatherDataHelpers.GetWindDirection(json.Wind.Deg);
            response.Message = GetMessage(response.Direction, response.Speed);
            return response;
        }

        private string GetMessage(string direction, double speed)
        {
            if (speed >= 60 || (speed >= 30 && (direction == "N" || direction == "NNE" || direction == "NE")))
            {
                return "Zwycięstwo gwarantowane! Ruszaj po bursztyn żegalarzu!";
            }
            return "Zawsze jest szansa, spróbuj swojego szczęścia!";
        }
    }
}

