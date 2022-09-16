using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherSdk.Models.WebModels
{
    public class ApiResponse
    {
        /// <summary>
        /// Http Response code
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// API Response Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Any message headers from the API response
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }
        /// <summary>
        /// Program generatered reason why the API invocation failed
        /// </summary>
        public string FailureDescription { get; set; }
    }
}
