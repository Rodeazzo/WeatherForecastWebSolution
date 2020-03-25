using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class WeatherBitEndpoint : Endpoint
    {
        public WeatherBitEndpoint() :
            base("16ae13bd22614f56875ce25db3a8c51b",
                 "https://api.weatherbit.io/",
                 new Dictionary<EndpointTypes, string> {
                     { EndpointTypes.CURRENT, "current" },
                     { EndpointTypes.FORECAST, "forecast" }
                 },
                 "v2.0") { }

        public string getCurrentWeatherByCityNameEndpoint(string cityName)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointTypes.CURRENT]}");
            stringBuilder.Append($"?city={cityName}");
            stringBuilder.Append($"&key={apiKey}");

            return stringBuilder.ToString();
        }

        public string getWeatherForecast(string cityName)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointTypes.FORECAST]}");
            stringBuilder.Append("/daily");
            stringBuilder.Append("?city=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&key=");
            stringBuilder.Append(apiKey);

            return stringBuilder.ToString();
        }
    }
}
