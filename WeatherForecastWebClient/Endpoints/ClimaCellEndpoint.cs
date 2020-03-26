using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class ClimaCellEndpoint : Endpoint
    {
        public ClimaCellEndpoint() :
            base("tP3poginUG7XmneGZhRDfcvI0vRSyb1N",
                 "https://api.climacell.co/",
                 new Dictionary<EndpointTypes, string> {
                     { EndpointTypes.CURRENT, "weather/realtime" },
                     { EndpointTypes.FORECAST, "weather/forecast/daily"}
                 }, "v3")
        { }

        public string getCurrentWeather(string latitude, string longitude, EndpointTypes endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"{version}/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append($"?apikey={apiKey}");
            stringBuilder.Append($"&lat={latitude}");
            stringBuilder.Append($"&lon={longitude}");
            stringBuilder.Append("&fields=temp:C");

            return stringBuilder.ToString();
        }

        public string getForecast(string latitude, string longitude, EndpointTypes endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"{version}/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append($"?apikey={apiKey}");
            stringBuilder.Append($"&lat={latitude}");
            stringBuilder.Append($"&lon={longitude}");
            stringBuilder.Append("&start_time=now");
            //stringBuilder.Append($"&end_time={currentTime}");
            stringBuilder.Append("&fields=temp:C");

            return stringBuilder.ToString();
        }
    }
}
