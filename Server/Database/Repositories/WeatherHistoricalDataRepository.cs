using System;
using AmberWeatherDashboard.Server.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmberWeatherDashboard.Server.Database.Repositories
{
	public class WeatherHistoricalDataRepository
	{
        private readonly ApplicationDbContext applicationDbContext;

        public WeatherHistoricalDataRepository(ApplicationDbContext applicationDbContext)
		{
            this.applicationDbContext = applicationDbContext; 
        }

        public async Task<WeatherData[]> GetAll()
        {
            return await applicationDbContext.WeatherHistoricalData.OrderByDescending(i => i.Date).ToArrayAsync();
        }

        public async Task Create(WeatherData weatherData)
        {
            weatherData.Date = DateTime.Now;
            applicationDbContext.WeatherHistoricalData.Add(weatherData);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteOldData()
        {
            var oldData = await applicationDbContext.WeatherHistoricalData.Where(o => o.Date < DateTime.Today.AddDays(-30)).ToArrayAsync();
            applicationDbContext.WeatherHistoricalData.RemoveRange(oldData);
            await applicationDbContext.SaveChangesAsync();
        }
	}
}

