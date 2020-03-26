using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    class ClimaCellForecastModel
    {
        public List<Forecast> temp { get; set; }
    }

    class Forecast
    {
        public string observation_time { get; set; }
        public MinMaxTemp min { get; set; }
        public MinMaxTemp max { get; set; }
    }

    class MinMaxTemp
    {
        public float value { get; set; }
        public string units { get; set; }
    }
}
