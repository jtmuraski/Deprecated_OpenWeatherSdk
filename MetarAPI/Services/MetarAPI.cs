using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MetarAPI.Models.DataModels;
using Npgsql.EntityFrameworkCore;
using Npgsql;

namespace MetarAPI.Services
{
    public class MetarAPI
    {
        private MetarContext MetarContext { get; set; }

        public MetarAPI(string connectionString)
        {
            MetarContext = new MetarContext(connectionString);
        }

        public IEnumerable<Metar> GetAllMetars => MetarContext.Metars;

        public IEnumerable<Metar> FilterByStation(string station)
        {
               return MetarContext.Metars.Where(report => report.StationId == station).ToList();
        }

        public IEnumerable<Metar> FilterByTime(DateTime start, DateTime end)
        {
            return MetarContext.Metars.Where(report => report.ObservationTime <= start && report.ObservationTime >= end).ToList();
        }
    }
}
