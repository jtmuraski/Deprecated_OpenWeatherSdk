using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetarAPI.Models.DataModels;
using MetarAPI.Models.XmlModels;

namespace MetarAPI.Actions
{
    public static class Parser
    {
        // <summary>
        // This class proived the necessary methods to parse data received from NOAA from XML to the objects in the Models/DataModels folder
        // </summary>

        public static List<Metar> ParseMetarToModel(Response response)
        {
            List<Metar> MetarCollection = new List<Metar>();
            foreach (var data in response.Data.METAR)
            {
                List<Models.DataModels.SkyCondition> skyConditions = new List<Models.DataModels.SkyCondition>();
                foreach (var sky in data.SkyCondition)
                {
                    skyConditions.Add(new Models.DataModels.SkyCondition()
                    {
                        CloudBaseFtAng = sky.CloudBaseFtAgl,
                        SkyCover = sky.SkyCover
                    });
                }
                List<Models.DataModels.QualityControlFlags> qualityControl = new List<Models.DataModels.QualityControlFlags>();
                foreach (var qual in data.QualityControlFlags)
                {
                    qualityControl.Add(new Models.DataModels.QualityControlFlags()
                    {
                        AutoStation = qual.AutoStation
                    });
                }

                MetarCollection.Add(new Metar()
                {
                    RawText = data.RawText,
                    StationId = data.StationId,
                    ObservationTime = data.ObservationTime,
                    Latitude = data.Latitude,
                    Longtitude = data.Longitude,
                    TempC = data.TempC,
                    DewPointC = data.DewpointC,
                    WindDirDegree = data.WindDirDegrees,
                    WindSpeedKnots = data.WindSpeedKt,
                    VisibilityStatuteMi = data.VisibilityStatuteMi,
                    AltimeterInHg = data.AltimInHg,
                    SeaLevelPressureMb = data.SeaLevelPressureMb,
                    QualityControlFlag = qualityControl,
                    SkyConditions = skyConditions,
                    FlightCategory = data.FlightCategory,
                    ThreeHrPressureTEndencyMb = data.ThreeHrPressureTendencyMb,
                    MaxTC = data.MaxTC,
                    MinTC = data.MinTC,
                    PrecipIn = data.PrecipIn,
                    Pcp6hrIn = data.Pcp6hrIn,
                    MetarType = data.MetarType,
                    ElevationM = data.ElevationM
                });
            }

            return MetarCollection;
        }
    }
}
