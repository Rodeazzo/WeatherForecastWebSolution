using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    class DarkSkyForecastModel
    {
        public string timezone { get; set; }
        public DarkSkyDailyForecast daily { get; set; }
    }

    class DarkSkyDailyForecast
    {
        public List<DarkSkyData> data { get; set; }
    }

    class DarkSkyData
    {
        public long time { get; set; }
        public float temperatureMin { get; set; }
        public float temperatureMax { get; set; }
    }
}
