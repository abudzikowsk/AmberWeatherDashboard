using AmberWeatherDashboard.Server.Database;
using AmberWeatherDashboard.Server.Database.Repositories;
using AmberWeatherDashboard.Server.Filters;
using AmberWeatherDashboard.Server.Jobs;
using AmberWeatherDashboard.Server.Services;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Storage.SQLite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Any, 8111);
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddScoped<WeatherService>();
builder.Services.AddScoped<WeatherHistoricalDataRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite("Data Source=Database.db"));
builder.Services.AddHangfire(a => a.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
.UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
.UseSQLiteStorage());
builder.Services.AddHangfireServer();
builder.Services.AddScoped<GetWeatherDataJob>();
builder.Services.AddScoped<DeleteOldWeatherDataJob>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() },
    IsReadOnlyFunc = (DashboardContext context) => true
});

app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseGetWeatherDataJob();
app.UseDeleteOldWeatherDataJob();

app.Run();

