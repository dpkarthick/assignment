using AirportApp.Models;
using AirportApp.Repository;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirportApp.Helper
{
    public class GeoLocationAPI: IGeoLocationRepository
    {
        /// <summary>
        /// Get Distance between Source and Destination Airports
        /// </summary>
        /// <param name="AirportData"></param>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        /// <returns></returns>
       public double GetDistance(AirportDetails AirportData,string Source,string Destination)
        {
            var SourceCity = AirportData.AirportDetailsList.Where(x => x.name != null && x.name.ToLower().Equals(Source.ToLower())).ToList().First();
            var DestinationCity = AirportData.AirportDetailsList.Where(x => x.name != null && x.name.ToLower().Equals(Destination.ToLower())).ToList().First();
            var sCoord = new GeoCoordinate(Convert.ToDouble(SourceCity.lat), Convert.ToDouble(SourceCity.lon));
            var eCoord = new GeoCoordinate(Convert.ToDouble(DestinationCity.lat), Convert.ToDouble(DestinationCity.lon));
            return (sCoord.GetDistanceTo(eCoord) / 1000);
        }
    }
}