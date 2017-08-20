using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Serilog;
using TinyCsvParser;

namespace Domain
{
   public interface IWeatherService
    {
        void Add(Measurement measurement);
        List<Measurement> List(int count);
        DataPoint<double> [] GetTempIn(DateTime after, DateTime before);
        void Import(string file);
    }    
    public class WeatherService : IWeatherService
    {
        private WeatherContext weatherContext;
        private ILogger logger;
        public WeatherService(WeatherContext context, ILogger logger)
        {
            weatherContext = context;
            this.logger = logger;
        }
        public void Add(Measurement measurement)
        {
            if (measurement == null)
            {
                logger.Warning("entity is null");
                return;
            }
            try
            {
                // try get 
                if(weatherContext.Measurements.Where(x => x.Time == measurement.Time).Any())
                {
                    logger.Warning("there is already a measurement for this point in time. Skipping");
                    return;
                }
                
                weatherContext.Measurements.Add(measurement);
                weatherContext.SaveChanges();
                logger.Information("Successfully added new measurement with Id {@Measurement}", measurement);
            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);
                throw;
            }
        }

        public DataPoint<double> [] GetTempIn(DateTime after, DateTime before)
        {
                return weatherContext.Measurements
                    .Where(x => x.Time > after && x.Time < before)
                    .Select(x => new DataPoint<double>(x.TempIn, x.Time))
                    .ToArray();
        }

        public void Import(String file)
        {
            var parserOptions = new CsvParserOptions(true, new[] { '\t' });
            var readerOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            var csvMapper = new MeasurementMapping();
            var csvParser = new CsvParser<Measurement>(parserOptions, csvMapper);

            var measurements = csvParser.ReadFromString(readerOptions,  file);
            
            foreach (var measurement in measurements)
            {   
                Add(measurement.Result);
            }
        }

        public List<Measurement> List(int count)
        {
            logger.Information("Getting latest {count} measurements", count);
            return weatherContext.Measurements
                .OrderByDescending(x => x.Time)
                .Take(count)
                .ToList();
        }

    }
}