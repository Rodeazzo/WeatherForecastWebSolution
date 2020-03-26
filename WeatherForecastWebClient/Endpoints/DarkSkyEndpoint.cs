using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class DarkSkyEndpoint : Endpoint
    {
        public DarkSkyEndpoint() :
            base("1e009576401090c7b75403775da62227",
                 "https://api.darksky.net/",
                 new Dictionary<EndpointTypes, string> {
                     { EndpointTypes.FORECAST, "forecast" }
                 })
        { }

        public string getForecast(string position)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"{endpointTypeDictionary[EndpointTypes.FORECAST]}");
            stringBuilder.Append($"/{apiKey}");
            stringBuilder.Append($"/{position}");

            return stringBuilder.ToString();
        }
    }
}
