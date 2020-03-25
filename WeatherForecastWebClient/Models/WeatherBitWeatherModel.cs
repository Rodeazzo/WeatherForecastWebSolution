using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    class WeatherBitWeatherModel
    {
        public List<Data> data { get; set; }
    }

    class Data
    {
        public float temp { get; set; }
    }
}
