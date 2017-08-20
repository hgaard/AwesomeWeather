using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AbsolutePressure = table.Column<double>(nullable: false),
                    DewPoint = table.Column<double>(nullable: false),
                    Gust = table.Column<double>(nullable: false),
                    HourlyRainfall = table.Column<double>(nullable: false),
                    HumidityIn = table.Column<int>(nullable: false),
                    HumidityOut = table.Column<int>(nullable: false),
                    Interval = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    RelativePressure = table.Column<double>(nullable: false),
                    TempIn = table.Column<double>(nullable: false),
                    TempOut = table.Column<double>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    WindChill = table.Column<double>(nullable: false),
                    WindDirection = table.Column<string>(nullable: true),
                    WindSpeed = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
