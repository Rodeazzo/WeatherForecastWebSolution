using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    class WeatherBitForecastModel
    {
        public List<Dataf> data { get; set; }
    }

    class Dataf
    {
        public string datetime { get; set; }
        public float min_temp { get; set; }
        public float max_temp { get; set; }
    }
}
