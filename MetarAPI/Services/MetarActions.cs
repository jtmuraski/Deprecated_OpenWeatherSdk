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
    public class MetarActions : IMetarActions
    {
        private MetarContext MetarContext { get; set; }

        public MetarActions(string connectionString)
        {
            MetarContext = new MetarContext(connectionString);
        }

        /// <summary>
        /// Returns a list of all the metars in the database. WARNING: This could be a very large amount of data.
        /// </summary>
        public IEnumerable<Metar> GetAllMetars() => MetarContext.Metars;

        /// <summary>
        /// Return a list of Metars for a specific reporting station, such as KMSP (Minneapolis/Saint Paul International Airport)
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public IEnumerable<Metar> FilterByStation(string stationId)
        {
               return MetarContext.Metars.Where(report => report.StationId == stationId).ToList();
        }

        /// <summary>
        /// Return all Metars between two DateTimes
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IEnumerable<Metar> FilterByTime(DateTime start, DateTime end)
        {
            return MetarContext.Metars.Where(report => report.ObservationTime <= start && report.ObservationTime >= end).ToList();
        }

        public IEnumerable<Metar> GetYesterdayReports()
        {
            var yesterday = DateTime.UtcNow.AddDays(-1);
            return MetarContext.Metars.Where(report => report.ObservationTime.Date == yesterday.Date).ToList();
        }

        public int Commit()
        {
            return MetarContext.SaveChanges();
        }
    }
}
