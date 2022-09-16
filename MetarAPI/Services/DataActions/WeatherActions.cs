using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenWeatherSdk.Models.WebModels;

namespace OpenWeatherSdk.Services.DataActions
{
    public static class WeatherActions
    {
        private static string _baseUrl = "";

        /// <summary>
        /// Get a summary of weather data from the previous 2 days. Defaults to last 2 days.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static WeatherShortSummary GetShortWeatherSummary()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.
            var result = new WeatherShortSummary();
            return result;
        }
    }
}
