using System;
using Hangfire.Dashboard;

namespace AmberWeatherDashboard.Server.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            return true;
        }
    }
}

