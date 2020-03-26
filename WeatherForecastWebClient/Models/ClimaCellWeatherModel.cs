using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    class ClimaCellWeatherModel
    {
        public Weather temp { get; set; }
        public Time observation_time { get; set; }
    }

    class Weather
    {
        public float value { get; set; }
        public string units { get; set; }
    }

    class Time
    {
        public string value { get; set; }
    }
}
