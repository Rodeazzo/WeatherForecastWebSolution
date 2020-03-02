using System.Collections.Generic;

namespace WeatherForecastWebClient.ForecastModel
{
    class OpenWeatherMapForecastModel
    {
        public List<ListEmptyObject> list { get; set; }
    }

    class ListEmptyObject
    {
        public Main main { get; set; }
        public long dt { get; set; }
    }

    class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public float pressure { get; set; }
        public float sea_level { get; set; }
        public float grnd_level { get; set; }
        public float humidity { get; set; }
    }

    //class Date
    //{
    //    public string dt_txt { get; set; }
    //}
}
