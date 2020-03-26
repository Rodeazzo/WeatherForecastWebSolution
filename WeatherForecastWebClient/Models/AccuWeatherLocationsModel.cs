using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    class AccuWeatherLocationsModel
    {
        public string Key { get; set; }
        public GeoPosition GeoPosition { get; set; }
    }

    class GeoPosition
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
