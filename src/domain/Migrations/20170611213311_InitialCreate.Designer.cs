using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Domain;

namespace domain.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20170611213311_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Domain.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AbsolutePressure");

                    b.Property<double>("DewPoint");

                    b.Property<double>("Gust");

                    b.Property<double>("HourlyRainfall");

                    b.Property<int>("HumidityIn");

                    b.Property<int>("HumidityOut");

                    b.Property<int>("Interval");

                    b.Property<int>("Number");

                    b.Property<double>("RelativePressure");

                    b.Property<double>("TempIn");

                    b.Property<double>("TempOut");

                    b.Property<DateTime>("Time");

                    b.Property<double>("WindChill");

                    b.Property<string>("WindDirection");

                    b.Property<double>("WindSpeed");

                    b.HasKey("Id");

                    b.ToTable("Measurements");
                });
        }
    }
}
