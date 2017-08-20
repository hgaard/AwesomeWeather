using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }
        public int Number{ get; set; }
		public DateTime Time { get; set;}
        public int Interval { get; set; }
		public double TempIn { get; set; }
		public int HumidityIn { get; set; }
		public double TempOut { get; set; }
		public int HumidityOut { get; set; }
		public double RelativePressure { get; set; }
		public double AbsolutePressure { get; set; }
		public double WindSpeed { get; set; }
		public double Gust { get; set; }
		public string WindDirection { get; set; }
		public double DewPoint { get; set; }
		public double WindChill { get; set; }
        public double HourlyRainfall { get; set; }
    }   
}