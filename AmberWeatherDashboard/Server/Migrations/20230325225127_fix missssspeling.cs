using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmberWeatherDashboard.Server.Migrations
{
    public partial class fixmissssspeling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Windgusts",
                table: "WeatherHistoricalData",
                newName: "WindGusts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WindGusts",
                table: "WeatherHistoricalData",
                newName: "Windgusts");
        }
    }
}
