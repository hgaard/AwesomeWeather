using Domain;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace Domain
{
    public class MeasurementMapping : CsvMapping<Measurement>
    {
        public MeasurementMapping() : base()
        {
            MapProperty(0, x => x.Number);
            MapProperty(1, x => x.Time);
            MapProperty(2, x => x.Interval);
            MapProperty(3, x => x.TempIn);
            MapProperty(4, x => x.HumidityIn);
            MapProperty(5, x => x.TempOut);
			MapProperty(6, x => x.HumidityOut);
			MapProperty(7, x => x.RelativePressure);
			MapProperty(8, x => x.AbsolutePressure);
			MapProperty(9, x => x.WindSpeed);
			MapProperty(10, x => x.Gust);
			MapProperty(11, x => x.WindDirection);
			MapProperty(12, x => x.DewPoint);
			MapProperty(13, x => x.WindChill);
            MapProperty(14, x => x.HourlyRainfall);
		}     
    }
}