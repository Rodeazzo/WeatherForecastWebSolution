using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{
    class ClimaCellForecast
    {
        private DateTime observation_time;
        private float value;
        private string units;

        public ClimaCellForecast(string epochDateTime, float val, string un)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(epochDateTime);
            this.observation_time = dateTimeOffset.UtcDateTime;
            this.value = val;
            this.units = un;
        }

        public DateTime getDateTime()
        {
            return observation_time;
        }

        public float getValue()
        {
            return value;
        }

        public string getUnits()
        {
            return units;
        }
    }
}
