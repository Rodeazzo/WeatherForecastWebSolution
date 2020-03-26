using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{
    class DarkSkyForecast
    {
        private string timezone;
        private DateTime dateTime;
        private float temperatureMin;
        private float temperatureMax;

        public DarkSkyForecast(string timezone_, long epochDateTime, float min, float max)
        {
            this.timezone = timezone_;
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochDateTime);
            dateTime = dateTimeOffset.UtcDateTime;
            this.temperatureMin = min;
            this.temperatureMax = max;
        }

        public string getTimezone()
        {
            return timezone;
        }

        public DateTime getDateTime()
        {
            return dateTime;
        }

        public float getMinTemp()
        {
            return temperatureMin;
        }

        public float getMaxTemp()
        {
            return temperatureMax;
        }
    }
}
