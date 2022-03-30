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
        private MetarContext Metars { get; set; }

        public MetarAPI(string connectionString)
        {
            Metars = new MetarContext(connectionString);
        }

        public IEnumerable<Metar> GetAllMetars => Metars.Metars;

        public IEnumerable<Metar> FilterByStation(List<string> stations)
        {
            List<Models.DataModels.Metar> Results = new List<Models.DataModels.Metar>();
            var result = Metars.Metars.Where(met => met.StationId == "Hello").ToList();
            Results.Add(result);
            foreach (var station in stations)
            {
                var filter = Metars.Metars.Where(metar => metar.StationId == station).ToList();
            }
            return Results;

        }
    }
}
