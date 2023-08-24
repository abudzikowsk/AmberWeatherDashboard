using System;
using AmberWeatherDashboard.Server.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmberWeatherDashboard.Server.Database
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<WeatherData> WeatherHistoricalData { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
		}
	}
}

