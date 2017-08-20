﻿using System;
using Domain;
using TinyCsvParser;
using System.Text;
using System.Linq;

namespace Cli
{
    class Program
    {
        static void Main(string[] args)
        {

            var app = new Microsoft.Extensions.CommandLineUtils.CommandLineApplication();
            app.Name = "awesome";
            app.HelpOption("-?|-h|--help");
           
           app.Command("import", (command) =>
            {
                command.Description = "Import measurements form json file";
                command.HelpOption("-?|-h|--help");

                var fileArgument = command.Argument("[fileName]", "Path for json file");

                command.OnExecute(() =>
                {
                    var csvParserOptions = new CsvParserOptions(true, new[] { '\t' });
                    var csvMapper = new MeasurementMapping();
                    var csvParser = new CsvParser<Measurement>(csvParserOptions, csvMapper);
                    // var service = new WeatherService();

                    // var result = csvParser
                    //     .ReadFromFile(@"data.csv", Encoding.ASCII)
                    //     .ToList();

                    // foreach (var measurement in result)
                    // {
                    //     service.Add(measurement.Result);
                    // }

                    Console.WriteLine("done");
                    return 0;
                });
            });

            app.Command("temp", (command) =>
            {
                command.Description = "Get temperature";
                command.HelpOption("-?|-h|--help");

                var locationArg = command.Argument("[location]", "in or out");

                command.OnExecute(() =>
                {
                    Console.WriteLine("Temperature {0} is...", locationArg);
                    // var service = new WeatherService();
                    // var tempIn = service.GetTempIn(new DateTime(1900,1,1), DateTime.Now);
                    // Console.WriteLine("Here are the latest {0} entries", tempIn.Length);
                    return 0;
                });
            });
        }
    }
}
