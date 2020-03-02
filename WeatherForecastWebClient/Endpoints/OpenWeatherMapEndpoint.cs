using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    public enum EndpointTypes
    {
        CURRENTWEATHER,
        FORECAST
    }

    class OpenWeatherMapEndpoint
    {
        private const string baseCurrentWeatherEndpoint = "http://api.openweathermap.org/data/2.5/weather";
        private const string baseForecastEndpoint = "http://api.openweathermap.org/data/2.5/forecast";

        public string apiKey { get; set; }
        public string units { get; set; }

        private string currentEndpoint;

        public OpenWeatherMapEndpoint()
        {
            apiKey = "c31c79a010a54878ef9b05feee7f2503";
            units = "metric";

            // Default endpoint
            this.currentEndpoint = baseCurrentWeatherEndpoint;
        }

        public void setCurrentWeatherEndpoint(EndpointTypes endpointTypes)
        {
            switch(endpointTypes)
            {
                case EndpointTypes.CURRENTWEATHER:
                    this.currentEndpoint = baseCurrentWeatherEndpoint; break;
                case EndpointTypes.FORECAST:
                    this.currentEndpoint = baseForecastEndpoint; break;
                default:
                    this.currentEndpoint = baseCurrentWeatherEndpoint; break;
            }
        }

        public string getByCityNameEndpoint(string cityName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.currentEndpoint);
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);

            return stringBuilder.ToString();
        }

        public string getByCityNameEndpoint(string cityName, string countryCode)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.currentEndpoint);
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

        public string getByCityNameEndpoint(string cityName, string state, string countryCode)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.currentEndpoint);
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
