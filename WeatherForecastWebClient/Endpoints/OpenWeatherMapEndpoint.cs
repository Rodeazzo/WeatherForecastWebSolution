using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class OpenWeatherMapEndpoint : Endpoint
    {
        public OpenWeatherMapEndpoint() :
            base("c31c79a010a54878ef9b05feee7f2503",
                 "http://api.openweathermap.org/data/",
                 new Dictionary<EndpointTypes, string> {
                     { EndpointTypes.CURRENT, "weather" },
                     { EndpointTypes.FORECAST, "forecast" }
                 },
                 "2.5",
                 "metric") { }

        public string getByCityNameEndpoint(string cityName, EndpointTypes endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);

            return stringBuilder.ToString();
        }

        public string getByCityNameEndpoint(string cityName, string countryCode, EndpointTypes endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append(",");
            stringBuilder.Append(countryCode);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);

            return stringBuilder.ToString();
        }

        public string getByCityNameEndpoint(string cityName, string state, string countryCode, EndpointTypes endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append(",");
            stringBuilder.Append(state);
            stringBuilder.Append(",");
            stringBuilder.Append(countryCode);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);

            return stringBuilder.ToString();
        }
    }
}
