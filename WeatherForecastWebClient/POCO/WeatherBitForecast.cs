using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{
    class WeatherBitForecast
    {
        private DateTime ts;
        private float min_temp;
        private float max_temp;

        public WeatherBitForecast(string epochDateTime, float min, float max)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(epochDateTime);
            ts = dateTimeOffset.UtcDateTime;
            min_temp = min;
            max_temp = max;
        }

        public DateTime getDateTime()
        {
            return ts;
        }

        public float getMinTemp()
        {
            return min_temp;
        }

        public float getMaxTemp()
        {
            return max_temp;
        }
    }
}
