using AirportApp.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;

namespace AirportApp.Helper
{
    public static class Helpers
    {
        //Json data method:to get user details from json file
        public static List<Airport> JsonData(IServiceHelperRepository _ServiceHelperRepository)
        {
            //get the Json filepath 
            var file = _ServiceHelperRepository.GetjsonStream();

            //deserialize JSON from file  
            if (!string.IsNullOrEmpty(file))
            {
               var AirportData= JsonConvert.DeserializeObject<List<Airport>>(file);
               return AirportData;
            }
            return null;
        }
       
    }
}