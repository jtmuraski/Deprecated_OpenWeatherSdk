using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherSdk.Models.WebModels
{
    public class WeatherShortSummary
    {
        /// <summary>
        /// Unique Identifier of the weather station that the data came from
        /// </summary>
        public string StationId { get; set; }
        /// <summary>
        /// Zulu time of the weather observation
        /// </summary>
        public DateTime ZuluObservationTime { get; set; }
        /// <summary>
        /// Central time weather observation time
        /// </summary>
        public DateTime LocalObservationTime { get; set; }
        /// <summary>
        /// Temperature in Celsius
        /// </summary>
        public double TempC { get; set; }
        /// <summary>
        /// Converted Celsius to F
        /// </summary>
        public double TempF { get; set; }
        /// <summary>
        /// Air Pressure
        /// </summary>
        public double AltimeterInHg { get; set; }
        /// <summary>
        /// Any precipitation that occured during the hour
        /// </summary>
        public double PrecipIn { get; set; }
        /// <summary>
        /// Response from the AWS API Gateway call. Developer can use this to handle any failures that occured during
        /// invocation
        /// </summary>
        public ApiResponse Response {get; set;}
    }
}
