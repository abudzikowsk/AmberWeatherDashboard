using System;
using AmberWeatherDashboard.Server.Database.Repositories;

namespace AmberWeatherDashboard.Server.Jobs
{
	public class DeleteOldWeatherDataJob
	{
        private readonly WeatherHistoricalDataRepository weatherHistoricalDataRepository;

        public DeleteOldWeatherDataJob(WeatherHistoricalDataRepository weatherHistoricalDataRepository)
		{
            this.weatherHistoricalDataRepository = weatherHistoricalDataRepository;
        }

        public async Task Run()
        {
            await weatherHistoricalDataRepository.DeleteOldData();
        }
	}
}

