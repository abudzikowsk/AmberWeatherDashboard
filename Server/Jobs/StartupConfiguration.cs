using System;
using Hangfire;

namespace AmberWeatherDashboard.Server.Jobs
{
	public static class StartupConfiguration 
	{
		public static void UseGetWeatherDataJob(this WebApplication webApplication)
		{
			RecurringJob.AddOrUpdate<GetWeatherDataJob>("getWeatherDataJob", s => s.Run(), "0 * * * *");
		}

		public static void UseDeleteOldWeatherDataJob(this WebApplication webApplication)
		{
			RecurringJob.AddOrUpdate<DeleteOldWeatherDataJob>("deleteOldDataJob", d => d.Run(), Cron.Daily);
		}

    };
}

