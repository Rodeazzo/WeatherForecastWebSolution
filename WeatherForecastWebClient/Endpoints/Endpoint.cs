using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    public enum EndpointTypes
    {
        LOCATION,
        CURRENT,
        FORECAST        
    }

    abstract class Endpoint
    {
        protected string apiKey;
        protected string baseEndpoint;
        protected string units { get; set; }
        protected string version { get; }
        protected Dictionary<EndpointTypes, string> endpointTypeDictionary { get; }
        

        public Endpoint(string apiKey, string baseEndpoint, Dictionary<EndpointTypes, string> endpointTypeDictionary, string version="", string units = "") 
        {
            this.apiKey = apiKey;
            this.baseEndpoint = baseEndpoint;
            this.endpointTypeDictionary = endpointTypeDictionary;
            this.version = version;
            this.units = units;
        }
    }
}
