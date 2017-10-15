using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.IO;

namespace web.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private IWeatherService weatherService;
        private ILogger logger;
        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
            this.logger = Log.Logger;
        }
        [HttpGet("[action]")]
        public IEnumerable<Measurement> Latest(int count = 100)
        {
             return weatherService.List(count);
        }

        [HttpPost("[action]")]
        public async Task<StatusCodeResult> Upload()
        {
            var files = Request.Form.Files;   

            if(!files.Any())
            {
                logger.Information("No files received for upload");            
                return new StatusCodeResult(404);            
            }
            logger.Information("Received files for upload");
            
            foreach (var file in files)
            {

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    var fileContent = reader.ReadToEnd();

                    // Do actual import.
                    weatherService.Import(fileContent);   
                }
            }
            
            
            return new StatusCodeResult(201);
        }
    }
}
