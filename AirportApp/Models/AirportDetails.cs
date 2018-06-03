using AirportApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportApp.Models
{
    public class AirportDetails
    {
        public AirportDetails()
        {
            AirportDetailsList = new List<Airport>();
            CountryList = new Dictionary<string, string>();
        }
        public List<Airport> AirportDetailsList { get; set; }

        public Dictionary<string,string> CountryList { get; set; }
    }
}