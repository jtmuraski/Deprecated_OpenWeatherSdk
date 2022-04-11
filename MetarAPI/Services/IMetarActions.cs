using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetarAPI.Models.DataModels;

namespace MetarAPI.Services
{
    public interface IMetarActions
    {
        public IEnumerable<Metar> GetAllMetars();
        public IEnumerable<Metar> FilterByStation(string stationName);
        public IEnumerable<Metar> FilterByTime(DateTime start, DateTime end);
        public IEnumerable<Metar> GetYesterdayReports();
    }
}
