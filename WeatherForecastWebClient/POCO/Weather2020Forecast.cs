using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{
    class Weather2020Forecast
    {
        private DateTime startDate;
        private int temperatureLow;
        private int temperatureHigh;

        public Weather2020Forecast(long epochDateTime, int low, int high)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochDateTime);
            this.startDate = dateTimeOffset.UtcDateTime;
            this.temperatureLow = low;
            this.temperatureHigh = high;
        }

        public DateTime getDateTime()
        {
            return startDate;
        }

        public float getMinimum()
        {
            return temperatureLow;
        }

        public float getMaximum()
        {
            return temperatureHigh;
        }
    }
}
