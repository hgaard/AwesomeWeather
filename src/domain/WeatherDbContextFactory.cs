using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Domain
{
    public class WeatherDbContextFactory : IDbContextFactory<WeatherContext>
    {
        public WeatherContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherContext>();
            return Create(
                options.ContentRootPath,
                options.EnvironmentName);
        }

        private WeatherContext Create(string basePath, string environmentName)
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            var connstr = config.GetConnectionString("WeatherDatabase");

            if (String.IsNullOrWhiteSpace(connstr) == true)
            {
                throw new InvalidOperationException(
                    "Could not find a connection string named 'WeatherDatabase'.");
            }
            else
            {
                return Create(connstr);
            }
        }

        private WeatherContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
                    $"{nameof(connectionString)} is null or empty.",
                    nameof(connectionString));

            var optionsBuilder =
                new DbContextOptionsBuilder<WeatherContext>();

            optionsBuilder.UseNpgsql(connectionString);

            return new WeatherContext(optionsBuilder.Options);
        }
    }
}
