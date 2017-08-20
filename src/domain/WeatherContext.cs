using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {
            
        }
        public DbSet<Measurement> Measurements{ get; set; }
    }   
}
